<%@ Page Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Show.aspx.cs" Inherits="Show" Title="无标题页" %>

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
<asp:UpdatePanel ID="UpdateDigg" runat="server" >
   <ContentTemplate>
  <div id="title"><h2><%=ct_title%></h2>
  <p><span>发表时间：<%=ct_time %></span> <span>浏览：<%= ct_views%>次</span> <span>被顶次数：<asp:Label
          ID="diggsu" runat="server" Text="Label"></asp:Label></span></p>
  </div>
  <div id="content"><%= content %></div>
  <div class="digg">
  <asp:ImageButton ID="diggbuttom" runat="server" Height="45px" Width="70px" 
           ImageUrl="~/images/digg.gif" onclick="diggbuttom_Click"/>
  </div>
 </ContentTemplate>
</asp:UpdatePanel>
   
<div class="actbar"><span>标签：<%= tags %></span></div>
<div class="context">
	<div style='float:left'>
	上一篇：<asp:HyperLink ID="up" runat="server" onprerender="up_PreRender">HyperLink</asp:HyperLink><br />
	下一篇：<asp:HyperLink ID="down" runat="server">HyperLink</asp:HyperLink></div>
	</div> 
<asp:UpdatePanel ID="UpdateComment" runat="server" >
   <ContentTemplate>
   <div class="comment">
   文章评论：
   <dl>
   <asp:ListView ID="ListComment" runat="server" DataKeyNames="id" 
           onprerender="ListComment_PreRender" InsertItemPosition="LastItem" 
           oniteminserting="ListComment_ItemInserting">
   <ItemTemplate>
      <dt>昵称：<span><%#Eval("name")%></span>
      评论时间：<span><%#Eval("cotime")%></span>
      IP：<span><%#Eval("ip")%></span></dt>
      <dd><textarea id="Csay" readonly="readonly" rows="6" cols="200">&nbsp;&nbsp;&nbsp;<%#Eval("say")%></textarea></dd>
  </ItemTemplate>
  <LayoutTemplate>
  <span ID="itemPlaceholder" runat="server"/>
  </LayoutTemplate>
    <InsertItemTemplate>
    <dt>昵称：<asp:TextBox ID="Cname" runat="server" Height="20px" MaxLength="100"></asp:TextBox><span>
    </span>验证码：<asp:TextBox ID="ChkCode" runat="server" Width="50px" Height="20px" MaxLength="20"></asp:TextBox><span></span> <img src="ChkCode.aspx" id="tupian" alt="点击刷新验证码" onclick="chkcode()"/>
    <a href="javascript:document.getElementById('tupian').src='ChkCode.aspx?'+new Date;void(0);">看不清楚</a> </dt><br />
    <dt><asp:TextBox ID="Csay" runat="server" TextMode="MultiLine" Height="100px" MaxLength="250"></asp:TextBox></dt><br />
    <dt><asp:Button ID="comment" runat="server" Text="添加评论" CommandName="Insert"/></dt>
  </InsertItemTemplate>
  </asp:ListView>
   <asp:Label ID="JS" runat="server" Text="评论需要审核后才会显示出来！" ForeColor="Red"></asp:Label>
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
<script language="Javascript" type="text/javascript">
window.onload=function onloa()
{
var as=document.getElementById("content").getElementsByTagName("a");
for(var i = 0; i < as.length; i++)
as[i].target="_blank";
var imgwidth=540;
var img=document.getElementById("content").getElementsByTagName("img");
for(var i=0; i<img.length;i++)
if(img[i].width>imgwidth)
{
img[i].width=imgwidth;
img[i].style.width=imgwidth;
img[i].border=0;
}
}
</script> 
</asp:Content>

