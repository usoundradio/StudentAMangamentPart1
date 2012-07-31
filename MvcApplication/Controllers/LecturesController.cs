using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Models;

namespace MvcApplication.Controllers
{   
    public class LecturesController : Controller
    {
        private MvcApplicationContext context = new MvcApplicationContext();

        //
        // GET: /Lectures/

        public ViewResult Index()
        {
            return View(context.Lectures.Include(lecture => lecture.Course).ToList());
        }

        //
        // GET: /Lectures/Details/5

        public ViewResult Details(int id)
        {
            Lecture lecture = context.Lectures.Single(x => x.LectureId == id);
            return View(lecture);
        }

        //
        // GET: /Lectures/Create

        public ActionResult Create()
        {
            ViewBag.PossibleCourses = context.Courses;
            return View();
        } 

        //
        // POST: /Lectures/Create

        [HttpPost]
        public ActionResult Create(Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                context.Lectures.Add(lecture);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleCourses = context.Courses;
            return View(lecture);
        }
        
        //
        // GET: /Lectures/Edit/5
 
        public ActionResult Edit(int id)
        {
            Lecture lecture = context.Lectures.Single(x => x.LectureId == id);
            ViewBag.PossibleCourses = context.Courses;
            return View(lecture);
        }

        //
        // POST: /Lectures/Edit/5

        [HttpPost]
        public ActionResult Edit(Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                context.Entry(lecture).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleCourses = context.Courses;
            return View(lecture);
        }

        //
        // GET: /Lectures/Delete/5
 
        public ActionResult Delete(int id)
        {
            Lecture lecture = context.Lectures.Single(x => x.LectureId == id);
            return View(lecture);
        }

        //
        // POST: /Lectures/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Lecture lecture = context.Lectures.Single(x => x.LectureId == id);
            context.Lectures.Remove(lecture);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}