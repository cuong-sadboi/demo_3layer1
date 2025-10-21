using System;
using System.Collections.Generic;
using demo_3layer1.Models;
using demo_3layer1.DataAccess;

namespace demo_3layer1.Business
{
    public class SubjectBusiness
    {
        private readonly SubjectDataAccess _dataAccess;

        public SubjectBusiness()
        {
            _dataAccess = new SubjectDataAccess();
        }

        // Lấy danh sách tất cả môn học
        public List<Subject> GetAllSubjects()
        {
            return _dataAccess.GetAllSubjects();
        }

        // Lấy môn học theo ID
        public Subject GetSubjectById(int id)
        {
            return _dataAccess.GetSubjectById(id);
        }

        // Thêm môn học — có kiểm tra logic nghiệp vụ
        public string AddSubject(Subject s)
        {
            if (string.IsNullOrWhiteSpace(s.Name) && s.Credit <= 0)
            {
                return "Vui lòng nhập dữ liệu.";
            }
            // Kiểm tra tên môn học
            if (string.IsNullOrWhiteSpace(s.Name))
                return "Tên môn học không được để trống.";

            // Kiểm tra số tín chỉ
            if (s.Credit <= 0)
                return "Số tín chỉ phải lớn hơn 0.";

            // Kiểm tra trùng tên môn học
            var existing = _dataAccess.GetAllSubjects().Find(x =>
                x.Name.Equals(s.Name, StringComparison.OrdinalIgnoreCase));

            if (existing != null)
                return "Môn học này đã tồn tại.";

            // Hợp lệ → thêm vào CSDL
            _dataAccess.AddSubject(s);
            return "Thêm môn học thành công!";
        }

        // Cập nhật môn học — có kiểm tra logic
        public string UpdateSubject(Subject s)
        {
            if (string.IsNullOrWhiteSpace(s.Name) && s.Credit <= 0)
            {
                return "Vui lòng không để trống dữ liệu.";
            }
            if (string.IsNullOrWhiteSpace(s.Name))
                return "Tên môn học không được để trống.";

            if (s.Credit <= 0)
                return "Số tín chỉ phải lớn hơn 0.";

            var existing = _dataAccess.GetSubjectById(s.Id);
            if (existing == null)
                return "Không tìm thấy môn học cần cập nhật.";

            _dataAccess.UpdateSubject(s);   
            return "Cập nhật môn học thành công!";
        }

        // Xóa môn học — có kiểm tra tồn tại
        public string DeleteSubject(int id)
        {
            var existing = _dataAccess.GetSubjectById(id);
            if (existing == null)
                return "Không tìm thấy môn học cần xóa.";

            try
            {
                _dataAccess.DeleteSubject(id);
                return "Đã xóa môn học thành công.";
            }
            catch (InvalidOperationException ex)
            {
                // thông điệp nghiệp vụ từ DAL (đang có đăng ký / điểm)
                return ex.Message; // "Không thể xóa môn học vì đang có sinh viên đăng ký hoặc đã có điểm."
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        // Tìm kiếm môn học theo từ khóa (theo tên; rỗng => tất cả)
        public List<Subject> SearchSubjects(string keyword)
        {
            return _dataAccess.SearchSubjects(keyword);
        }
    }
}
