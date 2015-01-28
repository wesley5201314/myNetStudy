<%@ Page Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" Title="无标题页" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
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
<div class="newslist">
<asp:ListView ID="ListSearch" runat="server">
<ItemTemplate>
<dl>
   <dt><a href="Show.aspx?id=<%# Eval("id") %>" target="_blank"><%# Eval("ct_title") %></a></dt>
   <dd class="preview"><%#Eval("ct_description")%></dd>
   <dd class="info">发表于：<span><%# Eval("ct_time")%></span>浏览次数：<span><%# Eval("ct_views")%></span>支持度：<span><%# Eval("ct_digg")%></span><a href="Show.aspx?id=<%# Eval("id") %>" target="_blank">查阅全文</a></dd>
</dl>
</ItemTemplate>
<LayoutTemplate>
            <span ID="itemPlaceholder" runat="server"/>
</LayoutTemplate>
</asp:ListView>
<div class="daohan">
   <h3>&nbsp;<webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" 
        UrlPaging="True" FirstPageText="第一页" LastPageText="最后一页" 
        NextPageText="下一页" PageSize="5" 
        PrevPageText="上一页" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" 
        CustomInfoHTML="当前第%CurrentPageIndex%页，共%PageCount%页" 
        PageIndexOutOfRangeErrorMessage="超出最大页数" 
        onpagechanged="AspNetPager1_PageChanged">
    </webdiyer:AspNetPager></h3> 
</div>
</div>
</asp:Content>

