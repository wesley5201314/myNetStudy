<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_main.aspx.cs" Inherits="MyBlog.admin.admin_main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label4" runat="server" Text="Label" Font-Names="宋体" Font-Size="12px">当前位置:后台首页</asp:Label><br />
        <hr /><br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Label">关于程序：</asp:Label><br /><br />
        <asp:Label ID="Label3" runat="server" Text="Label">
        《个人博客系统1.0》<br />这个是我个人用.net做的第1个整站程序，还有很多的不足与缺陷，希望大家能
        多给我些宝贵意见！</asp:Label>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Label">关于作者：</asp:Label><br /><br />
        
        <asp:Label ID="Label1" runat="server" Text="Label">南阳理工学院软件学院大四在校生。姓名：郑伟山 QQ：893189117</asp:Label><br /><br />
        
        <asp:Label ID="Label2" runat="server" Text="Label">主要独立开发项目(网站版)13年上：<a href="#">南阳理工学院软件学院操行分系统</a></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Label">主要独立开发项目(网站版)13年下：<a href="#">软件学院党支部网站</a></asp:Label>
        <br />
        <br />
       <asp:Label ID="Label8" runat="server" Text="Label">主要独立开发项目(网站版)14年上：<a href="#">某工作室整站</a></asp:Label>
       <br />
        <br />
       <asp:Label ID="Label9" runat="server" Text="Label">目前正在开发乐鱼交友网站：详情关注。。。。</asp:Label>
    </div>
    </form>
</body>
</html>