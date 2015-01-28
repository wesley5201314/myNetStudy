<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_edit.aspx.cs" Inherits="MyBlog.admin.edit.admin_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
    <td height="20" align="center"><font color="#FFFFFF">文章查看与修改</font></td>
  </tr>
  <tr>
  <table width="95%" border="0" align="center" cellpadding="1" cellspacing="1" bgcolor="#f1f1f1">
          <tr bgcolor="#FFFFFF" align="center" height="20"> 
            <td width="30%">文章标题</td>
            <td width="17%">加入时间</td>
            <td width="8%">操   作</td>
          </tr>
 </HeaderTemplate>
                    <ItemTemplate>
                    <tr bgcolor="#FFFFFF" align="center" >
                    <td align="left"><img src="../images/admin_top_open.gif"  height="16"/><a href='admin_edit_edit.aspx?id=<%# Eval("edit_id")  %>'><%# Eval("edit_title") %></a></td><td align="center"><%# Eval("edit_time") %></td><td align="center"><a href='admin_edit_edit.aspx?id=<%# Eval("edit_id")  %>'>修改</a><a href='admin_edit_delete.aspx?id=<%# Eval("edit_id")  %>'>  删除</a>
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
    <td height="20" align="center"><font color="#FFFFFF">图片查看与修改</font></td>
  </tr>
                    
                    </table>
                    </FooterTemplate>
                    </asp:Repeater>
                    <br />
     <div style="font:normal 12px 宋体;" align="right">共<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>页 当前第<asp:Label ID="Label2"
            runat="server" Text="Label"></asp:Label>页
                    <asp:LinkButton ID="lbtnFirstPage" runat="server" OnClick="lbtnFirstPage_Click" >页首</asp:LinkButton> 
                    <asp:LinkButton ID="lbtnpritPage" runat="server" OnClick="lbtnpritPage_Click">上一页</asp:LinkButton> 
                    <asp:LinkButton ID="lbtnNextPage" runat="server" OnClick="lbtnNextPage_Click">下一页</asp:LinkButton> 
                    <asp:LinkButton ID="lbtnDownPage" runat="server" OnClick="lbtnDownPage_Click">末页</asp:LinkButton><br /></div>
    </div>
    </form>
</body>
</html>
