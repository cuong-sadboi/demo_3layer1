using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo_3layer1.Models
{
    public class CourseRegistration
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public string Semester { get; set; }
        // Navigation properties
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}