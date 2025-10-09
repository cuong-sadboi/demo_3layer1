using demo_3layer1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace demo_3layer1.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("MyDB") { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CourseRegistration> CourseRegistrations { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Không cần cấu hình phức tạp — EF6 sẽ tự nhận

        }   
    }
}