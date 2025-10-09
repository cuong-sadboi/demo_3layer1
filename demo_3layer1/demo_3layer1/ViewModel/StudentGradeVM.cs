using demo_3layer1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo_3layer1.ViewModel
{
    public class StudentGradeVM
    {
        public Student Student { get; set; }
        public Subject Subject { get; set; } // null nếu chưa có grade
        public double? Score { get; set; }   // null nếu chưa có grade
    }
}