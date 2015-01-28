<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="photo_title.ascx.cs" Inherits="MyBlog.ascx.photo_title" %>
<asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
        <table>
            <tr width="549px;">
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Label"><font color="white">相册分类</font></asp:Label></td>
    </HeaderTemplate>
    <ItemTemplate>
        <td width="80">
            <img src="images/arrow.gif" /><a href="photo.aspx?type=<%# Eval("type_id") %>"><%# Eval("type_title") %></a></td>
    </ItemTemplate>
    <FooterTemplate>
        </tr>
</table>
    </FooterTemplate>
</asp:Repeater>
