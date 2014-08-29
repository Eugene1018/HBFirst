<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Window_BackStep.aspx.cs" Inherits="FlowWeb.Flow.Window_BackStep" %>

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
        .style1
        {
            width: 252px;
        }
        -->
    </style>
    <link href="inc/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="scriptmanager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>
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
                                                            <span class="STYLE3"><span class="STYLE3" style="color: Red; font-family: 微软雅黑">
                                                                <asp:Label ID="lblFlowText" runat="server">修改完成后提交的节点</asp:Label>
                                                            </span></span>
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
                                                                            <asp:ImageButton ID="btnOK" runat="server" ToolTip="确定" Width="16" Height="16" ImageUrl="images/save.gif"
                                                                                OnClick="btnOK_Click" OnClientClick="return GetOption();" />
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
                                                    <table border="0" style="width: 438px">
                                                        <tr>
                                                            <td>
                                                                <asp:ListBox ID="NextStepList" runat="server" Width="200px" Height="200px" Style="font-family: 微软雅黑;
                                                                    color: Blue;" SelectionMode="Single"  
                                                                    ondblclick="ChangeItem('btnNextStepList')" ></asp:ListBox>
                                                            </td>
                                                            <td>
                                                                <div align="center">
                                                                    <asp:ImageButton ID="btnNextStepList" runat="server" ToolTip="选择步骤" ImageUrl="images/right.png"
                                                                        OnClick="btnNextStepList_Click" /><br />
                                                                    <asp:ImageButton ID="btnNextStepSelectedList" runat="server" ToolTip="选择步骤" ImageUrl="images/left.png"
                                                                        OnClick="btnNextStepSelectedList_Click" />
                                                                </div>
                                                            </td>
                                                            <td class="style1">
                                                                <asp:ListBox ID="NextStepSelectedList" runat="server" Width="200px" Height="200px"
                                                                    Style="font-family: 微软雅黑; color: Blue;" SelectionMode="Single" 
                                                                    ondblclick="ChangeItem('btnNextStepSelectedList')"></asp:ListBox>
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
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
    function ChangeItem(btn) {
        document.getElementById(btn).click();
    }
    function GetOption() {
        var rs = document.getElementById("<%=NextStepSelectedList.ClientID %>").options;
        if (rs.length == 0) {
            alert('先选择修改完成后提交的节点！');
            return false;
        }
        return true;
    }
</script>

