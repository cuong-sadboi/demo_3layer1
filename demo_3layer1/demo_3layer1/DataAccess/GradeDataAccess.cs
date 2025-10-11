using demo_3layer1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace demo_3layer1.DataAccess
{
    public class GradeDataAccess
    {
        private readonly AppDbContext _context;

        public GradeDataAccess()
        {
            _context = new AppDbContext();
        }

        // Lấy tất cả điểm + include Student & Subject
        public List<Grade> GetAllGrades()
        {
            return _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .OrderBy(g => g.StudentId)
                .ThenBy(g => g.SubjectId)
                .ToList();
        }

        // Lấy grade theo StudentId + SubjectId
        public Grade GetGrade(int studentId, int subjectId)
        {
            return _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .FirstOrDefault(g => g.StudentId == studentId && g.SubjectId == subjectId);
        }

        // Thêm điểm
        public void AddGrade(Grade grade)
        {
            _context.Grades.Add(grade);
            _context.SaveChanges();
        }

        // Cập nhật điểm
        public void UpdateGrade(Grade grade)
        {
            var existing = GetGrade(grade.StudentId, grade.SubjectId);
            if (existing != null)
            {
                existing.Score = grade.Score;
                _context.SaveChanges();
            }
        }

        // Thêm hoặc cập nhật điểm
        public void AddOrUpdateGrade(Grade grade)
        {
            var existing = GetGrade(grade.StudentId, grade.SubjectId);
            if (existing != null)
                existing.Score = grade.Score;
            else
                _context.Grades.Add(grade);
            _context.SaveChanges();
        }
        public void DeleteGrade(int studentId, int subjectId)
        {
            var existing = GetGrade(studentId, subjectId);
            if (existing != null)
            {
                _context.Grades.Remove(existing);
                _context.SaveChanges();
            }
        }
    public List<Grade> GetGradesByStudent(int studentId)
        {
            return _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .Where(g => g.StudentId == studentId)
                .OrderBy(g => g.SubjectId)
                .ToList();
        }
    }
}