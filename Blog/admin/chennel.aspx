<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="chennel.aspx.cs" Inherits="admin_chennel" Title="栏目管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p id="nav">
<a href="addchennel.aspx">添加栏目</a>
</p>
 <p style="margin:2px">
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
         BorderColor="#3399FF" CellPadding="3"
         onprerender="GridView1_PreRender" ShowFooter="True" Width="100%">
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <RowStyle BackColor="#ECF5FF" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#A6CBEF" Font-Bold="True" ForeColor="#404040" BorderColor="#A6CBEF" />
         <Columns>
             <asp:BoundField DataField="id" HeaderText="编号" ItemStyle-Width="10px" 
                 ItemStyle-BorderStyle="Solid" >
<ItemStyle BorderStyle="Solid" Width="10px"></ItemStyle>
             </asp:BoundField>
             <asp:BoundField DataField="ch_name" HeaderText="栏目" ItemStyle-Width="60%" 
                 ItemStyle-BorderStyle="Solid" >
<ItemStyle BorderStyle="Solid" Width="60%"></ItemStyle>
             </asp:BoundField>
             <asp:BoundField DataField="ch_order" HeaderText="权重" ItemStyle-Width="10%" 
                 ItemStyle-BorderStyle="Solid">
<ItemStyle BorderStyle="Solid" Width="10%"></ItemStyle>
             </asp:BoundField>
             <asp:TemplateField HeaderText="操作" ItemStyle-Width="20%" ItemStyle-BorderStyle="Solid">
                 <ItemTemplate>
                     <asp:HyperLink ID="edit" runat="server">修改</asp:HyperLink>
                     <asp:HyperLink ID="del" runat="server">删除</asp:HyperLink>
                 </ItemTemplate>

<ItemStyle BorderStyle="Solid" Width="20%"></ItemStyle>
             </asp:TemplateField>
         </Columns>
     </asp:GridView>
 </p>
</asp:Content>

