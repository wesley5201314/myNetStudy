<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="photo_type.ascx.cs" Inherits="MyBlog.ascx.photo_type" %>
<asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
        <h3>相册分类</h3>
        <div class="navcontainer">
            <ul class="navlist">
    </HeaderTemplate>
    <ItemTemplate>
        <li><a href="photo.aspx?type=<%# Eval("type_id") %>"><%# Eval("type_title") %></a></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
</div>
    </FooterTemplate>
</asp:Repeater>
