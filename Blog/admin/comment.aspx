<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="comment.aspx.cs" Inherits="admin_comment" Title="评论管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table width="100%" border="1px">
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="id" 
        onprerender="ListView1_PreRender" onitemediting="ListView1_ItemEditing" 
        onitemupdating="ListView1_ItemUpdating" 
        onitemdeleting="ListView1_ItemDeleting" 
        onitemcanceling="ListView1_ItemCanceling">
     <EditItemTemplate>
            <tr>
            <td>文章标题</td>
            <td>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("ct_title") %>' Width="30%"></asp:Label></td>
            </tr>
            <tr>
            <td>昵称： <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>'/></td>
            <td>评论时间：<asp:Label ID="timeLabel" runat="server" Text='<%# Eval("time") %>'/></td>
            </tr>
            <tr>
            <td>评论内容：</td>
            <td><asp:TextBox ID="cTextBox" runat="server" Text='<%# Bind("say") %>' TextMode="MultiLine" Height="50px" Width="60%" /></td>
            </tr>
            <tr>
             <td>操作：</td>
             <td>
            状态：<asp:DropDownList ID="DropDownList1" runat="server">
                  <asp:ListItem Value="1"  Text="已审核"></asp:ListItem>
                  <asp:ListItem Value="0"  Text="未审核"></asp:ListItem>
                 </asp:DropDownList>      
             <asp:Button ID="Button3" runat="server" CommandName="Update" Text="更新" />
            <asp:Button ID="Button4" runat="server" CommandName="Cancel" Text="取消" />
            </td>
            </tr>
        </EditItemTemplate>
        <ItemTemplate>
            <tr>
            <td>文章标题</td>
            <td  Width="40%">
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("ct_title") %>'></asp:Label></td>
            </tr>
            <tr>
            <td>昵称： <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' /></td>
            <td>评论时间：<asp:Label ID="timeLabel" runat="server" Text='<%# Eval("time") %>' /></td>
            </tr>
            <tr>
            <td>评论内容：</td>
            <td><asp:TextBox ID="contentTextBox" runat="server" Text='<%# Eval("say") %>' TextMode="MultiLine" Width="900px" Height="50px" ReadOnly="True" /></td>
            </tr>
            <tr>
             <td>操作：</td>
             <td>状态：<asp:Label ID="Label2" runat="server" Text='<%# Eval("shen") %>'></asp:Label>
                 <asp:Button ID="Button1" runat="server" CommandName="Edit" Text="编辑" />
            <asp:Button ID="Button2" runat="server" CommandName="Delete" Text="删除" /></td>
            </tr>
        </ItemTemplate>
    <EmptyDataTemplate>
            <span>未返回数据。</span>
        </EmptyDataTemplate>
    <LayoutTemplate>
            <div ID="itemPlaceholderContainer" runat="server" style="">
                <span ID="itemPlaceholder" runat="server" />
            </div>
            <div style="">
                <asp:DataPager ID="DataPager1" runat="server">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                            ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                            ShowNextPageButton="False" ShowPreviousPageButton="False" />
                    </Fields>
                </asp:DataPager>
            </div>
        </LayoutTemplate>
    </asp:ListView>
                </table>
</asp:Content>

