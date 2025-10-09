<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseRegistration.aspx.cs" Inherits="demo_3layer1.UI.Students.CourseRegistration" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng ký môn học</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">
            <h2 class="text-center mb-4">📝 Đăng ký môn học</h2>

            <asp:Label ID="lblMessage" runat="server" CssClass="d-block mb-3"></asp:Label>

            <div class="row mb-3">
                <div class="col-md-6">
                    <asp:DropDownList ID="ddlSubjects" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <asp:TextBox ID="txtSemester" runat="server" CssClass="form-control" placeholder="Học kỳ (vd: 2025A)"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Button ID="btnRegister" runat="server" Text="Đăng ký" CssClass="btn btn-primary w-100" OnClick="btnRegister_Click" />
                </div>
            </div>

            <h4 class="mt-4">Môn đã đăng ký</h4>
            <asp:GridView ID="gvRegistrations" runat="server" CssClass="table table-bordered mt-2" AutoGenerateColumns="false" DataKeyNames="Id" OnRowCommand="gvRegistrations_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Mã" />
                    <asp:BoundField DataField="Subject.Name" HeaderText="Môn học" />
                    <asp:BoundField DataField="Semester" HeaderText="Học kỳ" />
                    <asp:TemplateField HeaderText="Thao tác">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Text="Hủy" CommandName="DeleteRegistration" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Hủy đăng ký?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <div class="text-center mt-3">
                <asp:Button ID="btnBack" runat="server" Text="⬅️ Về trang Sinh viên" CssClass="btn btn-secondary" OnClick="btnBack_Click" />
            </div>
        </div>
    </form>
</body>
</html>
