using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo_3layer1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public string Email { get; set; }
        public int? UserId { get; set; }
    }
}