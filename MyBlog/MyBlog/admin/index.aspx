<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MyBlog.admin.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>

<frameset rows="*" cols="181,*" framespacing="0" frameborder="1" border="false" id="frame" scrolling="yes">
  <frame src="admin_left.aspx" name="left" scrolling="auto" noresize marginheight="0">
  <frameset framespacing="0" border="false" rows="35,*" frameborder="0" scrolling="yes">
    <frame src="admin_top.aspx" name="top" frameborder="no" scrolling="no" noresize marginheight="30">
    <frame name="right" scrolling="yes" src="admin_main.aspx">
  </frameset>
</frameset>
</html>
