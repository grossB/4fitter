using _4fitter.Models;
using _4fitter.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using _4fitter.Enums;

namespace _4fitter.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles = Definitions.ROLE_ADMIN)]
        public ActionResult AdminPanel()
        {
            return View();
        }

        public ActionResult TabataTimer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchPhrase)
        {
            var result = new List<Article>();

            var splittedPhrase = searchPhrase.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var phrase in splittedPhrase)
            {
                var articles = db.Articles.ToList();

                foreach (var article in articles)
                {
                    var phraseProcessed = phrase.RemovePolishLetters();

                    var isMatch = article.Tags.Any(tag => tag.Name.RemovePolishLetters() == phraseProcessed) 
                                  || article.Title.RemovePolishLetters().Contains(phraseProcessed);

                    if (isMatch && !result.Contains(article))
                    {
                        result.Add(article);
                    }
                }
            }

            return View(result);
        }
    }
}