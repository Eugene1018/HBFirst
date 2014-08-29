<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="FlowWeb.Flow.Test" %>

<html>
<head>
    <base  target="_self" />
    <title>可视化工作流 </title>
    <link rel="stylesheet" type="text/css" href="inc/style.css" />
    <link rel="stylesheet" type="text/css" href="inc/webTab/webtab.css"/>
    <script language="jscript" src="inc/function.js"></script>
    <script language="jscript" src="inc/shiftlang.js"></script>
    <script language="jscript" src="inc/webTab/webTab.js"></script>
    <style>
        body
        {
            background-color: buttonface;
            scroll: no;
            margin: 7px, 0px, 0px, 7px;
            border: none;
            overflow: hidden;
        }
    </style>
</head>
<body>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="scriptmanager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" height="385px">
                <thead>
                    <tr id="WebTab">
                        <td class="selectedtab" id="tab1" onmouseover='hoverTab("tab1")' onclick="switchTab('tab1','contents1');">
                            <span id="tabpage1">流程信息</span>
                        </td>
                        <td class="tab" id="tab2" onmouseover='hoverTab("tab2")' onclick="switchTab('tab2','contents2');">
                            <span id="tabpage2">其他流程</span>
                        </td>
                        <td class="tabspacer" width="672px">
                            &nbsp;
                        </td>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td id="contentscell" colspan="5">
                            <div class="selectedcontents" id="contents1">
                                <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="100%" valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td height="30" background="images/tab_05.gif">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="12" height="30">
                                                                    <img src="images/tab_03.gif" width="12" height="30" />
                                                                </td>
                                                                <td>
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="46%" valign="middle">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="5%">
                                                                                            <div align="center">
                                                                                                <img src="images/tb.gif" width="16" height="16" /></div>
                                                                                        </td>
                                                                                        <td width="95%" class="STYLE1">
                                                                                            <span class="STYLE3">审批意见  <asp:HiddenField ID="hddata" runat="server" /></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td width="54%">
                                                                                <table border="0" align="right" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td width="80" colspan="2" id="td_ok" runat="server" style="display:none">
                                                                                            <table width="90%" border="0" cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                    <td class="STYLE1">
                                                                                                        <div align="center">
                                                                                                            <img src="images/audit.png" alt="流程审批" style="cursor: pointer" onclick='workFlowDialog()' />
                                                                                                        </div>
                                                                                                    </td>
                                                                                                    <td class="STYLE1">
                                                                                                        <div align="center" style="cursor: pointer" onclick='workFlowDialog()'>
                                                                                                            流程审批</div>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                        <td width="80" colspan="2" id="td_not" runat="server" style="display:none">
                                                                                            <table width="90%" border="0" cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                    <td class="STYLE1">
                                                                                                        <div align="center">
                                                                                                            <img src="images/again.png" alt="修改完成" style="cursor: pointer" onclick='revisionDialog()' />
                                                                                                        </div>
                                                                                                    </td>
                                                                                                    <td class="STYLE1">
                                                                                                        <div align="center" style="cursor: pointer" onclick='revisionDialog()'>
                                                                                                            修改完成</div>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                        <td width="80" colspan="2">
                                                                                            <table width="90%" border="0" cellpadding="0" cellspacing="0">
                                                                                                <tr>
                                                                                                    <td class="STYLE1">
                                                                                                        <div align="center">
                                                                                                            <img src="images/filter.png" alt="查看流程" style="cursor: pointer" onclick='showFlowDialog()' />
                                                                                                        </div>
                                                                                                    </td>
                                                                                                    <td class="STYLE1">
                                                                                                        <div align="center" style="cursor: pointer" onclick='showFlowDialog()'>
                                                                                                            流程图例</div>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td width="16">
                                                                    <img src="images/tab_07.gif" width="16" height="30" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="8" background="images/tab_12.gif">
                                                                    &nbsp;
                                                                </td>
                                                                <td>
                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="1">
                                                                        <tr>
                                                                            <td align="left" valign="top" width="210">
                                                                                <asp:TreeView ID="tv_flow" runat="server" ShowLines="true" CssClass="panel_style"
                                                                                    Width="205px" Height="333px" SelectedNodeStyle-BackColor="LightSteelBlue" OnSelectedNodeChanged="tv_flow_SelectedNodeChanged">
                                                                                </asp:TreeView>
                                                                            </td>
                                                                            <td align="left" valign="top">
                                                                                <table width="575px" border="0" cellpadding="0" cellspacing="1" bgcolor="b5d6e6">
                                                                                    <tr>
                                                                                          <%-- <td width="3%" height="22" background="images/bg.gif" bgcolor="#FFFFFF">
                                                                                            <div align="center">
                                                                                              <input type='hidden' id='hddata' value="<%=InitUser() %>" />
                                                                                            </div>
                                                                                        </td>--%>
                                                                                        <td height="22" background="images/bg.gif" bgcolor="#FFFFFF" class="style5">
                                                                                            <div align="center">
                                                                                                <span class="STYLE1">审批人</span></div>
                                                                                        </td>
                                                                                        <td height="22" background="images/bg.gif" bgcolor="#FFFFFF" class="style5">
                                                                                            <div align="center">
                                                                                                <span class="STYLE1">审批时间</span></div>
                                                                                        </td>
                                                                                        <td height="22" background="images/bg.gif" bgcolor="#FFFFFF" class="style8">
                                                                                            <div align="center">
                                                                                                <span class="STYLE1">审批意见</span>
                                                                                            </div>
                                                                                        </td>
                                                                                        <td height="22" background="images/bg.gif" bgcolor="#FFFFFF" class="style8">
                                                                                            <div align="center">
                                                                                                <span class="STYLE1">修改意见</span>
                                                                                            </div>
                                                                                        </td>
                                                                                        <td height="22" background="images/bg.gif" bgcolor="#FFFFFF" class="style5">
                                                                                            <div align="center">
                                                                                                <span class="STYLE1">工作状态</span></div>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <%=InitHtmlData()%>
                                                                                 <%--  <tr height="310px" style="background-color: #FFFFFF">
                                                                                        <td colspan="6">
                                                                                            <asp:HiddenField ID="hddata" runat="server" />
                                                                                        </td>
                                                                                    </tr>--%>
                                                                                     <tr height="310px" style="background-color: #FFFFFF" id="td_height" runat="server">
                                                                                        <td colspan="6">
                                                                                           
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td width="8" background="images/tab_15.gif">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="35" background="images/tab_19.gif">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="12" height="35">
                                                                    <img src="images/tab_18.gif" width="12" height="35" />
                                                                </td>
                                                                <td valign="top">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 5px">
                                                                        <tr>
                                                                            <td class="STYLE4">
                                                                                <asp:Label ID="Lb_Role" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td width="16">
                                                                    <img src="images/tab_20.gif" width="16" height="35" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="contents" id="contents2">
                                <table width="100%" height="100%" style="font-size: 10pt;">
                                </table>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
