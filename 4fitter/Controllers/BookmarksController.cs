using System.Net;
using System.Web.Mvc;
using _4fitter.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace _4fitter.Controllers
{
    public class BookmarksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // POST: Bookmarks/Create
        [HttpPost]
        public HttpStatusCode Create([Bind(Include = "ID,UserID,ArticleID")] Bookmark bookmark)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userExists = userManager.FindById(bookmark.UserID) != null;

            if (ModelState.IsValid && userExists)
            {
                bookmark.Article = db.Articles.Find(bookmark.ArticleID);
                db.Bookmarks.Add(bookmark);
                db.SaveChanges();
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.BadRequest;
        }

        // POST: Bookmarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public HttpStatusCode DeleteConfirmed(int id)
        {
            Bookmark bookmark = db.Bookmarks.Find(id);
            db.Bookmarks.Remove(bookmark);

            var retCode = db.SaveChanges();

            return retCode > 0 ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
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
