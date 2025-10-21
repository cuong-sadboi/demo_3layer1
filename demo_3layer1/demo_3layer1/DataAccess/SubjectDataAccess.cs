using demo_3layer1.Models;
using System;
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
                bool hasRegistrations = _context.CourseRegistrations.Any(c => c.SubjectId == id);
                bool hasGrades = _context.Grades.Any(g => g.SubjectId == id);

                if (hasRegistrations || hasGrades)
                {
                    throw new InvalidOperationException("Không thể xóa môn học vì đang có sinh viên đăng ký hoặc đã có điểm.");
                }

                _context.Subjects.Remove(subject);
                _context.SaveChanges();
            }
        }

        // Tìm kiếm môn học theo từ khóa (theo tên; rỗng => trả tất cả)
        public List<Subject> SearchSubjects(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return GetAllSubjects();
            }

            string trimmed = keyword.Trim();
            return _context.Subjects
                .Where(s => s.Name.Contains(trimmed))
                .ToList();
        }
    }
}
