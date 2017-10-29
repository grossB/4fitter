using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _4fitter.Models;
using _4fitter.Utilities;
using Microsoft.AspNet.Identity;

namespace _4fitter.Controllers
{
	public class ArticlesController : Controller
	{
		private ApplicationDbContext db = new ApplicationDbContext();

		// GET: Articles
		public ActionResult Index()
		{
			return View(db.Articles.ToList());
		}

		// GET: Articles/<friendly-id>
		public ActionResult Details(string id = "")
		{
			if (id.IsNullOrEmpty())
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Article article = db.Articles.First(a => a.FriendlyID == id);
			if (article == null)
			{
				return HttpNotFound();
			}
			return View(article);
		}

		// GET: Articles/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Articles/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Create([Bind(Include = "ID,Title,IllustrationURL,FriendlyID,ArticleType,ContentTextFormatted,Author,RawTags")] Article article)
		{
			this.CheckIfTitleUnique(article);

			if (ModelState.IsValid)
			{
				var tags = this.GetTagsByRawTags(article.RawTags);
                var correctTags = new List<Tag>();

				foreach (var tag in tags)
				{
					var isDuplicated = db.Tags.Any(t => t.Name == tag.Name);

					if (isDuplicated)
					{
                        correctTags.Add(db.Tags.First(t => t.Name == tag.Name));
						continue;
					}
                    correctTags.Add(tag);
				}

				article.Tags = correctTags;
                article.Author = User.Identity.GetUserId();
                db.Articles.Add(article);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(article);
		}

		// GET: Articles/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Article article = db.Articles.Find(id);
			if (article == null)
			{
				return HttpNotFound();
			}
			return View(article);
		}

		// POST: Articles/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ValidateInput(false)]
		public ActionResult Edit([Bind(Include = "ID,Title,IllustrationURL,FriendlyID,ArticleType,ContentTextFormatted,Author")] Article article)
		{
			this.CheckIfTitleUnique(article);

			if (ModelState.IsValid)
			{
				db.Entry(article).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(article);
		}

		// GET: Articles/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Article article = db.Articles.Find(id);
			if (article == null)
			{
				return HttpNotFound();
			}
			return View(article);
		}

		// POST: Articles/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Article article = db.Articles.Find(id);
			db.Articles.Remove(article);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}

		private void CheckIfTitleUnique(Article article)
		{
			var isDuplicated = db.Articles.Any(a => a.Title == article.Title && 
													a.FriendlyID == article.FriendlyID &&
													a.ID != article.ID);
			if (isDuplicated)
			{
				ModelState.AddModelError("FriendlyID", Resources.ErrorStrings.FriendlyIdMustBeUnique);
			}
		}

		private List<Tag> GetTagsByRawTags(string rawTags)
		{
			var result = new List<Tag>();

			var splittedTags = rawTags.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

			return splittedTags.Select(tag => new Tag
			{
				Name = tag
			}).ToList();
		}
	}
}
