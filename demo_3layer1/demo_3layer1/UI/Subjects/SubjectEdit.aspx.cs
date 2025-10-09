using demo_3layer1.Business;
using demo_3layer1.Models;
using System;
using System.Xml.Linq;

namespace demo_3layer1.UI
{
    public partial class SubjectEdit : System.Web.UI.Page
    {
        private readonly SubjectBusiness _bus = new SubjectBusiness();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int id;
                    if (int.TryParse(Request.QueryString["id"], out id))
                        LoadSubject(id);
                    else
                        Response.Redirect("SubjectList.aspx");
                }
                else
                {
                    Response.Redirect("SubjectList.aspx");
                }
            }
        }

        private void LoadSubject(int id)
        {
            var subject = _bus.GetSubjectById(id);
            if (subject != null)
            {
                hfId.Value = subject.Id.ToString();
                txtName.Text = subject.Name;
                txtCredit.Text = subject.Credit.ToString();
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "❌ Không tìm thấy môn học cần sửa.";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
           

                // Lấy dữ liệu từ form
                var subject = new Subject
                {
                    Id = int.Parse(hfId.Value),
                    Name = txtName.Text.Trim(),
                    Credit = int.TryParse(txtCredit.Text.Trim(), out int credit) ? credit : 0
                };

                // Gọi Business xử lý
                string message = _bus.UpdateSubject(subject);

                // Xử lý phản hồi từ Business
                if (message.Contains("thành công"))
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "✅ " + message;
                    // Quay lại trang danh sách sau 1s
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
