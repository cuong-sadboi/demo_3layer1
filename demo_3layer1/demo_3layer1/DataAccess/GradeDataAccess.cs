using demo_3layer1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

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

        // ====== Search helpers ======
        public List<Grade> SearchGrades(string keyword)
        {
            string lower = keyword.ToLower();
            return _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .Where(g => g.Student.Name.ToLower().Contains(lower)
                         || g.Subject.Name.ToLower().Contains(lower)
                         || ("" + g.Score).Contains(keyword))
                .OrderBy(g => g.StudentId)
                .ThenBy(g => g.SubjectId)
                .ToList();
        }

        public List<Grade> SearchGradesByStudentName(string keyword)
        {
            string lower = keyword.ToLower();
            return _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .Where(g => g.Student.Name.ToLower().Contains(lower))
                .OrderBy(g => g.StudentId)
                .ThenBy(g => g.SubjectId)
                .ToList();
        }

        public List<Grade> SearchGradesBySubjectName(string keyword)
        {
            string lower = keyword.ToLower();
            return _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .Where(g => g.Subject.Name.ToLower().Contains(lower))
                .OrderBy(g => g.StudentId)
                .ThenBy(g => g.SubjectId)
                .ToList();
        }

        public List<Grade> SearchGradesByScore(string keyword)
        {
            // allow decimal variants: 7,5 or 7.5
            string normalized = keyword.Replace(',', '.');

            double score;
            bool isNumeric = double.TryParse(normalized, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out score);

            var query = _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .AsQueryable();

            if (isNumeric)
            {
                // exact match if numeric parsed
                query = query.Where(g => g.Score == score);
            }
            else
            {
                // fallback contains on string representation
                query = query.Where(g => SqlFunctions.StringConvert((double?)g.Score).Contains(keyword));
            }

            return query
                .OrderBy(g => g.StudentId)
                .ThenBy(g => g.SubjectId)
                .ToList();
        }
    }
}