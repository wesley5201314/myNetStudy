<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_top.aspx.cs" Inherits="MyBlog.admin.admin_top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="Css_Left.css" rel="stylesheet" type="text/css">
    <script language="JavaScript" type="text/JavaScript">
        function preloadImg(src) {
            var img = new Image();
            img.src = src
        }
        preloadImg("images/close.gif");

        var displayBar = true;
        function switchBar(obj) {
            if (displayBar) {
                parent.frame.cols = "0,*";
                displayBar = false;
                obj.src = "images/open.gif";
                obj.title = "打开左边管理导航菜单";
            }
            else {
                parent.frame.cols = "180,*";
                displayBar = true;
                obj.src = "images/close.gif";
                obj.title = "关闭左边管理导航菜单";
            }
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table width="100%" height="35"  border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="30%" bgcolor="#39867B" class="top"><img onClick="switchBar(this)" src="images/close.gif" title="关闭左边管理导航菜单" style="cursor:hand"></td>
    <td width="70%" bgcolor="#39867B" class="top"><div align="right">程序维护：QQ893189117 郑伟山</div></td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
