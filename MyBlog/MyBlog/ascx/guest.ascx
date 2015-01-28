<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="guest.ascx.cs" Inherits="MyBlog.ascx.guest" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:DataList ID="DataList1" runat="server" Width="545px">
            <HeaderTemplate>
                <div id="content">
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Label"><font color="white">以下为游客评论:</font></asp:Label>
                    <hr />
                    <table bordercolor="ffffff" border="2" cellpadding="3" cellspacing="3">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <table border="1" width="520px" bordercolor="#16508b">
                            <tr>
                                <td width="50"><font color="white"><%# Eval("guest_count") %>楼：</font></td>
                                <td width="350">
                                    <table>
                                        <tr>
                                            <td align="left"><font color="white">姓名:<%# Eval("guest_name") %></font></td>
                                            <td align="right" width="200"><font color="white">联系方式:<%# Eval("guest_qq") %></font></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <p>
                            </p>
                            <p>
                            </p>
                            <p>
                                <tr>
                                    <td width="50" height="120"><font color="white">内容:</font></td>
                                    <td width="480px" valign="top"><font color="white"><%# Eval("guest_edit") %></font>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="50"><font color="white">时间:</font></td>
                                    <td width="350"><font color="white"><%# Eval("guest_time") %></font></td>
                        </table>
                    </td>
                </tr>
                </p>
            </ItemTemplate>
            <SeparatorTemplate>
            </SeparatorTemplate>
            <FooterTemplate>
                </table></div>
            </FooterTemplate>
        </asp:DataList>&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Button1" />
    </Triggers>

</asp:UpdatePanel>


<br />
<table>
    <tr>
        <td></td>
    </tr>
    <tr>
        <td>
            <hr width="549" />
        </td>
    </tr>
</table>
<br />
<br />

<br />
<table style="width: 549px; height: 245px">
    <tr>
        <td><font color="white">签写评价</font>
        </td>
    </tr>
    <tr>
        <td style="height: 27px"><font color="white">姓名:</font>
        </td>
        <td style="height: 27px">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="姓名不能为空！！" Style="position: relative">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td><font color="white">联系方式:</font>
        </td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox2" ErrorMessage="联系方式不能为空！！" Style="position: relative" Width="10px">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td><font color="white">内容:</font>
        </td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Height="137px" Width="452px"></asp:TextBox>
            <br />
            <font color="red">*请不要输入任何非法字符串</font>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" Style="left: 293px; position: relative; top: 10px" Width="149px" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage=" 内容不能为空！！" Style="left: 457px; position: relative; top: -133px">*</asp:RequiredFieldValidator>
        </td>
    </tr>
</table>



<asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
<br />
