<%@ Page Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="GuestBook.aspx.cs" Inherits="GuestBook" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<meta name="keywords" content='<%=pagekey%>' />
<meta name="description" content='<%=pagedesc%>'/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div class="daohan">
<h3>你现在的位置：<asp:HyperLink ID="sitemap1" runat="server">HyperLink</asp:HyperLink>
    <asp:Label ID="map1" runat="server" Text="&gt;"></asp:Label>
    <asp:HyperLink ID="sitemap2" runat="server">HyperLink</asp:HyperLink>
    <asp:Label ID="map2" runat="server" Text="&gt;"></asp:Label>
    <asp:HyperLink ID="sitemap3" runat="server">HyperLink</asp:HyperLink>
    </h3>
</div>
<asp:UpdatePanel ID="UpdateGuestBook" runat="server" >
   <ContentTemplate>
   <div class="comment">
   <asp:Label ID="JS" runat="server" Text="留言需要回复才会显示出来！" ForeColor="Red"></asp:Label>
   <dl>
   <asp:ListView ID="ListGuest" runat="server" DataKeyNames="id" 
           InsertItemPosition="FirstItem" oniteminserting="ListGuest_ItemInserting" 
           onprerender="ListGuest_PreRender">
   <ItemTemplate>
      <dt>昵称：<span><%#Eval("name")%></span>
      评论时间：<span><%#Eval("modtime")%></span>
      IP：<span><%#Eval("ip")%></span></dt>
      <dd><textarea id="Vcontent" readonly="readonly" rows="6" cols="200">&nbsp;&nbsp;&nbsp;<%#Eval("content")%></textarea></dd>
      <dd><span>回复：</span><asp:Label ID="Vreview" runat="server" Text='<%#Eval("review")%>' ForeColor="Red"></asp:Label></dd>
  </ItemTemplate>
  <LayoutTemplate>
  <span ID="itemPlaceholder" runat="server"/>
  <div>
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
    <InsertItemTemplate>
    <dt>昵称：<asp:TextBox ID="Cname" runat="server" Height="20px" MaxLength="100"></asp:TextBox><span>
    </span>验证码：<asp:TextBox ID="ChkCode" runat="server" Width="50px" Height="20px" MaxLength="20"></asp:TextBox><span></span> <img src="ChkCode.aspx" id="tupian" alt="点击刷新验证码" onclick="chkcode()"/>
    <a href="javascript:document.getElementById('tupian').src='ChkCode.aspx?'+new Date;void(0);">看不清楚</a> </dt><br />
    <dt><asp:TextBox ID="Ccontent" runat="server" TextMode="MultiLine" Height="100px" MaxLength="250"></asp:TextBox></dt><br />
    <dt><asp:Button ID="Guestbtn" runat="server" Text="添加留言" CommandName="Insert"/></dt>
  </InsertItemTemplate>
  </asp:ListView>
  </dl>
</div>
     </ContentTemplate>
</asp:UpdatePanel>
<script language="jscript" type="text/jscript">
function chkcode()
{
document.getElementById("tupian").src="ChkCode.aspx?"+new Date;void(0);
}
</script>
</asp:Content>

