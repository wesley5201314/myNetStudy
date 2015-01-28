<%@ Page Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="无标题页" %>

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
<asp:ListView ID="ListContent" runat="server" onprerender="ListContent_PreRender">
<ItemTemplate>
<dl>
   <dt><a href="Show.aspx?id=<%# Eval("id") %>" target="_blank" title='<%# Eval("ct_title") %>'><%# Eval("ct_title") %></a></dt>
   <dd class="preview"><%#myli.GetSubString(Eval("ct_description").ToString(),300) %></dd>
   <dd class="info">发表于：<span><%# Eval("ct_time")%></span>浏览次数：<span><%# Eval("ct_views")%></span>支持度：<span><%# Eval("ct_digg")%></span><a href="Show.aspx?id=<%# Eval("id") %>" target="_blank">查阅全文</a></dd>
</dl>
</ItemTemplate>
<LayoutTemplate>
            <span ID="itemPlaceholder" runat="server"/>
</LayoutTemplate>
</asp:ListView>
<div class="daohan">
   <h3><webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" 
        UrlPaging="True" FirstPageText="第一页" LastPageText="最后一页" 
        NextPageText="下一页" onpagechanged="AspNetPager1_PageChanged" PageSize="10" 
        PrevPageText="上一页" ShowCustomInfoSection="Left" ShowPageIndexBox="Always" 
        CustomInfoHTML="当前第%CurrentPageIndex%页，共%PageCount%页" 
        PageIndexOutOfRangeErrorMessage="超出最大页数">
    </webdiyer:AspNetPager></h3> 
</div>
</div>
</asp:Content>

