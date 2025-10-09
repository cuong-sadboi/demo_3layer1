using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo_3layer1.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public double Score { get; set; }
        // Navigation properties
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}