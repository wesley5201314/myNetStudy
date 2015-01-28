<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_type_edit.aspx.cs" Inherits="MyBlog.admin.edit.edit_type_edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label4" runat="server" Text="Label" Font-Names="宋体" Font-Size="12px">当前位置:分类修改</asp:Label><br />
        <hr /><br />
        <asp:TextBox ID="TextBox1" runat="server" Font-Names="宋体" Font-Size="12px"></asp:TextBox>
        &nbsp;
        <asp:Button ID="Button1"
            runat="server" Text="修改" Font-Names="宋体" Font-Size="12px" OnClick="Button1_Click"/>
    </div>
    </form>
</body>
</html>
