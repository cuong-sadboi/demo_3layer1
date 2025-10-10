using demo_3layer1.Business;
using demo_3layer1.Models;
using System;
using System.Xml.Linq;

namespace demo_3layer1.UI.Subjects
{
    public partial class SubjectAdd : System.Web.UI.Page
    {
        private readonly SubjectBusiness _bus = new SubjectBusiness();

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
                // Tạo đối tượng Subject từ dữ liệu form
                var s = new Subject
                {
                    Name = txtName.Text.Trim(),
                    Credit = int.TryParse(txtCredit.Text.Trim(), out int c) ? c : -1
                };

                // Gọi Business xử lý và nhận thông báo phản hồi
                string message = _bus.AddSubject(s);

                // Hiển thị thông báo từ Business
                if (message.Contains("thành công"))
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "✅ " + message;

                    // Xóa form sau khi thêm
                    txtName.Text = txtCredit.Text = "";

                    // Sau 1s quay lại danh sách
                    Response.AddHeader("REFRESH", "1;URL=SubjectList.aspx");
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "⚠️ " + message;
                }
         
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubjectList.aspx");
        }
    }
}