<script type="text/javascript" language="javascript">

    var highlightcolor = '#c1ebff';
    //此处clickcolor只能用win系统颜色代码才能成功,如果用#xxxxxx的代码就不行,还没搞清楚为什么:(
    var clickcolor = '#51b2f6';
    function changeto() {
        source = event.srcElement;
        if (source.tagName == "TR" || source.tagName == "TABLE")
            return;
        while (source.tagName != "TD")
            source = source.parentElement;
        source = source.parentElement;
        cs = source.children;
        //alert(cs.length);
        if (cs[1].style.backgroundColor != highlightcolor && source.id != "nc" && cs[1].style.backgroundColor != clickcolor)
            for (i = 0; i < cs.length; i++) {
                cs[i].style.backgroundColor = highlightcolor;
            }
    }

    function changeback() {
        if (event.fromElement.contains(event.toElement) || source.contains(event.toElement) || source.id == "nc")
            return
        if (event.toElement != source && cs[1].style.backgroundColor != clickcolor)
        //source.style.backgroundColor=originalcolor
            for (i = 0; i < cs.length; i++) {
                cs[i].style.backgroundColor = "";
            }
    }

    function clickto() {
        source = event.srcElement;
        if (source.tagName == "TR" || source.tagName == "TABLE")
            return;
        while (source.tagName != "TD")
            source = source.parentElement;
        source = source.parentElement;
        cs = source.children;
        //alert(cs.length);
        if (cs[1].style.backgroundColor != clickcolor && source.id != "nc")
            for (i = 0; i < cs.length; i++) {
                cs[i].style.backgroundColor = clickcolor;
            }
        else
            for (i = 0; i < cs.length; i++) {
                cs[i].style.backgroundColor = "";
            }
    }
    //===========================按钮相关操作=========================================
    function workFlowDialog() {
        var id = document.all.hddata.value;
        if (id == "") {
            return;
        }
        var dialogURL = id == null ? 'FormAudit.aspx' : 'FormAudit.aspx?id=' + id;
        var dialog = window.showModalDialog(dialogURL, window, "dialogWidth:520px; dialogHeight:227px; center:yes; help:no; resizable:no; status:no;");
        if (dialog == "ok") {
           // window.location.href = window.location.href;
            // window.location.reload;
            window.returnValue = dialog;
            window.close();
        }
        return dialog;
    }

    function showFlowDialog() {
        var id = document.all.hddata.value;
        if (id == "") {
            return;
        }
        var dialogURL = 'FlowPreview.aspx?id=' + id;
        var dialog = window.showModalDialog(dialogURL, window, "dialogWidth:926px; dialogHeight:540px; center:yes; help:no; resizable:no; status:no;");
        return dialog;
    }

    function revisionDialog() {
        var id = document.all.hddata.value;
        if (id == "") {
            return;
        }
        var dialogURL = id == null ? 'Window_Revision.aspx' : 'Window_Revision.aspx?id=' + id;
        var dialog = window.showModalDialog(dialogURL, window, "dialogWidth:520px; dialogHeight:215px; center:yes; help:no; resizable:no; status:no;");
        if (dialog == "ok") {
           // window.location.href = window.location.href;
           // window.location.reload;
            window.close();
        }
        return dialog;
    }
</script>
