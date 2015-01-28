<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="addcontent.aspx.cs" Inherits="admin_addcontent" Title="添加文章" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!--<script type="text/jscript" language="jscript">
function inserthtml()
{
//document.getElementById("ctl00_ContentPlaceHolder1_ctitle").insertHTML("111");
alert("111");
} 
</script>-->
<table width="100%">
<asp:UpdatePanel ID="UpdateADD" runat="server" >
<ContentTemplate>
<tr>
<td>
<a href="addcontent.aspx">添加文章</a><asp:Label ID="js" runat="server" ForeColor="Red"></asp:Label>
    </td>
</tr>
<tr>
<td>
    文章栏目：<asp:DropDownList ID="DropDownList1" runat="server" Height="16px" 
        Width="30%">
    </asp:DropDownList>
    </td>
</tr>
<tr>
<td>
        文章标题：<asp:TextBox ID="ctitle" runat="server" Width="80%" 
            ontextchanged="ctitle_TextChanged" AutoPostBack="true"></asp:TextBox>
        <asp:CheckBox ID="ccommend" runat="server" Text="推荐" />
        <asp:CheckBox ID="chide" runat="server" Text="隐藏" />
    </td>
</tr>
<tr>
<td>
        关键字：<asp:TextBox ID="ckeywords" runat="server" Width="80%"></asp:TextBox>
        权重：<asp:TextBox ID="corder" runat="server" Width="40px">0</asp:TextBox>
    </td>
</tr>
<tr>
<td>
        文件上传：
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="UPfile" runat="server" onclick="UPfile_Click" Text="上传" />
    </td>
</tr>
<tr>
<td>
    <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" BasePath="fckeditor/" Height="600px">
    </FCKeditorV2:FCKeditor>
    </td>
</tr>
<tr>
<td>
        <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click"/>
    </td>
</tr>
</ContentTemplate>
</asp:UpdatePanel>
    </table>
</asp:Content>