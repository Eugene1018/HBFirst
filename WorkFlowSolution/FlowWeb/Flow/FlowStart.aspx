<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowStart.aspx.cs" ValidateRequest="false"
    Inherits="FlowWeb.Flow.FlowStart" %>

<html xmlns:v="urn:schemas-microsoft-com:vml">
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
        -->
    </style>
    <link href="inc/style.css" rel="stylesheet" type="text/css" />
    <script src="inc/contextMenu/context.js" charset="gb2312" language="javascript" type="text/javascript"></script>
    <script src="inc/webflow.js" charset="gb2312" language="javascript" type="text/javascript"></script>
    <script src="inc/function.js" charset="gb2312" language="javascript" type="text/javascript"></script>
    <script src="inc/shiftlang.js" charset="gb2312" language="javascript" type="text/javascript"></script>
    <script src="inc/movestep.js" charset="gb2312" language="javascript" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
<!--
        //自动取得浏览器语言
        var LANG = navigator.browserLanguage;
        if (LANG.indexOf('en') > -1) {
            LANG = 'en';
        }
        if (LANG.indexOf('zh') > -1) {
            LANG = 'zh';
        }
//-->
    </script>
    <style>
        v\:*
        {
            behavior: url(#default#VML);
        }
    </style>
</head>
<body onload='shiftLanguage(LANG,"main");document.title+=" Build "+document.lastModified;'
    oncontextmenu="cleancontextMenu();return false;" scroll="auto">
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
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
                                                    <span class="STYLE3">你当前的位置</span>：[流程管理]-[流程配置]
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
                                                                    <img src="images/22.gif" width="14" alt="新增" height="14" onclick='newFlow()' style="cursor: hand" /></div>
                                                            </td>
                                                            <td class="STYLE1">
                                                                <div align="center" onclick='newFlow()' style="cursor: hand">
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
                                                                    <img src="images/33.gif" width="14" height="14" alt="修改" onclick='editFlow()' style="cursor: hand" />
                                                                </div>
                                                            </td>
                                                            <td class="STYLE1">
                                                                <div align="center" onclick='editFlow()' style="cursor: hand">
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
                                                                    <asp:ImageButton ID="btnDelete" runat="server" ToolTip="删除" Width="14" Height="14"
                                                                        ImageUrl="images/11.gif" OnClick="btnDelete_Click" OnClientClick="return  judgeXml()" />
                                                                </div>
                                                            </td>
                                                            <td class="STYLE1">
                                                                <div align="center" onclick='document.getElementById("btnDelete").click()' style="cursor: hand">
                                                                    删除</div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="52">
                                                    <table width="88%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="STYLE1">
                                                                <div align="center">
                                                                    <asp:ImageButton ID="btnSave" runat="server" ToolTip="保存" Width="14" Height="14"
                                                                        ImageUrl="images/save.gif" OnClick="btnSave_Click" OnClientClick="return judgeXml()" /></div>
                                                            </td>
                                                            <td class="STYLE1">
                                                                <div align="center" onclick='document.getElementById("BtnSave").click()' style="cursor: hand">
                                                                    保存</div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="52">
                                                    <table width="88%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="STYLE1">
                                                                <div align="center">
                                                                    <img src="inc/images/saveflow.gif" width="14" height="14" onclick="exportFlow()"
                                                                        style="cursor: hand" /></div>
                                                            </td>
                                                            <td class="STYLE1">
                                                                <div align="center" onclick="exportFlow()" style="cursor: hand">
                                                                    导出</div>
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
                            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="b5d6e6">
                                <tr>
                                    <td width="100%" bgcolor="#FFFFFF">
                                        <div style="text-align: left; vertical-align: top">
                                            <input type="hidden" name="FlowXML" onpropertychange='if(AUTODRAW) redrawVML();'>
                                            <table border="0">
                                                <tr>
                                                    <td width="170" valign="top">
                                                        <table width="100%" height="465" cellspacing="0" cellpadding="0" class="panel_style">
                                                            <tr height="20">
                                                                <td width="" align="center" style="background-color: buttonface" colspan="2">
                                                                    <div id="Div1">
                                                                        流程信息</div>
                                                                </td>
                                                            </tr>
                                                            <tr height="1">
                                                                <td colspan="2" class="panel_line">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="100%" bgcolor="white">
                                                                    <table width="" height="" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td height="5" colspan="3">
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="0">
                                                                            </td>
                                                                            <td valign="top" align="left" height="415">
                                                                                <asp:TreeView ID="tv_flow" runat="server" ShowLines="true" OnSelectedNodeChanged="tv_flow_SelectedNodeChanged">
                                                                                </asp:TreeView>
                                                                                <div>
                                                                                    <iframe id="web" src="about:blank" style="display: none"></iframe>
                                                                                </div>
                                                                                <br>
                                                                            </td>
                                                                            <td width="0">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr height="1">
                                                                <td colspan="2" class="panel_line">
                                                                </td>
                                                            </tr>
                                                            <tr height="22">
                                                                <td colspan="2" align="center" style="background-color: buttonface">
                                                                    <div id="treeText">
                                                                        <font size="medium" color="-webkit-text"></font>可视化工作流—导航视图</div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="8">
                                                    </td>
                                                    <td width="930px" height="465">
                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                            <ContentTemplate>
                                                                <table cellspacing="0" cellpadding="0" class="panel_style" width="100%" height="100%">
                                                                    <tr>
                                                                        <td colspan="2" width="100%" height="100%" onclick="cleancontextMenu();return false;"
                                                                            oncontextmenu='flowContextMenu();return false;' valign="top" align="left">
                                                                            <v:group id="FlowVML" style="left: 200; top: 40; width: 925px; height: 460px; position: absolute;"
                                                                                coordsize="2000,2000">
                                                                            </v:group>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="tv_flow" />
                                                                <asp:PostBackTrigger ControlID="btnSave" />
                                                                <asp:PostBackTrigger ControlID="btnDelete" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
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
