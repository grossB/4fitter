using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using _4fitter.Enums;
using _4fitter.Models;
using _4fitter.Utilities;

namespace _4fitter.Controllers
{
    public class BmrCalculatorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BmrCalculators
        public ActionResult Index()
        {
            EmailNotyfication emailNotyfication = new EmailNotyfication();
            emailNotyfication.NewMealCalcWithDayOfWeekModel();
            //CalculateMealPerWeek();
            return View(db.BmrCalculators.ToList());
        }

        // GET: BmrCalculators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BmrCalculator bmrCalculator = db.BmrCalculators.Find(id);
            if (bmrCalculator == null)
            {
                return HttpNotFound();
            }
            return View(bmrCalculator);
        }


        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                if (_userManager == null && HttpContext == null)
                {
                    return new ApplicationUserManager(new UserStore<ApplicationUser>(db));
                }
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: BmrCalculators/Create
        public ActionResult Create(double? baseResult, double? totalResult)
        {
            ViewBag.baseResult = baseResult;
            ViewBag.totalResult = totalResult;
            return View("Create");
        }

        // POST: BmrCalculators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserId,Weight,Activity,SexType,DateTime,Notification,TargetType,NumberOfWeeks,Height,Age")] BmrCalculator bmrCalculator)
        {
            if (ModelState.IsValid)
            {
                RandomUtils randomUtils = new RandomUtils();
                int sexTypeBonus = randomUtils.SexBasedBonusCalories(bmrCalculator.SexType);
                double activityMuptilier = randomUtils.ActivityMultiplier(bmrCalculator.Activity);
                double weight = bmrCalculator.Weight;
                double target = randomUtils.TargetBasedBonusCalories(bmrCalculator.TargetType);


                var baseResult2 = (9.99 * weight + 6.25 * bmrCalculator.Height - 4.92 * bmrCalculator.Age + 50);
                double totalResult2 = baseResult2 * activityMuptilier + sexTypeBonus + target + 50 ;


                if (bmrCalculator.Notification == false)
                {
                    return RedirectToAction("Create", new { baseResult = baseResult2, totalResult = totalResult2 });
                }
                else
                {
                    string strCurrentUserId = User.Identity.GetUserId();
                    bmrCalculator.UserId = strCurrentUserId;
                    bmrCalculator.DateTime = DateTime.Now;
                    bmrCalculator.BaseCalories = totalResult2;

                    db.BmrCalculators.Add(bmrCalculator);
                    db.SaveChanges();

                    return RedirectToAction("Create", new { baseResult = baseResult2, totalResult = totalResult2 });
                }
            }

            return View(bmrCalculator);
        }

        // GET: BmrCalculators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BmrCalculator bmrCalculator = db.BmrCalculators.Find(id);
            if (bmrCalculator == null)
            {
                return HttpNotFound();
            }
            return View(bmrCalculator);
        }

        // POST: BmrCalculators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserId,Weight,Activity,SexType,DateTime,Notification,TargetType,NumberOfWeeks,Height,Age")] BmrCalculator bmrCalculator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bmrCalculator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bmrCalculator);
        }

        // GET: BmrCalculators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BmrCalculator bmrCalculator = db.BmrCalculators.Find(id);
            if (bmrCalculator == null)
            {
                return HttpNotFound();
            }
            return View(bmrCalculator);
        }

        // POST: BmrCalculators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BmrCalculator bmrCalculator = db.BmrCalculators.Find(id);
            db.BmrCalculators.Remove(bmrCalculator);
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
