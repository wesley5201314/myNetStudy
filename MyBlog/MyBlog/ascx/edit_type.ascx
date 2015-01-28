<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit_type.ascx.cs" Inherits="MyBlog.ascx.edit_type" %>
<asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
        <h3>日志分类</h3>
        <div class="navcontainer">
            <ul class="navlist">
    </HeaderTemplate>
    <ItemTemplate>
        <li><a href="edit.aspx?type=<%# Eval("type_id") %>"><%# Eval("type_title") %></a></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
</div>
    </FooterTemplate>
</asp:Repeater>
