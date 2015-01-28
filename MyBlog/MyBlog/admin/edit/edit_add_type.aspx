<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_add_type.aspx.cs" Inherits="MyBlog.admin.edit.edit_add_type" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="Label4" runat="server" Text="Label" Font-Names="宋体" Font-Size="12px">当前位置:添加分类</asp:Label><br />
        <hr /><br />
        <asp:Label ID="Label1" runat="server" Text="已有分类："  Font-Names="宋体" Font-Size="12px"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" Width="112px" Font-Names="宋体" Font-Size="12px">
        </asp:DropDownList><br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="添加类别："  Font-Names="宋体" Font-Size="12px"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Font-Names="宋体" Font-Size="12px" Width="156px"></asp:TextBox><br />
        <br />
   
   <asp:Button ID="Button1" runat="server" Text="添加" Font-Size="12px" Font-Names="宋体" OnClick="Button1_Click1" />  </div>
   </form>
    
</body>
</html>
