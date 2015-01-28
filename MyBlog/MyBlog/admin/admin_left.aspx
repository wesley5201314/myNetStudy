<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_left.aspx.cs" Inherits="MyBlog.admin.admin_left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网站管理系统</title>
    <style type="text/css">
        body {
            background: #39867B;
            margin: 0px;
            font: 9pt 宋体;
        }

        table {
            border: 0px;
        }

        td {
            font: normal 12px 宋体;
        }

        img {
            vertical-align: bottom;
            border: 0px;
        }

        a {
            font: normal 12px 宋体;
            color: #000000;
            text-decoration: none;
        }

            a:hover {
                color: #428EFF;
                text-decoration: underline;
            }

        .sec_menu {
            border-left: 1px solid white;
            border-right: 1px solid white;
            border-bottom: 1px solid white;
            overflow: hidden;
            background: #C6EBDE;
        }

        .menu_title {
        }

            .menu_title span {
                position: relative;
                top: 2px;
                left: 8px;
                color: #39867B;
                font-weight: bold;
            }

        .menu_title2 {
        }

            .menu_title2 span {
                position: relative;
                top: 2px;
                left: 8px;
                color: #39867B;
                font-weight: bold;
            }
    </style>
    <script language="javascript">
        function showsubmenu(sid) {
            whichEl = eval("submenu" + sid);
            imgmenu = eval("imgmenu" + sid);
            if (whichEl.style.display == "none") {
                eval("submenu" + sid + ".style.display=\"\";");
                imgmenu.background = "images/menuup.gif";
            }
            else {
                eval("submenu" + sid + ".style.display=\"none\";");
                imgmenu.background = "images/menudown.gif";
            }
        }

        top.document.title = "网站管理系统";
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellspacing="0" cellpadding="0" width="158" align="center">
                <tr>
                    <td valign="bottom" height="42">
                        <img height="38" src="images/title.gif" width="158" border="0"></td>
                </tr>
                <tr>

                    <td class="menu_title" background="images/title_bg_quit.gif" height="25">
                        <span><a href="../index.aspx" target="_blank"><b>网站首页 </b></a>| <a href="admin_logout.aspx" target="_top"><b>注销登录</b></a></span></td>
                </tr>
                <tr>
                    <td align="center">
                        <font face="Webdings" color="#FFFFFF" style="cursor: hand">5</font> </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="0" width="158" align="center">
                <tr>
                    <td class="menu_title" id="imgmenu1" onclick="showsubmenu(1)" style="cursor: hand" background="images/menudown.gif" height="25">&nbsp;<span>网站设置</span> </td>
                </tr>
                <tr>
                    <td id="submenu1" style="DISPLAY: none" align="left">
                        <div class="sec_menu" style="WIDTH: 158px">
                            <table cellpadding="0" cellspacing="0" align="center" width="135">
                                <tr>
                                    <td height="20"><a href="admin_setup.aspx" target="right">基本设置</a></td>
                                </tr>

                            </table>
                        </div>
                        <br>
                    </td>
                </tr>
                <td id="imgmenu2" class="menu_title" onclick="showsubmenu(2)" style="cursor: hand" background="images/menudown.gif" height="25">&nbsp;<span>文章管理 </span></td>
                </tr>
	<tr>
        <td id="submenu2" style="DISPLAY: none">
            <div class="sec_menu" style="WIDTH: 158px">
                <table cellpadding="0" cellspacing="0" align="center" width="135">
                    <tr>
                        <td height="20"><a href="edit/admin_edit.aspx" target="right">文章管理</a></td>
                    </tr>
                    <tr>
                        <td height="20"><a href="edit/edit_add.aspx" target="right">添加文章</a></td>
                    </tr>
                    <tr>
                        <td height="20"><a href="edit/edit_add_type.aspx" target="right">添加分类</a></td>
                    </tr>
                    <tr>
                        <td height="20"><a href="edit/edit_type.aspx" target="right">分类管理</a></td>
                    </tr>


                </table>
            </div>
            <br>
        </td>
    </tr>
                <tr>
                    <td class="menu_title" id="imgmenu3" onclick="showsubmenu(3)" style="cursor: hand" background="images/menudown.gif" height="25">&nbsp;<span>图片管理</span> </td>
                </tr>
                <tr>
                    <td id="submenu3" style="DISPLAY: none">
                        <div class="sec_menu" style="WIDTH: 158px">
                            <div align="left">
                                <table cellpadding="0" cellspacing="0" align="center" width="135">
                                    <tr>
                                        <td height="20"><a href="photo/admin_photo.aspx" target="right">图片管理</a></td>
                                    </tr>
                                    <tr>
                                        <td height="20"><a href="photo/photo_add.aspx" target="right">添加图片</a></td>
                                    </tr>
                                    <tr>
                                        <td height="20"><a href="photo/photo_add_type.aspx" target="right">添加分类</a></td>
                                    </tr>
                                    <tr>
                                        <td height="20"><a href="photo/photo_edit_type.aspx" target="right">分类管理</a></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <br>
                    </td>
                </tr>



                <tr>
                    <td class="menu_title" id="imgmenu9" onclick="showsubmenu(9)" style="cursor: hand" background="images/menudown.gif" height="25">&nbsp;<span>其他管理</span> </td>
                </tr>
                <tr>
                    <td id="submenu9" style="DISPLAY: none" align="left">
                        <div class="sec_menu" style="WIDTH: 158px">
                            <table cellpadding="0" cellspacing="0" align="center" width="135">

                                <tr>
                                    <td height="20"><a href="page/page_add.aspx" target="right">添加页面</a></td>
                                </tr>
                                <tr>
                                    <td height="20"><a href="page/page_edit.aspx" target="right">个人简介</a></td>
                                </tr>
                                <tr>
                                    <td height="20"><a href="admin_edit.aspx" target="right">后台管理</a></td>
                                </tr>


                            </table>
                        </div>
                        <br>
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="0" width="158" align="center">
                <tr>
                    <td align="center" valign="bottom">
                        <font face="Webdings" color="#FFFFFF" style="cursor: hand">6</font> </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="0" width="158" align="center">
                <tr>

                    <td class="menu_title" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';" background="images/title_bg_quit.gif" height="25">
                        <span>版权信息</span> </td>
                </tr>
                <tr>
                    <td>
                        <div class="sec_menu" style="WIDTH: 158px">
                            <table cellpadding="0" cellspacing="0" align="center" width="134">
                                <tr>
                                    <td height="50">
                                        <br>
                                        郑伟山
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table> 
        </div>
    </form>
</body>
</html>

