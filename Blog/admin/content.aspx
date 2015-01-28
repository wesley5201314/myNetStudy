<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="content.aspx.cs" Inherits="admin_content" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>文章管理</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p id="nav">
<a href="addcontent.aspx">添加文章<asp:TextBox ID="searchtxt" runat="server"></asp:TextBox>
    <asp:Button ID="search" runat="server" onclick="search_Click" Text="搜索" />
    </a></p>
<p>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
         BorderColor="#3399FF" CellPadding="3" Width="100%"
        PageSize="15" ForeColor="#333333" AllowPaging="True" 
        onpageindexchanging="GridView1_PageIndexChanging">
        <PagerSettings FirstPageText="第一页" LastPageText="最后页" NextPageText="下一页" />
        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <RowStyle BackColor="#ECF5FF" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#A6CBEF" Font-Bold="True" ForeColor="#404040" BorderColor="#A6CBEF" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="编号" ControlStyle-Width="30" >
<ControlStyle Width="30px"></ControlStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="栏目">
                <ItemTemplate>
                    <asp:Label ID="chennel" runat="server" Text="栏目"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ct_title" HeaderText="标题" ControlStyle-Width="60%">
<ControlStyle Width="60%"></ControlStyle>
            </asp:BoundField>
            <asp:BoundField DataField="ct_views" HeaderText="浏览量" ControlStyle-Width="30" >
<ControlStyle Width="30px"></ControlStyle>
            </asp:BoundField>
            <asp:BoundField DataField="ct_digg" HeaderText="支持度" ControlStyle-Width="30" >
<ControlStyle Width="30px"></ControlStyle>
            </asp:BoundField>

            <asp:TemplateField HeaderText="预览">
                <ItemTemplate>
                    <asp:HyperLink ID="yulan" runat="server">预览</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="状态">
                <ItemTemplate>
                    <asp:HyperLink ID="hide" runat="server">正常</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="修改">
                <ItemTemplate>
                    <asp:HyperLink ID="edit" runat="server">修改</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</p>
    <p><asp:Button ID="selall" runat="server" onclick="selall_Click" Text="全选" />
    <asp:Button ID="delcontent" runat="server" Text="删除" 
        onclick="delcontent_Click" />
    </p>
</asp:Content>

