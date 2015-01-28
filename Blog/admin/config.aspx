<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="config.aspx.cs" Inherits="admin_config" Title="系统配置" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        博客名称：<asp:TextBox ID="ctitle" runat="server" MaxLength="200" Width="224px"></asp:TextBox>
    </p>
    <p>
        关键字：<asp:TextBox ID="ckeywords" runat="server" MaxLength="200" Width="404px"></asp:TextBox>
        (英文状态下&quot;,&quot;号分割)</p>
    <p>
        博客描述：<asp:TextBox ID="cdescription" runat="server" Height="48px" 
            MaxLength="200" TextMode="MultiLine" Width="398px"></asp:TextBox>
    </p>
                  <p>
                      程序路径：<asp:TextBox ID="cinstalldir" runat="server"></asp:TextBox>
                      （以“/”结尾）</p>
    <p>
        头像：<asp:Image ID="Image1" runat="server" AlternateText="未找到头像" Height="100px" 
            Width="100px" />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="上传头像" />
                    </p>
                    <p>
                        个人简介：<asp:TextBox ID="cjianjie" runat="server" Width="405px"></asp:TextBox>
                    </p>
                    <p>
                        管理帐号：<asp:TextBox ID="cname" runat="server" MaxLength="50" Width="149px"></asp:TextBox>
    </p>
    <p>
        管理密码：<asp:TextBox ID="cpass" runat="server" MaxLength="50" Width="146px"></asp:TextBox>
        (不修改请留空)</p>
    <p>
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="修改" />
    </p>
</asp:Content>

