<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="edit_show.ascx.cs" Inherits="MyBlog.ascx.edit_show" %>
<asp:DataList ID="DataList1" runat="server">
    <HeaderTemplate>
        <div id="content">
            <table>
    </HeaderTemplate>
    <ItemTemplate>

        <tr>
            <td>
                <h2><a href='edit_show.aspx?id=<%# Eval("edit_id")  %>&type=<%# Eval("edit_type")  %>'><%# Eval("edit_title") %></a>
            </td>
        </tr>
        <tr>
            <td><font color="white"><%#GetSubString(DataBinder.Eval(Container.DataItem,"edit_edit").ToString(),200,100)%></font>
            </td>
        </tr>
    </ItemTemplate>
    <SeparatorTemplate>
        <tr>
            <td>
                <hr />
            </td>
        </tr>
    </SeparatorTemplate>
    <FooterTemplate>
        <tr>
            <td>
                <hr />
            </td>
        </tr>
        </table>
    </FooterTemplate>
</asp:DataList><br />
<font color="white">
<asp:Label ID="Label4" runat="server" Text=""></asp:Label><br />
共<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>页 当前第<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>页
                    <asp:LinkButton ID="lbtnFirstPage" runat="server" OnClick="lbtnFirstPage_Click" >页首</asp:LinkButton> 
                    <asp:LinkButton ID="lbtnpritPage" runat="server" OnClick="lbtnpritPage_Click">上一页</asp:LinkButton> 
                    <asp:LinkButton ID="lbtnNextPage" runat="server" OnClick="lbtnNextPage_Click">下一页</asp:LinkButton> 
                    <asp:LinkButton ID="lbtnDownPage" runat="server" OnClick="lbtnDownPage_Click">末页</asp:LinkButton>
<asp:Label ID="Label3" runat="server" Text="每页显示10篇日志"></asp:Label><br /> </font>

