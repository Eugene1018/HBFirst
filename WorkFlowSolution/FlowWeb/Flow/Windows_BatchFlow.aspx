<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Windows_BatchFlow.aspx.cs"
    Inherits="FlowWeb.Flow.Windows_BatchFlow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base target="_self" />
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
        -->
    </style>
    <link href="../Flow/inc/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="updatePanel1"  runat="server">
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
                                                    <%-- <span class="STYLE3">你当前的位置</span>：[系统管理]-[角色管理]--%>
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
                                                                    <asp:ImageButton ID="btnOK" runat="server" ToolTip="确定" Width="16" Height="16" ImageUrl="../Flow/images/save.gif"
                                                                        OnClick="btnOK_Click" OnClientClick="return saveBtn()" />
                                                                </div>
                                                            </td>
                                                            <td class="STYLE1">
                                                                <div align="center" style="cursor: pointer" onclick="document.getElementById('btnOK').click()">
                                                                    确定</div>
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
                                                        <asp:TreeView ID="tv_flow"  runat="server" ShowLines="true" 
                                                            CssClass="panel_style" Height="219px" Width="285px"  SelectedNodeStyle-BackColor="LightSteelBlue"
                                                            onselectednodechanged="tv_flow_SelectedNodeChanged" >
                                                        </asp:TreeView>
                                                    </td>
                                                </tr>
                                                <tr height="10">
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <span class="STYLE3" style="color: Green; font-family: 微软雅黑">流程名称 </span>
                                                        <br />
                                                        <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td style="margin-right: 100">
                                                                    <asp:TextBox ID="Tb_FlowName" runat="server" Width="240px" CssClass="panel_style" ReadOnly="true"></asp:TextBox>
                                                                    <asp:HiddenField ID="Tb_FlowNameValue" runat="server"  />
                                                                </td>
                                                                <td class="STYLE1">
                                                                    <div align="center">
                                                                        <asp:ImageButton ID="btnPreview" runat="server" ToolTip="预览" Width="18" Height="18"
                                                                            ImageUrl="images/zoom.png" OnClick="btnPreview_Click" />
                                                                    </div>
                                                                </td>
                                                                <td class="STYLE1">
                                                                    <div align="center" style="cursor: pointer" onclick="document.getElementById('btnPreview').click()">
                                                                        预览</div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>

                                                <tr height="10">
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <span class="STYLE3" style="color: Green; font-family: 微软雅黑"><asp:Label ID="Lb_Step" runat="server"></asp:Label> <asp:HiddenField ID="Lb_StepValue" runat="server"  /></span>
                                                        <br />
                                                       
                                                          <table border="0" width="100%" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td style="margin-right: 100">
                                                                    <asp:TextBox ID="Tb_FlowPeople" runat="server" Width="240px" CssClass="panel_style" ReadOnly="true"></asp:TextBox>
                                                                    <asp:HiddenField ID="Tb_FlowPeopleValue" runat="server"  />
                                                                </td>
                                                                <td class="STYLE1">
                                                                    <div align="center">
                                                                        <asp:ImageButton ID="btnSelect" runat="server" ToolTip="选择"  
                                                                            ImageUrl="images/select.gif" OnClick="btnSelect_Click" OnClientClick="return checkPeople()" />
                                                                    </div>
                                                                </td>
                                                                <td class="STYLE1">
                                                                    <div align="center" style="cursor: pointer" onclick="document.getElementById('btnSelect').click();">
                                                                        选择</div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>

                                                 <tr height="10">
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <span class="STYLE3" style="color: Green; font-family: 微软雅黑">发起方式 </span>
                                                        <br />
                                                        <asp:RadioButtonList ID="Rbl_Type" runat="server" BorderStyle="None" BorderWidth="1px"
                                                            CssClass="panel_style" RepeatDirection="Horizontal" Height="26px">
                                                            <asp:ListItem Text="逐条发起" Value="1" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="打包发起" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
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
    SetTreeNodeClickHander("tv_flow");
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
    function preFlowDialog(page, id, width, height) {
        var dialogURL = id == null ? page : page + '?id=' + id;
        var dialog = window.showModalDialog(dialogURL, window, "dialogWidth:" + width + "px; dialogHeight:" + height + "px; center:yes; help:no; resizable:no; status:no;");
        return dialog;
    }
    function checkPeople() {
        if (document.all.Tb_FlowPeopleValue.value != '') {
            alert('当人员为空时，才能执行此操作！');
            return false;
        }
    }
    function selectUserDialog(page, id, width, height) {
        var dialogURL = page;
        var dialog = window.showModalDialog(dialogURL, window, "dialogWidth:" + width + "px; dialogHeight:" + height + "px; center:yes; help:no; resizable:no; status:no;");
        if (dialog != '' && typeof (dialog) != "undefined") {
            document.all.Tb_FlowPeople.value = dialog.split('|')[0];
            document.all.Tb_FlowPeopleValue.value = dialog.split('|')[1];
        }
    }
    function saveBtn() {
        if (document.all.Tb_FlowName.value.trim() == '') {
            alert('流程为空，不能执行此操作！');
            return false;
        }
        if (document.all.Tb_FlowPeople.value.trim() == '') {
            alert('人员为空，不能执行此操作！');
            return false;
        }       
    }
</script>
