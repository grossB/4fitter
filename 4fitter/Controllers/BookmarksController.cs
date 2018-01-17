using System.Net;
using System.Web.Mvc;
using _4fitter.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace _4fitter.Controllers
{
    public class BookmarksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // POST: Bookmarks/Create
        [HttpPost]
        public HttpStatusCode Create([Bind(Include = "ID,UserID,ArticleID")] Bookmark bookmark)
        {
            var userExists = this.IsUserExist(bookmark.UserID);

            if (ModelState.IsValid && userExists)
            {
                bookmark.Article = db.Articles.Find(bookmark.ArticleID);
                db.Bookmarks.Add(bookmark);
                db.SaveChanges();
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.BadRequest;
        }

        // GET: Bookmarks/Check/6
        [HttpGet, ActionName("Check")]
        public bool IsArticleBookmarked(int id, string userId)
        {
            return db.Bookmarks.Any(b => b.Article.ID == id && b.UserID == userId);
        }

        // POST: Bookmarks/Delete/5?userId=<guid>
        [HttpPost, ActionName("Delete")]
        public HttpStatusCode DeleteConfirmed(int id, string userId)
        {
            var userExists = this.IsUserExist(userId);

            if (!userExists)
            {
                return HttpStatusCode.InternalServerError;
            }

            Bookmark bookmark = db.Bookmarks.First(b => b.Article.ID == id && b.UserID == userId);
            db.Bookmarks.Remove(bookmark);

            var retCode = db.SaveChanges();

            return retCode > 0 ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }

        // GET: Bookmarks/User/<guid>
        [HttpGet, ActionName("User")]
        public ActionResult GetBookmarksByUserId(string userId)
        {
            var userExists = this.IsUserExist(userId);

            if (!userExists)
            {
                return new HttpStatusCodeResult(500);
            }

            var bookmarks = db.Bookmarks.Where(b => b.UserID == userId).ToList();

            foreach (var bookmark in bookmarks)
            {
                var article = new Article
                {
                    ID = bookmark.Article.ID,
                    FriendlyID = bookmark.Article.FriendlyID,
                    Title = bookmark.Article.Title
                };
                bookmark.Article = article;
            }

            return Json(bookmarks, JsonRequestBehavior.AllowGet);
        }

        private bool IsUserExist(string id)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            return userManager.FindById(id) != null;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
