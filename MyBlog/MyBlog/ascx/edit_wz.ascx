<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit_wz.ascx.cs" Inherits="MyBlog.ascx.edit_wz" %>
<asp:DataList ID="DataList1" runat="server">
    <HeaderTemplate>
        <div id="content">
            <table>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <h2>
                    <div align="center"><%# Eval("edit_title") %></div>
                </h2>
            </td>
        </tr>
        <p>
        </p>
        <p>
        </p>
        <p>
            <tr>
                <td><font color="white"><%# Eval("edit_edit") %></font>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="right"><font color="white">添加时间:<%# Eval("edit_time") %></font></div>
                </td>
            </tr>
        </p>
    </ItemTemplate>
    <FooterTemplate>
        <hr />
        <br />
        </table></div>
    </FooterTemplate>
</asp:DataList>