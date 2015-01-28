<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="guest_add.aspx.cs" Inherits="MyBlog.guest_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;
        </div>
        <table border="1" bordercolor="#16508b" width="520px">
            <tr>
                <td width="50">姓名:
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                <td width="50">QQ:
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        <table border="1" bordercolor="#16508b" width="520px">
            <tr>
                <td width="50">内容:</td>
                <td width="450">
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Height="146px" Width="443px"></asp:TextBox></td>
            </tr>
        </table>
        <asp:Button ID="Button1" runat="server" Text="确定" />
        <asp:Button ID="Button2" runat="server" Text="关闭" />
    </form>

</body>
</html>
