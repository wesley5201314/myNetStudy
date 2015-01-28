<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="newshow.ascx.cs" Inherits="MyBlog.ascx.newshow" %>
<asp:DataList ID="DataList1" runat="server">
    <HeaderTemplate>
        <div id="content">
            <table>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <h2><a href='edit_show.aspx?id=<%# Eval("edit_id")  %>&type=<%# Eval("edit_type") %>'><%# Eval("edit_title") %></a>
            </td>
            </h2>
        </tr>
        <p>
            <tr>
                <td><font color="white">
                <%#GetSubString(DataBinder.Eval(Container.DataItem,"edit_edit").ToString(),500,200)%></font>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right"><font color="white">添加时间:<%# Eval("edit_time") %>    <a href='edit_show.aspx?id=<%# Eval("edit_id")  %>&type=<%# Eval("edit_type") %>'>点击查看全文</a></font></div>
                </td>
            </tr>
        </p>
    </ItemTemplate>
    <FooterTemplate>
        <hr />
        <br />
        <div align="right"><a href="edit.aspx">更多文章...</a></div>
        </table></div>
    </FooterTemplate>
</asp:DataList>
<br />
<table>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
        <td>
            <hr width="549" />
        </td>
    </tr>
</table>
<br />
<br />

