<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="MyBlog.admin.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body bgcolor="#16508b">
    <form id="form1" runat="server">
        <div>
            <table border="0" align="center" cellpadding="0" cellspacing="1" background="images/lg2_bg.gif" style="width: 298px; height: 225px">
                <tr width="300">
                    <td align="center" height="28" colspan="2"><font color="#42AAF7"><b>管理员登录</b></font></td>
                </tr>
                <tr width="300">
                    <td align="center" height="28" colspan="2"></td>
                </tr>
                <tr width="300">
                    <td width="100" align="right" height="28">管理员：</td>
                    <td width="200">
                        <input type="text" id="name" runat="server" /></td>
                </tr>
                <tr width="300">
                    <td align="right" height="28">密　码：</td>
                    <td>
                        <input type="password" id="password" runat="server" style="width: 147px" /></td>
                </tr>
                <tr width="300">
                    <td colspan="2" align="center">
                        <asp:Button ID="Button1" runat="server" Text="登陆" OnClick="Button1_Click" />
                        &nbsp;
                <asp:Button ID="Button2" runat="server" Text="重置" OnClick="Button2_Click" /></td>
                </tr>
                <tr width="300">
                    <td colspan="2" align="center" height="28"></td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
