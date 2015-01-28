<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="photo_show.ascx.cs" Inherits="MyBlog.ascx.photo_show" %>
<asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
    <HeaderTemplate>
        <table border="1" cellspacing="2" cellpadding="2">
            <tr width="400">
    </HeaderTemplate>
    <ItemTemplate>
        <td>
            <table border="1" bordercolor="#000000">
                <tr>
                    <td>
                        <img src="updata/small/<%# Eval("photo_smallpath")  %>" alt="<%# Eval("photo_edit")  %>" /><br />
                        <a href="updata/<%# Eval("photo_bigpath")  %>" rel="lightbox[roadtrip]"><%# Eval("photo_name") %></a></td>
                </tr>
            </table>
        </td>
    </ItemTemplate>
    <SeparatorTemplate>
    </SeparatorTemplate>
    <FooterTemplate>
        </tr></table>
    </FooterTemplate>
</asp:DataList><br />
<asp:Label ID="Label4" runat="server" Text=""></asp:Label><br />
共<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>页 当前第<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>页
                    <asp:LinkButton ID="lbtnFirstPage" runat="server" OnClick="lbtnFirstPage_Click">页首</asp:LinkButton>
<asp:LinkButton ID="lbtnpritPage" runat="server" OnClick="lbtnpritPage_Click">上一页</asp:LinkButton>
<asp:LinkButton ID="lbtnNextPage" runat="server" OnClick="lbtnNextPage_Click">下一页</asp:LinkButton>
<asp:LinkButton ID="lbtnDownPage" runat="server" OnClick="lbtnDownPage_Click">末页</asp:LinkButton>