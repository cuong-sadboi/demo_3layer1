using demo_3layer1.Models;
using System.Collections.Generic;
using System.Linq;

namespace demo_3layer1.DataAccess
{
    public class SubjectDataAccess
    {
        private readonly AppDbContext _context;

        public SubjectDataAccess()
        {
            _context = new AppDbContext();
        }

        // Lấy tất cả môn học
        public List<Subject> GetAllSubjects()
        {
            return _context.Subjects.ToList();
        }

        // Lấy môn học theo ID
        public Subject GetSubjectById(int id)
        {
            return _context.Subjects.Find(id);
        }

        // Thêm môn học mới
        public void AddSubject(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }

        // Cập nhật môn học
        public void UpdateSubject(Subject subject)
        {
            var existing = _context.Subjects.Find(subject.Id);
            if (existing != null)
            {
                existing.Name = subject.Name;
                existing.Credit = subject.Credit;
                _context.SaveChanges();
            }
        }

        // Xóa môn học
        public void DeleteSubject(int id)
        {
            var subject = _context.Subjects.Find(id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                _context.SaveChanges();
            }
        }
    }
}
