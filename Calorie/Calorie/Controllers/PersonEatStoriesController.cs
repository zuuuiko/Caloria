using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Calorie.Models;

namespace Calorie.Controllers
{
    public class PersonEatStoriesController : Controller
    {
        private CalorieModel db = new CalorieModel();

        // GET: PersonEatStories
        public ActionResult Index()
        {
            var personEatStories = db.PersonEatStories.Include(p => p.Dish).Include(p => p.Person);
            return View(personEatStories.ToList());
        }

        // GET: PersonEatStories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonEatStory personEatStory = db.PersonEatStories.Find(id);
            if (personEatStory == null)
            {
                return HttpNotFound();
            }
            return View(personEatStory);
        }

        // GET: PersonEatStories/Create
        public ActionResult Create()
        {
            ViewBag.DishID = new SelectList(db.Dishes, "DishID", "DishName");
            ViewBag.PersonID = new SelectList(db.Persons, "PersonID", "PersonName");
            return View();
        }

        // POST: PersonEatStories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StoryID,PersonID,DishID,DishWeight,Date")] PersonEatStory personEatStory)
        {
            if (ModelState.IsValid)
            {
                db.PersonEatStories.Add(personEatStory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DishID = new SelectList(db.Dishes, "DishID", "DishName", personEatStory.DishID);
            ViewBag.PersonID = new SelectList(db.Persons, "PersonID", "PersonName", personEatStory.PersonID);
            return View(personEatStory);
        }

        // GET: PersonEatStories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonEatStory personEatStory = db.PersonEatStories.Find(id);
            if (personEatStory == null)
            {
                return HttpNotFound();
            }
            ViewBag.DishID = new SelectList(db.Dishes, "DishID", "DishName", personEatStory.DishID);
            ViewBag.PersonID = new SelectList(db.Persons, "PersonID", "PersonName", personEatStory.PersonID);
            return View(personEatStory);
        }

        // POST: PersonEatStories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StoryID,PersonID,DishID,DishWeight,Date")] PersonEatStory personEatStory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personEatStory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DishID = new SelectList(db.Dishes, "DishID", "DishName", personEatStory.DishID);
            ViewBag.PersonID = new SelectList(db.Persons, "PersonID", "PersonName", personEatStory.PersonID);
            return View(personEatStory);
        }

        // GET: PersonEatStories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonEatStory personEatStory = db.PersonEatStories.Find(id);
            if (personEatStory == null)
            {
                return HttpNotFound();
            }
            return View(personEatStory);
        }

        // POST: PersonEatStories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonEatStory personEatStory = db.PersonEatStories.Find(id);
            db.PersonEatStories.Remove(personEatStory);
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
