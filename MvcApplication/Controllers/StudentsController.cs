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
    public class StudentsController : Controller
    {
        private MvcApplicationContext context = new MvcApplicationContext();

        //
        // GET: /Students/

        public ViewResult Index()
        {
            return View(context.Students.Include(student => student.Course).ToList());
        }

        //
        // GET: /Students/Details/5

        public ViewResult Details(int id)
        {
            Student student = context.Students.Single(x => x.StudentId == id);
            return View(student);
        }

        //
        // GET: /Students/Create

        public ActionResult Create()
        {
            ViewBag.PossibleCourses = context.Courses;
            return View();
        } 

        //
        // POST: /Students/Create

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                context.Students.Add(student);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleCourses = context.Courses;
            return View(student);
        }
        
        //
        // GET: /Students/Edit/5
 
        public ActionResult Edit(int id)
        {
            Student student = context.Students.Single(x => x.StudentId == id);
            ViewBag.PossibleCourses = context.Courses;
            return View(student);
        }

        //
        // POST: /Students/Edit/5

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                context.Entry(student).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleCourses = context.Courses;
            return View(student);
        }

        //
        // GET: /Students/Delete/5
 
        public ActionResult Delete(int id)
        {
            Student student = context.Students.Single(x => x.StudentId == id);
            return View(student);
        }

        //
        // POST: /Students/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = context.Students.Single(x => x.StudentId == id);
            context.Students.Remove(student);
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