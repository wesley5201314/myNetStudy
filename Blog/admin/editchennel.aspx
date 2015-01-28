<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="editchennel.aspx.cs" Inherits="admin_editchennel" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p id="nav">
<a href="addchennel.aspx">添加栏目</a>
</p>
    <p>
        上级栏目：&nbsp; 
        <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="209px">
        </asp:DropDownList>
    </p>
    <p>
        栏目名称：&nbsp; 
        <asp:TextBox ID="cname" runat="server" Width="211px"></asp:TextBox>
&nbsp;&nbsp;&nbsp; 排序：<asp:TextBox ID="corder" runat="server" Width="48px">0</asp:TextBox>
                </p>
                <p>
                    栏目关键字：<asp:TextBox ID="ckeywords" runat="server" Width="438px"></asp:TextBox>
    </p>
    <p>
        栏目描述：&nbsp; 
        <asp:TextBox ID="cdescription" runat="server" Height="63px" 
            TextMode="MultiLine"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" Text="修改" onclick="Button1_Click" />
    </p>
</asp:Content>

