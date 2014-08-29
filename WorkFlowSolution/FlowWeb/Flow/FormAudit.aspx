<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormAudit.aspx.cs" Inherits="FlowWeb.Flow.FormAudit" %>

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
    <link href="inc/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        function workFlowDialog(page, id, width, height) {
            var dialogURL = id == null ? page : page + '?id=' + id;
            var dialog = window.showModalDialog(dialogURL, window, "dialogWidth:" + width + "px; dialogHeight:" + height + "px; center:yes; help:no; resizable:no; status:no;");
            if (dialog == "ok") {
                window.returnValue = dialog;
                window.close();
            }
            return dialog;
        }
    </script>
</head>
<body>
    <form id="Form1" runat="server">
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
                                                    <div align="left">
                                                        <img src="images/tb.gif" width="16" height="16" /></div>
                                                </td>
                                                <%-- <td width="95%" class="STYLE1">
                                                    <span class="STYLE3">你当前的位置</span>：[流程管理]-[流程审批]
                                                </td>--%>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="54%">
                                        <table border="0" align="right" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <%--<td width="60">
                                                    <table width="90%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="STYLE1">
                                                                <div align="center">
                                                                    <img src="images/zoom.png" width="18" alt="发起" height="18" style="cursor: hand" /></div>
                                                            </td>
                                                            <td class="STYLE1">
                                                                <div align="center" style="cursor: hand">
                                                                    预览</div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>--%>
                                                <%-- <td width="60">
                                                    <table width="90%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="STYLE1">
                                                                <div align="center">
                                                                    <asp:ImageButton ID="btnSubmit" runat="server" ToolTip="确定" ImageUrl="images/select.png"
                                                                        OnClick="btnSubmit_Click" />
                                                                </div>
                                                            </td>
                                                            <td class="STYLE1">
                                                                <div align="center" style="cursor: hand" onclick="document.getElementById('btnSubmit').click();">
                                                                    确定</div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>--%>
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
                            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="b5d6e6">
                                <tr>
                                    <td width="100%" bgcolor="#FFFFFF">
                                        <div style="text-align: left; vertical-align: top">
                                            <table border="0">
                                                <tr>
                                                    <td>
                                                        <span class="STYLE3" style="color: Green; font-family: 微软雅黑">办理意见: </span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="Tb_HandleView" runat="server" TextMode="MultiLine" Width="432px"
                                                            Height="120px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <span class="STYLE3" style="color: Green; font-family: 微软雅黑">基本操作: </span>
                                                    </td>
                                                    <td>
                                                        <%--   <asp:RadioButtonList ID="Rbl_State" runat="server" BorderStyle="None" BorderWidth="1px"
                                                            CssClass="panel_style" RepeatDirection="Horizontal" Height="26px">
                                                            <asp:ListItem Text="审批通过" Value="2" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="退回修改" Value="3"></asp:ListItem>
                                                        </asp:RadioButtonList>--%>
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td class="STYLE1">
                                                                    <div align="center">
                                                                        <asp:ImageButton ID="btnSubmit" runat="server" ToolTip="审批通过" ImageUrl="images/select.png"
                                                                            OnClick="btnOperate_Click" />
                                                                    </div>
                                                                </td>
                                                                <td class="STYLE1">
                                                                    <div align="center" style="cursor: hand" onclick="document.getElementById('btnSubmit').click();">
                                                                        审批通过</div>
                                                                </td>
                                                                <td width="10px">
                                                                &nbsp;&nbsp;&nbsp;
                                                                </td>
                                                                <td class="STYLE1">
                                                                    <div align="center">
                                                                        <asp:ImageButton ID="btnBack" runat="server" ToolTip="退回修改" ImageUrl="images/back.png"
                                                                            OnClick="btnOperate_Click" />
                                                                    </div>
                                                                </td>
                                                                <td class="STYLE1">
                                                                    <div align="center" style="cursor: hand" onclick="document.getElementById('btnBack').click();">
                                                                        退回修改</div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
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
                            <img src="images/tab_20.gif" width="16" height="35" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
