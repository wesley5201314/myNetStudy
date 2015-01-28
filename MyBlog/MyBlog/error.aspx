<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="MyBlog.error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div align="center"><asp:Label ID="Label4" runat="server" Text="Label" ForeColor="#cc0000">出错啦</asp:Label><br /></div>
    <table border="1" align=center>
    <tr><td>
    <asp:Label ID="Label1" runat="server" Text="Label">错误原因1：你所访问的页面不存在.</asp:Label><br /></td></tr>
    <tr><td>
    <asp:Label ID="Label2" runat="server" Text="Label">错误原因2：你所提交的参数出错.</asp:Label><br /></td></tr>
    <tr><td>
    <asp:Label ID="Label3" runat="server" Text="Label">错误原因3：请注意不要进行非法破坏程序.</asp:Label><br /></td></tr></table>
    <div align="center"><a href="Default.aspx">点击返回</a></div>
    </div>
    </form>
</body>
</html>
