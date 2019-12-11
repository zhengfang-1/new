using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseManager.Models;

namespace CourseManager.Controllers
{
    public class CourseManagermentController : Controller
    {
        private CourseManagerEntities1 db = new CourseManagerEntities1();

        //
        // GET: /CourseManagerment/

        public ActionResult Index()
        {
            return View(db.CourseManagements.ToList());
        }

        //
        // GET: /CourseManagerment/Details/5

        public ActionResult Details(int id = 0)
        {
            CourseManagements coursemanagements = db.CourseManagements.Find(id);
            if (coursemanagements == null)
            {
                return HttpNotFound();
            }
            return View(coursemanagements);
        }

        //
        // GET: /CourseManagerment/Create

        public ActionResult Create()
        {
            var classes = db.Classes.ToList();
            ViewBag.Classes = classes;

            var teachers = db.Teachers.ToList();
            ViewBag.Classes = teachers;

            var course = db.Course.ToList();
            ViewBag.Classes = course;
            return View();
        }

        //
        // POST: /CourseManagerment/Create

        [HttpPost]
        public ActionResult Create(CourseManagements coursemanagements)
        {
            if (ModelState.IsValid)
            {
                db.CourseManagements.Add(coursemanagements);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coursemanagements);
        }

        //
        // GET: /CourseManagerment/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CourseManagements coursemanagements = db.CourseManagements.Find(id);
            if (coursemanagements == null)
            {
                return HttpNotFound();
            }
            return View(coursemanagements);
        }

        //
        // POST: /CourseManagerment/Edit/5

        [HttpPost]
        public ActionResult Edit(CourseManagements coursemanagements)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coursemanagements).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coursemanagements);
        }

        //
        // GET: /CourseManagerment/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CourseManagements coursemanagements = db.CourseManagements.Find(id);
            if (coursemanagements == null)
            {
                return HttpNotFound();
            }
            return View(coursemanagements);
        }

        //
        // POST: /CourseManagerment/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseManagements coursemanagements = db.CourseManagements.Find(id);
            db.CourseManagements.Remove(coursemanagements);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}