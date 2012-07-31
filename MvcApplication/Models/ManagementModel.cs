using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Lecture> Lectures { get; set; } 
    }

    public class Lecture
    {
        public int LectureId { get; set; }
        public string Name { get; set; }
        
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }

    public class Student
    {

        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}