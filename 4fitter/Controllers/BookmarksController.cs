using System.Net;
using System.Web.Mvc;
using _4fitter.Models;

namespace _4fitter.Controllers
{
    public class BookmarksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // POST: Bookmarks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public HttpStatusCode Create([Bind(Include = "ID,UserID")] Bookmark bookmark)
        {
            if (ModelState.IsValid)
            {
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
