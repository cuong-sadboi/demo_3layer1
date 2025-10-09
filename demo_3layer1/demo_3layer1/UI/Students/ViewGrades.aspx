<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewGrades.aspx.cs" Inherits="demo_3layer1.UI.Students.ViewGrades" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Xem điểm</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
<form id="form1" runat="server">
    <div class="container mt-4">
        <h2 class="text-center mb-4">📄 Kết quả học tập</h2>

        <asp:GridView ID="gvGrades" runat="server" CssClass="table table-bordered text-center" AutoGenerateColumns="false" EmptyDataText="Chưa có điểm.">
            <Columns>
                <asp:BoundField DataField="Subject.Name" HeaderText="Môn học" />
                <asp:BoundField DataField="Score" HeaderText="Điểm" />
            </Columns>
        </asp:GridView>

        <div class="text-center mt-3">
            <asp:Button ID="btnBack" runat="server" Text="⬅️ Về trang Sinh viên" CssClass="btn btn-secondary" OnClick="btnBack_Click" />
        </div>
    </div>
</form>
</body>
</html>
