using demo_3layer1.DataAccess;
using demo_3layer1.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebFormsApp.DataAccess
{
    public class StudentDataAccess
    {
        private readonly AppDbContext _context;

        public StudentDataAccess()
        {
            _context = new AppDbContext();
        }

        // Lấy danh sách sinh viên
        public List<Student> GetAllStudents()
        {
            using (var context = new AppDbContext())
            {
                return context.Students.ToList();
            }
        }

        // Thêm sinh viên
        public void AddStudent(Student s)
        {
            using (var context = new AppDbContext())
            {
                _context.Students.Add(s);
                _context.SaveChanges();
            }
         
        }

        // Lấy sinh viên theo ID
        public Student GetStudentById(int id)
        {
            using (var context = new AppDbContext())
            {
                return _context.Students.Find(id);
            }
           
        }

        // Cập nhật sinh viên
        public void UpdateStudent(Student s)
        {
            using (var context = new AppDbContext())
            {
                var existing = _context.Students.Find(s.Id);
                if (existing != null)
                {
                    existing.Name = s.Name;
                    existing.ClassName = s.ClassName;
                    existing.Email = s.Email;
                    _context.SaveChanges();
                }
            }
        }

        // Xóa sinh viên
        public void DeleteStudent(int id)
        {
            using (var context = new AppDbContext())
            {
                var existing = context.Students.Find(id);
                if (existing == null)
                context.Students.Remove(existing);
                context.SaveChanges();
            }

           
        }
    }
}
