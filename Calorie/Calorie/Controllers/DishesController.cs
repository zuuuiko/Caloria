using Calorie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calorie.Controllers
{
    public class DishesController : Controller
    {
        CalorieModel cm = new CalorieModel();
        // GET: Dishes
        public ActionResult Index()
        {
            IEnumerable<Dish> dishes = cm.Dishes;
            IEnumerable<Product> products = cm.Products;
            ViewBag.Dishes = dishes;
            ViewBag.Products = products;

            return View();
        }

        // GET: Dishes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dishes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dishes/Create
        [HttpPost]
        public ActionResult Create(Dish dish)
        {
            try
            {
                cm.Dishes.Add(dish);
                cm.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dishes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dishes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dishes/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.DishID = id;
            return View();
        }

        // POST: Dishes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                cm.Dishes.Remove(cm.Dishes.Find(id));
                cm.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            cm.Dispose();
            base.Dispose(disposing);
        }
    }
}
