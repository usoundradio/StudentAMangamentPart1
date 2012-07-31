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
    public class CoursesController : Controller
    {
        private MvcApplicationContext context = new MvcApplicationContext();

        //
        // GET: /Courses/

        public ViewResult Index()
        {
            return View(context.Courses.Include(course => course.Students).Include(course => course.Lectures).ToList());
        }

        //
        // GET: /Courses/Details/5

        public ViewResult Details(int id)
        {
            Course course = context.Courses.Single(x => x.CourseId == id);
            return View(course);
        }

        //
        // GET: /Courses/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Courses/Create

        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                context.Courses.Add(course);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(course);
        }
        
        //
        // GET: /Courses/Edit/5
 
        public ActionResult Edit(int id)
        {
            Course course = context.Courses.Single(x => x.CourseId == id);
            return View(course);
        }

        //
        // POST: /Courses/Edit/5

        [HttpPost]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                context.Entry(course).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        //
        // GET: /Courses/Delete/5
 
        public ActionResult Delete(int id)
        {
            Course course = context.Courses.Single(x => x.CourseId == id);
            return View(course);
        }

        //
        // POST: /Courses/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = context.Courses.Single(x => x.CourseId == id);
            context.Courses.Remove(course);
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