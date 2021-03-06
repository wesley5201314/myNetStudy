﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="photo_edit_type.aspx.cs" Inherits="MyBlog.admin.photo.photo_edit_type" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>无标题页</title>
     <style type="text/css">
table  { border:0px; }
td  { font:normal 12px 宋体; }
img  { vertical-align:bottom; border:0px; }
a  { font:normal 12px 宋体; color:#000000; text-decoration:none; }
a:hover  { color:#428EFF;text-decoration:underline; }
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
 <table width="98%" border="0" align="center" cellpadding="0" cellspacing="1" BGCOLOR="#39867B">
 <tr> 
    <td height="20" align="center"><font color="#FFFFFF">图片分类查看与修改</font></td>
  </tr>
  <tr>
  <table width="95%" border="0" align="center" cellpadding="1" cellspacing="1" bgcolor="#f1f1f1">
          <tr bgcolor="#FFFFFF" align="center" height="20"> 
            <td width="30%">图片分类</td>
            <td width="8%">操   作</td>
          </tr>
 </HeaderTemplate>
                    <ItemTemplate>
                    <tr bgcolor="#FFFFFF" align="center" >
                    <td align="left"><img src="../images/admin_top_open.gif"  height="16"/><a href='photo_type_edit.aspx?id=<%# Eval("type_id")  %>'><%# Eval("type_title")%></a></td><td align="center"><a href='photo_type_edit.aspx?id=<%# Eval("type_id")  %>'>修改</a><a href='photo_type_delete.aspx?id=<%# Eval("type_id")  %>'>  删除</a>
                    </td>
                    </tr>
                    </ItemTemplate>
                    <SeparatorTemplate>
                    <tr>
                    <td>
                    <hr size="1pt"  /></td>
                    </tr>
                    </SeparatorTemplate>
                    <FooterTemplate>
                    </table>

                    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="1" BGCOLOR="#39867B">
                    <tr> 
    <td height="20" align="center"><font color="#FFFFFF">图片分类查看与修改</font></td>
  </tr>
                    
                    </table>
                    </FooterTemplate>
                    </asp:Repeater>
        <br />
                    <br />
                    <div align=center>
                        <asp:Label ID="Label1" runat="server" Text="注意:删除分类的同时也会把分类下属的图片一并删除！" Font-Names="宋体" Font-Size="12px" ForeColor="Red"></asp:Label></div>
    </div>
    </form>
</body>
</html>
