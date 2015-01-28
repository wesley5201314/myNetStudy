<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_edit.aspx.cs" Inherits="MyBlog.admin.admin_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label4" runat="server" Text="Label" Font-Names="宋体" Font-Size="12px">当前位置:后台管理（设置后台登陆管理账号密码）</asp:Label><br />
            <hr />
            <br />
            <asp:Label ID="Label1" runat="server" Text="管理帐号：" Font-Names="宋体" Font-Size="12px"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" Font-Names="宋体" Font-Size="12px" Width="120px"></asp:TextBox><br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="管理密码：" Font-Names="宋体" Font-Size="12px"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Font-Names="宋体" Font-Size="12px" Width="122px" TextMode="Password"></asp:TextBox><br />
            <asp:Label ID="Label2" runat="server" Text="确认密码：" Font-Names="宋体" Font-Size="12px"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" Font-Names="宋体" Font-Size="12px" Width="122px" TextMode="Password"></asp:TextBox><br />
            <br />

            <asp:Button ID="Button1" runat="server" Text="添加" Font-Size="12px" Font-Names="宋体" OnClick="Button1_Click1" />
        </div>
    </form>
</body>
</html>
