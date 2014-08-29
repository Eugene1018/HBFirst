<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowPreview.aspx.cs" Inherits="FlowWeb.Flow.FlowPreview" %>

<html xmlns:v="urn:schemas-microsoft-com:vml">
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
    <script src="inc/contextMenu/context.js" charset="gb2312" language="javascript" type="text/javascript"></script>
    <script src="inc/webflowbyred.js" charset="gb2312" language="javascript" type="text/javascript"></script>
    <script src="inc/function.js" charset="gb2312" language="javascript" type="text/javascript"></script>
    <script src="inc/shiftlang.js" charset="gb2312" language="javascript" type="text/javascript"></script>
    <script src="inc/movestep.js" charset="gb2312" language="javascript" type="text/javascript"></script>
    <style>
        v\:*
        {
            behavior: url(#default#VML);
        }
    </style>
</head>
<body scroll="auto">
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
                                                    <div align="center">
                                                        <img src="images/tb.gif" width="16" height="16" /></div>
                                                </td>
                                                <td width="95%" class="STYLE1">
                                                    <span class="STYLE3">流程预览</span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="54%">
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
                                    <td bgcolor="#FFFFFF" width="940px" height="465">
                                        <div style="text-align: left; vertical-align: top">
                                            <table border="0" height="465">
                                                <tr>
                                                    <td>
                                                        <input type="hidden" name="FlowXML" onpropertychange='if(AUTODRAW) redrawVML();'>
                                                        <v:group id="FlowVML" style="left: 5; top: 40; width: 925px; height: 460px; position: absolute;"
                                                            coordsize="2000,2000">
                                                        </v:group>
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

