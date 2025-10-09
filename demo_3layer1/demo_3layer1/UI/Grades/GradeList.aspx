<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GradeList.aspx.cs" Inherits="demo_3layer1.Grades.GradeList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý điểm sinh viên</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script>
        function hideMessage() {
            var lbl = document.getElementById('<%= lblMessage.ClientID %>');
            if (lbl) setTimeout(function () { lbl.innerHTML = ''; }, 1000);
        }
    </script>
</head>
<body onload="hideMessage()">
    <form id="form1" runat="server">
        <div class="container mt-4">
            <h2 class="text-center mb-4 text-primary fw-bold">📊 Quản lý điểm sinh viên</h2>

            <div class="text-center mb-3">
                <asp:Button ID="btnAddGrade" runat="server" Text="➕ Nhập điểm mới" CssClass="btn btn-success" OnClick="btnAddGrade_Click" />
            </div>

            <asp:Label ID="lblMessage" runat="server" CssClass="text-center d-block mb-3"></asp:Label>

            <asp:GridView ID="gvGrades" runat="server" CssClass="table table-bordered table-hover text-center"
                AutoGenerateColumns="False" DataKeyNames="StudentId,SubjectId"
                OnRowEditing="gvGrades_RowEditing" OnRowUpdating="gvGrades_RowUpdating" OnRowDeleting="gvGrades_RowDeleting"
                EmptyDataText="Chưa có điểm sinh viên nào.">
                <Columns>
                    <asp:BoundField DataField="Student.Name" HeaderText="Sinh viên" ReadOnly="true"/>
                    <asp:BoundField DataField="Subject.Name" HeaderText="Môn học" ReadOnly="true"/>
                    <asp:BoundField DataField="Score" HeaderText="Điểm" />

                    <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" ButtonType="Button" />
                </Columns>
            </asp:GridView>
                <div class="text-center mt-4">
        <asp:Button ID="btnBack" runat="server" Text="⬅️ Quay lại trang Admin" CssClass="btn btn-secondary fw-semibold px-4" OnClick="btnBack_Click" />
    </div>
        </div>
    </form>
</body>
</html>
