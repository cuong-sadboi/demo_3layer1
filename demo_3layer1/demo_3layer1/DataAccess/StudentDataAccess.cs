using demo_3layer1.DataAccess;
using demo_3layer1.Models;
using System.Collections.Generic;
using System.Linq;

namespace demo_3layer1.DataAccess
{
    public class StudentDataAccess
    {
        public List<Student> GetAllStudents()
        {
            using (var context = new AppDbContext())
            {
                return context.Students.ToList();
            }
        }

        public void AddStudent(Student student)
        {
            using (var context = new AppDbContext())
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        public Student GetStudentById(int id)
        {
            using (var context = new AppDbContext())
            {
                return context.Students.Find(id);
            }
        }

        public void UpdateStudent(Student student)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.Students.Find(student.Id);
                if (existing != null)
                {
                    existing.Name = student.Name;
                    existing.ClassName = student.ClassName;
                    existing.Email = student.Email;
                    existing.UserId = student.UserId;
                    context.SaveChanges();
                }
            }
        }
        public Student GetByUserId(int userId)
        {
            using (var context = new AppDbContext())
                return context.Students.FirstOrDefault(s => s.UserId == userId);
        }
        public void DeleteStudent(int id)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.Students.Find(id);
                if (existing != null)
                {
                    context.Students.Remove(existing);
                    context.SaveChanges();
                }
            }
        }
    }
}
