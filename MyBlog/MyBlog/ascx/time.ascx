<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="time.ascx.cs" Inherits="MyBlog.ascx.time" %>
<style>
    A.menuitem {
        COLOR: menutext;
        TEXT-DECORATION: none;
    }

        A.menuitem:hover {
            COLOR: highlighttext;
            BACKGROUND-COLOR: highlight;
        }

    DIV.contextmenu {
        BORDER-RIGHT: 2px outset;
        BORDER-TOP: 2px outset;
        Z-INDEX: 999;
        VISIBILITY: hidden;
        BORDER-LEFT: 2px outset;
        BORDER-BOTTOM: 2px outset;
        POSITION: absolute;
        BACKGROUND-COLOR: buttonface;
    }
</style>
<h3>资源列表</h3>
<table>
    <tr>
        <th rowspan="4">
        <td>
            <script language="JavaScript">
                function Year_Month() {
                    var now = new Date();
                    var yy = now.getFullYear();
                    var mm = now.getMonth() + 1;
                    var cl = '<font color="#0000df">';
                    if (now.getDay() == 0) cl = '<font color="#c00000">';
                    if (now.getDay() == 6) cl = '<font color="#00c000">';
                    return (cl + yy + '年' + mm + '月</font>');
                }
                function Date_of_Today() {
                    var now = new Date();
                    var cl = '<font color="#ff0000">';
                    if (now.getDay() == 0) cl = '<font color="#c00000">';
                    if (now.getDay() == 6) cl = '<font color="#00c000">';
                    return (cl + now.getDate() + '</font>');
                }
                function Day_of_Today() {
                    var day = new Array();
                    day[0] = "星期日";
                    day[1] = "星期一";
                    day[2] = "星期二";
                    day[3] = "星期三";
                    day[4] = "星期四";
                    day[5] = "星期五";
                    day[6] = "星期六";
                    var now = new Date();
                    var cl = '<font color="#0000df">';
                    if (now.getDay() == 0) cl = '<font color="#c00000">';
                    if (now.getDay() == 6) cl = '<font color="#00c000">';
                    return (cl + day[now.getDay()] + '</font>');
                }
                function CurentTime() {
                    var now = new Date();
                    var hh = now.getHours();
                    var mm = now.getMinutes();
                    var ss = now.getTime() % 60000;
                    ss = (ss - (ss % 1000)) / 1000;
                    var clock = hh + ':';
                    if (mm < 10) clock += '0';
                    clock += mm + ':';
                    if (ss < 10) clock += '0';
                    clock += ss;
                    return (clock);
                }
                function refreshCalendarClock() {
                    document.all.calendarClock1.innerHTML = Year_Month();
                    document.all.calendarClock2.innerHTML = Date_of_Today();
                    document.all.calendarClock3.innerHTML = Day_of_Today();
                    document.all.calendarClock4.innerHTML = CurentTime();
                }
                var webUrl = webUrl;
                document.write('<table border="" cellpadding="0" cellspacing="0" bgcolor="#000000" ><tr><td>');
                document.write('<table id="CalendarClockFreeCode" border="0" cellpadding="0" cellspacing="0" width="60" height="70" ');
                document.write('style="position:absolute;visibility:hidden" bgcolor="#eeeeee">');
                document.write('<tr><td align="center"><font ');
                document.write('style="cursor:hand;color:#ff0000;font-family:宋体;font-size:14pt;line-height:120%" ');
                if (webUrl != 'netflower') {
                    document.write('</td></tr><tr><td align="center"><font ');
                    document.write('style="cursor:hand;color:#2000ff;font-family:宋体;font-size:9pt;line-height:110%" ');
                }
                document.write('</td></tr></table>');
                document.write('<table border="0" cellpadding="0" cellspacing="0" width="61" bgcolor="#C0C0C0" height="70">');
                document.write('<tr><td valign="top" width="100%" height="100%">');
                document.write('<table border="1" cellpadding="0" cellspacing="0" width="58" bgcolor="#FEFEEF" height="67">');
                document.write('<tr><td align="center" width="100%" height="100%" >');
                document.write('<font id="calendarClock1" style="font-family:宋体;font-size:7pt;line-height:120%"> </font><br>');
                document.write('<font id="calendarClock2" style="color:#ff0000;font-family:Arial;font-size:14pt;line-height:120%"> </font><br>');
                document.write('<font id="calendarClock3" style="font-family:宋体;font-size:9pt;line-height:120%"> </font><br>');
                document.write('<font id="calendarClock4" style="color:#100080;font-family:宋体;font-size:8pt;line-height:120%"><b> </b></font>');
                document.write('</td></tr></table>');
                document.write('</td></tr></table>');
                document.write('</td></tr></table>');
                setInterval('refreshCalendarClock()', 1000);
            </script>
        </td>
        <td valign="top">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="White"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Label" ForeColor="White"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Label" ForeColor="White"></asp:Label></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
