using demo_3layer1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using demo_3layer1.DataAccess;

namespace demo_3layer1.Business
{
    public class StudentBusiness
    {
        private readonly StudentDataAccess _data = new StudentDataAccess();

        // Lấy tất cả sinh viên
        public List<Student> GetAllStudents()
        {
            return _data.GetAllStudents();
        }

        // Lấy sinh viên theo ID
        public Student GetStudentById(int id)
        {
            return _data.GetStudentById(id);
        }

        // Thêm sinh viên – có kiểm tra logic nghiệp vụ
        public string AddStudent(Student s)
        {

            if (string.IsNullOrWhiteSpace(s.Name) && string.IsNullOrWhiteSpace(s.ClassName) && string.IsNullOrWhiteSpace(s.Email))
            {
                return "Vui lòng nhập dữ liệu.";
            }
            // Kiểm tra dữ liệu
            if (string.IsNullOrWhiteSpace(s.Name))
                return "Tên sinh viên không được để trống.";

            if (string.IsNullOrWhiteSpace(s.Email))
                return "Email không được để trống.";

            if (!IsValidEmail(s.Email))
                return "Định dạng email không hợp lệ.";

            // Kiểm tra trùng email (nếu có)

            var existing = _data.GetAllStudents()
             .FirstOrDefault(x => x.Email.Equals(s.Email, StringComparison.OrdinalIgnoreCase));
            if (existing != null)
                return "Email này đã được sử dụng.";

            // Hợp lệ → thêm mới
            _data.AddStudent(s);
            return "Thêm sinh viên thành công!";
        }

        // Cập nhật sinh viên – có kiểm tra logic
        public string UpdateStudent(Student s)
        {
            if (string.IsNullOrWhiteSpace(s.Name) && string.IsNullOrWhiteSpace(s.ClassName) && string.IsNullOrWhiteSpace(s.Email))
            {
                return "Vui lòng không để trống dữ liệu.";
            }
            if (string.IsNullOrWhiteSpace(s.Name))
                return "Tên sinh viên không được để trống.";

            if (string.IsNullOrWhiteSpace(s.Email))
                return "Email không được để trống.";

            if (!IsValidEmail(s.Email))
                return "Định dạng email không hợp lệ.";

            _data.UpdateStudent(s);
            return "Cập nhật thông tin sinh viên thành công!";
        }

        // Xóa sinh viên
        public string DeleteStudent(int id)
        {
            var existing = _data.GetStudentById(id);
            if (existing == null)
                return "Không tìm thấy sinh viên cần xóa.";

            _data.DeleteStudent(id);
            return "Đã xóa sinh viên thành công.";
        }

        // Hàm kiểm tra định dạng email
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}
