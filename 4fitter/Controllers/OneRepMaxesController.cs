using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using _4fitter.Models;

namespace _4fitter.Controllers
{
    public class OneRepMaxesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public static Dictionary<short, double> oneRepMaxPercentages = new Dictionary<short, double>()
        {
            {1, 1},
            {2, 0.95},
            {3, 0.93},
            {4, 0.90},
            {5, 0.87},
            {6, 0.85},
            {7, 0.83},
            {8, 0.80},
            {9, 0.77},
            {10, 0.75},
            {11, 0.73},
            {12, 0.70}
        };

        // GET: OneRepMaxes
        public ActionResult Index()
        {
            //IEnumerable<SelectList> aa = new[] {new SelectList(ViewBag.oneRepMax) };
            ViewBag.oneRepMax = oneRepMaxPercentages.Keys.ToList();

           // ViewBag.oneRepMax = aa;
            return View(db.OneRepMaxes.ToList());
        }

        // GET: OneRepMaxes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OneRepMax oneRepMax = db.OneRepMaxes.Find(id);
            if (oneRepMax == null)
            {
                return HttpNotFound();
            }
            return View(oneRepMax);
        }

        // GET: OneRepMaxes/Create
        public ActionResult Create(string result = "")
        {
            ViewBag.oneRepMax = oneRepMaxPercentages.Keys.ToList();
            ViewBag.weight = result;

            return View();
        }

        // POST: OneRepMaxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Weight,Repetitions")] OneRepMax oneRepMax)
        {
            if (ModelState.IsValid)
            {
                db.OneRepMaxes.Add(oneRepMax);

                var weightMax = oneRepMaxPercentages[oneRepMax.Repetitions];
                weightMax = oneRepMax.Weight/weightMax ;
                weightMax = Math.Round(weightMax, 2);
                string result2 = $"Yours 1 rep max is : {weightMax}";
                return RedirectToAction("Create", new { result = result2 } );

            }

            return View(oneRepMax);
        }

        // GET: OneRepMaxes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OneRepMax oneRepMax = db.OneRepMaxes.Find(id);
            if (oneRepMax == null)
            {
                return HttpNotFound();
            }
            return View(oneRepMax);
        }

        // POST: OneRepMaxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Weight,Repetitions")] OneRepMax oneRepMax)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oneRepMax).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oneRepMax);
        }

        // GET: OneRepMaxes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OneRepMax oneRepMax = db.OneRepMaxes.Find(id);
            if (oneRepMax == null)
            {
                return HttpNotFound();
            }
            return View(oneRepMax);
        }

        // POST: OneRepMaxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OneRepMax oneRepMax = db.OneRepMaxes.Find(id);
            db.OneRepMaxes.Remove(oneRepMax);
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
    }
}
