<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="guest_post.ascx.cs" Inherits="MyBlog.ascx.guest_post" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:DataList ID="DataList1" runat="server" Width="545px">
            <HeaderTemplate>
                <div id="content">
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Label"><font color="white">以下为游客留言:</font></asp:Label>
                    <hr />
                    <table bordercolor="ffffff" border="2" cellpadding="3" cellspacing="3">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <table border="1" bordercolor="#16508b">
                            <tr>
                                <td width="100"><font color="white"><%# Eval("post_count") %>楼：</font></td>
                                <td>
                                    <table>
                                        <tr width="550">
                                            <td width="150"><font color="white">姓名:<%# Eval("post_name") %></font></td>
                                            <td width="300"><font color="white">QQ:<%# Eval("post_qq") %></font></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td width="100"><font color="white">地址：</font></td>
                                <td>
                                    <table>
                                        <tr width="450">
                                            <td width="150"><font color="white">来自:<%# Eval("post_from") %></font></td>
                                            <td width="350"><font color="white">E-MAIL:<%# Eval("post_mail") %></font></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr width="600">
                                <td width="100" height="120"><font color="white">内容:</font></td>
                                <td width="480px" valign="top"><font color="white"><%# Eval("post_edit") %></font>
                                </td>
                            </tr>
                            <tr>
                                <td width="50"><font color="white">时间:</font></td>
                                <td width="350"><font color="white"><%# Eval("post_time") %></font></td>
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
        </asp:DataList><br />
        <font color="white">
共<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>页 当前第<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>页
                    <asp:LinkButton ID="lbtnFirstPage" runat="server" OnClick="lbtnFirstPage_Click" >页首</asp:LinkButton> 
                    <asp:LinkButton ID="lbtnpritPage" runat="server" OnClick="lbtnpritPage_Click">上一页</asp:LinkButton> 
                    <asp:LinkButton ID="lbtnNextPage" runat="server" OnClick="lbtnNextPage_Click">下一页</asp:LinkButton> 
                    <asp:LinkButton ID="lbtnDownPage" runat="server" OnClick="lbtnDownPage_Click">末页</asp:LinkButton>
<asp:Label ID="Label3" runat="server" Text="每页显示10条留言"></asp:Label><br /> </font>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Button1" />
    </Triggers>
</asp:UpdatePanel>


<table>
    <tr>
        <td>
            <hr width="549" />
        </td>
    </tr>
</table>
<asp:Label ID="Label4" runat="server" Text=""></asp:Label><br />
<font color="write">请在这里写下您的留言 O(∩_∩)O~</font>
<table style="width: 549px;">
    <tr>
        <td width="80"><font color="white">姓名:</font></td>
        <td>
            <table>
                <tr>
                    <td style="height: 27px">
                        <asp:TextBox ID="TextBox1" runat="server" Width="117px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox1" ErrorMessage="姓名不能为空！！" Style="position: relative">*</asp:RequiredFieldValidator>
                    </td>
                    <td><font color="white">QQ:</font>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server" Width="163px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="width: 88px"><font color="white">来自:</font></td>
        <td>
            <table>
                <tr>
                    <td style="height: 27px">
                        <asp:TextBox ID="TextBox3" runat="server" Width="117px"></asp:TextBox>
                    </td>
                    <td>&nbsp;&nbsp; <font color="white">E-MAIL:</font>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox4" runat="server" Width="163px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>

        <td><font color="white">内容:</font>
        </td>
        <td style="width: 349px">
            <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine" Height="191px" Width="498px" MaxLength="10"></asp:TextBox>
            <br />
            <font color="red">*请不要输入任何非法字符串</font>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" Style="left: 293px; position: relative; top: 10px" Width="149px" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage=" 内容不能为空！！" Style="left: 457px; position: relative; top: -133px">*</asp:RequiredFieldValidator>
        </td>

    </tr>
</table>



<asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
<br />
