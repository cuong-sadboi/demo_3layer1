using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo_3layer1.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
        // "Admin", "Teacher", "Student"
    }
}