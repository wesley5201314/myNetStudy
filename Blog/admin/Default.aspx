<%@ Page Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" Title="后台首页"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<meta name="keywords" content='<%=pagetitle%>' />
<meta name="description" content=''/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        你还有<asp:Label ID="guestbook" runat="server" Text="0"></asp:Label>
        条留言未回复！</p>
                    <p>
                        你还有<asp:Label ID="comment" runat="server" Text="0"></asp:Label>
        条评论未审核！</p>
</asp:Content>
