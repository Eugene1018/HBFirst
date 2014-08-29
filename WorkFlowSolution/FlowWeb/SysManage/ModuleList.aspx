<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModuleList.aspx.cs" Inherits="FlowWeb.SysManage.ModuleList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>可视化工作流管理</title>
    <style type="text/css">
        <!--
        body {
	        margin-left: 0px;
	        margin-top: 0px;
	        margin-right: 0px;
	        margin-bottom: 0px;
        }
        .STYLE1 {font-size: 12px}
        .STYLE3 {font-size: 12px; font-weight: bold; }
        .STYLE4 {
	        color: #03515d;
	        font-size: 12px;
        }
        .style1
        {
            width: 8%;
        }
        .style2
        {
            width: 10%;
        }
        .style4
        {
            width: 6%;
        }
        -->
    </style>
    <link href="../Flow/inc/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="scriptmanager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="30" background="../Flow/images/tab_05.gif">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="12" height="30">
                                    <img src="../Flow/images/tab_03.gif" width="12" height="30" />
                                </td>
                                <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="46%" valign="middle">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="5%">
                                                            <div align="center">
                                                                <img src="../Flow/images/tb.gif" width="16" height="16" /></div>
                                                        </td>
                                                        <td width="95%" class="STYLE1">
                                                            <span class="STYLE3">你当前的位置</span>：[系统管理]-[模块管理]
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="54%">
                                                <table border="0" align="right" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="60">
                                                            <table width="90%" border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td class="STYLE1">
                                                                        <div align="center">
                                                                            <img src="../Flow/images/22.gif" width="14" alt="新增" height="14" onclick="workFlowDialog(0)"
                                                                                style="cursor: hand" /></div>
                                                                    </td>
                                                                    <td class="STYLE1">
                                                                        <div align="center" style="cursor: hand" onclick="workFlowDialog(0)">
                                                                            新增</div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td width="52">
                                                            <table width="88%" border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td class="STYLE1">
                                                                        <div align="center">
                                                                            <img src="../Flow/images/33.gif" width="14" height="14" alt="修改" style="cursor: hand"
                                                                                onclick="workFlowDialog(1)" />
                                                                        </div>
                                                                    </td>
                                                                    <td class="STYLE1">
                                                                        <div align="center" style="cursor: hand" onclick="workFlowDialog(1)">
                                                                            修改</div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td width="52">
                                                            <table width="88%" border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td class="STYLE1">
                                                                        <div align="center">
                                                                            <img src="../Flow/images/11.gif" width="14" height="14" alt="删除" style="cursor: hand"
                                                                                onclick="workFlowDialog(2)" />
                                                                        </div>
                                                                    </td>
                                                                    <td class="STYLE1">
                                                                        <div align="center" style="cursor: hand" onclick="workFlowDialog(2)">
                                                                            删除</div>
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
                                    <img src="../Flow/images/tab_07.gif" width="16" height="30" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="8" background="../Flow/images/tab_12.gif">
                                    &nbsp;
                                </td>
                                <td>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="b5d6e6">
                                        <tr>
                                            <td width="100%" bgcolor="#FFFFFF">
                                                <div style="text-align: left; vertical-align: top">
                                                    <table border="0">
                                                        <tr>
                                                            <td>
                                                                <asp:TreeView ID="tv_menu" ShowCheckBoxes="Leaf" runat="server" ShowLines="true">
                                                                </asp:TreeView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="8" background="../Flow/images/tab_15.gif">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="35" background="../Flow/images/tab_19.gif">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="12" height="35">
                                    <img src="../Flow/images/tab_18.gif" width="12" height="35" />
                                </td>
                                <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="STYLE4">
                                                &nbsp;&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="16">
                                    <img src="../Flow/images/tab_20.gif" width="16" height="35" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
<script type="text/javascript" language="javascript">
    SetTreeNodeClickHander("tv_menu");
    function workFlowDialog(op) {
        var id = "";
        if (op != "0") {
            var cks = document.all.tv_menu.getElementsByTagName("input");
            for (var i = 0; i < cks.length; i++) {
                if (cks[i].checked == true && cks[i].value != '') {
                    s = cks[i].nextSibling.href
                    if (s.indexOf("\\") == -1) {
                        s = s.substr(0, s.lastIndexOf("'"))
                        s = s.substr(s.lastIndexOf("'") + 2)
                    }
                    else {
                        s = s.substr(s.lastIndexOf("\\") + 1, s.lastIndexOf("'") - s.lastIndexOf("\\") - 1) 
                    }
                    id = s;
                    break;
                }
            }
            if (id == "") {
                alert('未选择模块信息，不能执行此操作！');
                return false;
            }
        }
        if (op == "2" && !confirm('确认删除改数据吗？')) {
            return;
        }
        var dialog = 'Window_Module.aspx?op=' + op;
        var dialogURL = id == "" ? dialog : dialog + '&id=' + id;
        if (op == 1 || op == 0) {
            //修改、新增
            dialog = window.showModalDialog(dialogURL, window, "dialogWidth:352px; dialogHeight:377px; center:yes; help:no; resizable:no; status:no;");
        } else {
            //删除
            dialog = window.showModalDialog(dialogURL, window, "dialogWidth:0px; dialogHeight:0px; center:yes; help:no; resizable:no; status:no;");
        }
        if (dialog == "ok") {
            window.location.href = window.location.href;
            window.location.reload;
        }
        return dialog;
    }

    function TreeSingleSelect(treeID, checkNode) {
        if (!treeID)
            return;
        var objs = document.getElementsByTagName("input");
        for (var i = 0; i < objs.length; i++) {
            if (objs[i].type == 'checkbox') {
                var obj = objs[i];
                if (obj.id.indexOf(treeID) != -1) {
                    if (obj != checkNode) {
                        obj.checked = false;
                    }
                }
            }
        }
    }
    function SetTreeNodeClickHander(treeID) {
        var objs = document.getElementsByTagName("input");
        for (var i = 0; i < objs.length; i++) {
            if (objs[i].type == 'checkbox') {
                var obj = objs[i];
                if (obj.id.indexOf(treeID) != -1) {
                    objs[i].onclick = function () { TreeSingleSelect(treeID, this); };
                }
            }
        }
    }
</script>
