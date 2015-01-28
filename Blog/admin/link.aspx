<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="link.aspx.cs" Inherits="admin_link" Title='友情链接' %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ListView ID="ListView1" runat="server" DataKeyNames="id" 
        InsertItemPosition="LastItem" onitemcanceling="ListView1_ItemCanceling" 
        onitemediting="ListView1_ItemEditing" onprerender="ListView1_PreRender" 
        onitemdeleting="ListView1_ItemDeleting" 
        oniteminserting="ListView1_ItemInserting" 
        onitemupdating="ListView1_ItemUpdating">
        <AlternatingItemTemplate>
            <tr style="background-color: #FFFFFF;color: #284775;width:100%;">
                <td style="width:5%">
                    <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                </td>
                <td style="width:15%">
                    <asp:Label ID="sitenameLabel" runat="server" Text='<%# Eval("sitename") %>' />
                </td>
                <td style="width:30%">
                    <asp:Label ID="siteurlLabel" runat="server" Text='<%# Eval("siteurl") %>' />
                </td>
                 <td style="width:30%">
                    <asp:Label ID="logoLabel" runat="server" Text='<%# Eval("logo") %>' />
                </td>
                <td style="width:20%">
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <LayoutTemplate>
            <table runat="server" width="100%">
                <tr runat="server">
                    <td runat="server">
                        <table ID="itemPlaceholderContainer" runat="server" border="1" 
                            style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr runat="server" style="background-color: #E0FFFF;color: #333333;">
                                <th runat="server" style="width:15px">
                                    id</th>
                                <th runat="server">
                                    sitename</th>
                                <th runat="server" style="width:30%">
                                    siteurl</th>
                                <th runat="server" style="width:30%">
                                    logo</th>
                                <th id="Th1" runat="server" style="width:20%">
                                </th>
                            </tr>
                            <tr ID="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" 
                        style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                    ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                                    ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <InsertItemTemplate>
            <tr style="">
            <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="sitenameTextBox" runat="server" 
                        Text='<%# Bind("sitename") %>' />
                </td>
                <td>
                    <asp:TextBox ID="siteurlTextBox" runat="server" Text='<%# Bind("siteurl") %>' />
                </td>
                <td>
                    <asp:TextBox ID="logoTextBox" runat="server" Text='<%# Bind("logo") %>' />
                </td>
                 <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                </td>
            </tr>
        </InsertItemTemplate>
        <SelectedItemTemplate>
            <tr style="background-color: #E2DED6;font-weight: bold;color: #333333;">
                <td style="width:5%">
                    <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                </td>
                <td  style="width:15%">
                    <asp:Label ID="sitenameLabel" runat="server" Text='<%# Eval("sitename") %>' />
                </td>
                <td style="width:30%">
                    <asp:Label ID="siteurlLabel" runat="server" Text='<%# Eval("siteurl") %>' />
                </td>
                <td style="width:30%">
                    <asp:Label ID="logoLabel" runat="server" Text='<%# Eval("logo") %>' />
                </td>
                 <td style="width:20%">
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                </td>
            </tr>
        </SelectedItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" 
                style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                <tr>
                    <td>
                        未返回数据。</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <EditItemTemplate>
            <tr style="background-color: #999999;">
               
                <td>
                    <asp:Label ID="idLabel1" runat="server" Text='<%# Eval("id") %>' />
                </td>
                <td>
                    <asp:TextBox ID="sitenameTextBox" runat="server" 
                        Text='<%# Bind("sitename") %>' />
                </td>
                <td>
                    <asp:TextBox ID="siteurlTextBox" runat="server" Text='<%# Bind("siteurl") %>' />
                </td>
                <td>
                    <asp:TextBox ID="logoTextBox" runat="server" Text='<%# Bind("logo") %>' />
                </td>
                 <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                </td>
            </tr>
        </EditItemTemplate>
        <ItemTemplate>
            <tr style="background-color: #E0FFFF;color: #333333;">

                <td style="width:5%">
                    <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                </td>
                <td style="width:15%"> 
                    <asp:Label ID="sitenameLabel" runat="server" Text='<%# Eval("sitename") %>' />
                </td>
                <td style="width:30%">
                    <asp:Label ID="siteurlLabel" runat="server" Text='<%# Eval("siteurl") %>' />
                </td>
                <td style="width:30%">
                    <asp:Label ID="logoLabel" runat="server" Text='<%# Eval("logo") %>' />
                </td>
                                <td style="width:20%">
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" />
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    
</asp:Content>

