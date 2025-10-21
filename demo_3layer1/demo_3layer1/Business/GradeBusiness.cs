using demo_3layer1.DataAccess;
using demo_3layer1.Models;
using demo_3layer1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;


namespace demo_3layer1.Business
{
    public class GradeBusiness
    {
        private readonly GradeDataAccess _data = new GradeDataAccess();
        private readonly StudentDataAccess _studentData = new StudentDataAccess();
        private readonly SubjectDataAccess _subjectData = new SubjectDataAccess();

        // Lấy tất cả grade
        public List<Grade> GetAllGrades()
        {
            return _data.GetAllGrades();
        }
        public List<Grade> GetGradesOfStudent(int studentId)
        {
            return _data.GetGradesByStudent(studentId);
        }

        // Lấy tất cả sinh viên kèm điểm (left join)
        public List<StudentGradeVM> GetStudentsWithGrades()
        {
            var students = _studentData.GetAllStudents();
            var grades = _data.GetAllGrades();

            var list = from s in students
                       join g in grades on s.Id equals g.StudentId into sg
                       from g in sg.DefaultIfEmpty()
                       select new StudentGradeVM
                       {
                           Student = s,
                           Subject = g?.Subject,
                           Score = g?.Score
                       };

            return list.ToList();
        }

        // Lưu điểm (thêm mới hoặc cập nhật)
        public string SaveGrade(int studentId, int subjectId, double score)
        {
            if (score < 0 || score > 10)
                return "Điểm phải từ 0 đến 10.";

            try
            {
                var grade = new Grade
                {
                    StudentId = studentId,
                    SubjectId = subjectId,
                    Score = score
                };

                _data.AddOrUpdateGrade(grade);
                return "Lưu điểm thành công!";
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        // Xóa điểm
        public string DeleteGrade(int studentId, int subjectId)
        {
            var grade = _data.GetGrade(studentId, subjectId);
            if (grade == null)
                return "Không tìm thấy điểm cần xóa.";

            _data.DeleteGrade(studentId, subjectId);
            return "Đã xóa điểm thành công!";
        }

        // Tìm kiếm điểm theo từ khóa và trường
        public List<Grade> SearchGrades(string keyword, string field)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return GetAllGrades();
            }

            keyword = keyword.Trim();
            field = string.IsNullOrWhiteSpace(field) ? "all" : field.Trim().ToLowerInvariant();

            switch (field)
            {
                case "student":
                    return _data.SearchGradesByStudentName(keyword);
                case "subject":
                    return _data.SearchGradesBySubjectName(keyword);
                case "score":
                    return _data.SearchGradesByScore(keyword);
                default:
                    return _data.SearchGrades(keyword);
            }
        }
    }
}
