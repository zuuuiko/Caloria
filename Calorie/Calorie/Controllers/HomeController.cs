using Calorie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calorie.Controllers
{
    public class HomeController : Controller
    {
        CalorieModel cm = new CalorieModel();
        public ActionResult Index()
        {
            IEnumerable<Person> persons = cm.Persons;
            ViewBag.Person = persons.First<Person>();

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            cm.Dispose();
            base.Dispose(disposing);
        }
    }
}