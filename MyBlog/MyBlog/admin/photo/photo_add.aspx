<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="photo_add.aspx.cs" Inherits="MyBlog.admin.photo.photo_add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label2" runat="server" Text="图片分类:"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList><br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="图片标题:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="图片上传:"></asp:Label>
        <asp:FileUpload ID="FileUpload1" runat="server" /><br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="图片描述:"></asp:Label><br />
        <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Height="223px" Width="437px"></asp:TextBox><br />
        <br />
        &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />

    </div>
    </form>
</body>
</html>
