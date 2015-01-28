<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="guest.aspx.cs" Inherits="MyBlog.guest" %>

<%@ Register TagPrefix="time" TagName="time_show" Src="~/ascx/time.ascx" %>
<%@ Register TagPrefix="page" TagName="edit_type" Src="~/ascx/edit_type.ascx" %>
<%@ Register TagPrefix="page" TagName="photo_type" Src="~/ascx/photo_type.ascx" %>
<%@ Register TagPrefix="page" TagName="footer" Src="~/ascx/footer.ascx" %>
<%@ Register TagPrefix="count" TagName="countall" Src="~/ascx/count.ascx" %>
<%@ Register TagPrefix="page" TagName="post" Src="~/ascx/guest_post.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><%= title %></title>
    <link rel="stylesheet" type="text/css" href="css/style.css" title="demo" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="container">
                <div id="header">
                    <h1><%= title %></h1>
                </div>
                <div id="navcontainer">
                    <ul id="navlist">
                        <li><a href="index.aspx">首页</a></li>
                        <li>
                            <asp:HyperLink ID="HyperLink1" runat="server">日志</asp:HyperLink></li>
                        <li>
                            <asp:HyperLink ID="HyperLink2" runat="server">相册</asp:HyperLink></li>
                        <li><a href="sc.aspx">收藏</a></li>
                        <li><a href="guest.aspx">留言</a></li>
                        <li><a href="about.aspx">关于</a></li>
                    </ul>
                </div>
                <div id="subheader"></div>


                <div id="right">
                    <div id="Div1">
                        <time:time_show runat="server" ID="time_show" />
                        <page:edit_type runat="server" ID="edit_type" />
                        <page:photo_type runat="server" ID="photo_type" />
                    </div>
                </div>
                <page:post ID="post" runat="server" />
                <page:footer ID="footer" runat="server" />
                <count:countall ID="countall" runat="server" />
            </div>
    </form>
</body>
</html>

