<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="guestbook.aspx.cs" Inherits="admin_guestbook" Title="游客留言" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <table width="100%" border="1px">
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="id" 
        onitemcanceling="ListView1_ItemCanceling" onitemediting="ListView1_ItemEditing" 
        onitemupdating="ListView1_ItemUpdating" onprerender="ListView1_PreRender" 
        onitemdeleting="ListView1_ItemDeleting">
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
        <EmptyDataTemplate>
            <span>未返回数据。</span>
        </EmptyDataTemplate>
        <EditItemTemplate>
            <tr>
            <td>昵称： <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' /></td>
            <td>留言时间：<asp:Label ID="timeLabel" runat="server" Text='<%# Eval("modtime") %>' /></td>
            </tr>
            <tr>
            <td>留言：</td>
            <td><asp:TextBox ID="cTextBox" runat="server" Text='<%# Bind("content") %>' TextMode="MultiLine" Height="50px" Width="600px" /></td>
            </tr>
            <tr>
            <td>回复：</td>
             <td><asp:TextBox ID="reTextBox" runat="server" Text='<%# Bind("review") %>' TextMode="MultiLine" Height="30px" /></td>
            </tr>
            <tr>
             <td>操作：</td>
             <td>           
             <asp:Button ID="Button3" runat="server" CommandName="Update" Text="更新" />
            <asp:Button ID="Button4" runat="server" CommandName="Cancel" Text="取消" />
            </td>
            </tr>
        </EditItemTemplate>
        <ItemTemplate>
            <tr>
            <td>昵称： <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' /></td>
            <td>留言时间：<asp:Label ID="timeLabel" runat="server" Text='<%# Eval("modtime") %>' /></td>
            </tr>
            <tr>
            <td>留言：</td>
            <td><asp:Label ID="contentLabel" runat="server" Text='<%# Eval("content") %>' Height="50px" Width="600px" /></td>
            </tr>
            <tr>
            <td>回复：</td>
             <td><asp:Label ID="reviewLabel" runat="server" Text='<%# Eval("review") %>' Height="30px" /></td>
            </tr>
            <tr>
             <td>操作：</td>
             <td><asp:Button ID="Button1" runat="server" CommandName="Edit" Text="回复" />
            <asp:Button ID="Button2" runat="server" CommandName="Delete" Text="删除" /></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
                </table>
    </asp:Content>

