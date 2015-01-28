<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="addchennel.aspx.cs" Inherits="admin_addchennel" Title="添加栏目" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p>
<a href="addchennel.aspx">添加栏目</a>
</p>
    <p>
        上级栏目：&nbsp; 
        <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="30%">
        </asp:DropDownList>
    </p>
    <p>
        栏目名称：&nbsp; 
        <asp:TextBox ID="cname" runat="server" Width="50%"></asp:TextBox>
&nbsp;&nbsp;&nbsp; 排序：<asp:TextBox ID="corder" runat="server" Width="48px">0</asp:TextBox>
                </p>
                <p>
                    栏目关键字：<asp:TextBox ID="ckeywords" runat="server" Width="80%"></asp:TextBox>
    </p>
    <p>
        栏目描述：&nbsp; 
        <asp:TextBox ID="cdescription" runat="server" Height="63px" 
            TextMode="MultiLine" Width="80%"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="添加" />
    </p>

</asp:Content>

