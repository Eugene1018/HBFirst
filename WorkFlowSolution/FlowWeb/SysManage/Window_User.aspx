<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Window_User.aspx.cs" Inherits="FlowWeb.SysManage.Window_User" %>

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
                                                                <div align="center" style="cursor: pointer" onclick="document.getElementById('btnOK').click();">
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
                                                        <span class="STYLE3" style="color: Green; font-family: 微软雅黑">登录名称：</span>
                                                    </td>
                                                    <td>
                                                        <%-- <asp:Label ID="Lb_LoginName" runat="server" Width="180px" BorderStyle="None" CssClass="panel_style"></asp:Label>--%>
                                                        <asp:TextBox ID="Tb_LoginName" TextMode="SingleLine" runat="server" Width="180px"
                                                            CssClass="panel_style"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr height="5">
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <span class="STYLE3" style="color: Green; font-family: 微软雅黑">登录密码：</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="Tb_LoginPwd" TextMode="Password" runat="server" Width="180px" CssClass="panel_style"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr height="5">
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <span class="STYLE3" style="color: Green; font-family: 微软雅黑">真实姓名：</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="Tb_RealName" runat="server" CssClass="panel_style" Width="180px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr height="5">
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <span class="STYLE3" style="color: Green; font-family: 微软雅黑">电 话：</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="Tb_Telphone" runat="server" Width="180px" CssClass="panel_style"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr height="5">
                                                     <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <span class="STYLE3" style="color: Green; font-family: 微软雅黑">邮 箱：</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="Tb_Email" runat="server" Width="180px" CssClass="panel_style"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr height="5">
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <span class="STYLE3" style="color: Green; font-family: 微软雅黑">是否锁定： </span>
                                                    </td>
                                                    <td>
                                                        <asp:RadioButtonList ID="Rbl_IsLock" runat="server" RepeatDirection="Horizontal"
                                                            CssClass="panel_style" BorderStyle="None">
                                                            <asp:ListItem Text="否" Value="0" Selected="True"></asp:ListItem>
                                                            <asp:ListItem Text="是" Value="1"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr height="5">
                                                     <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <span class="STYLE3" style="color: Green; font-family: 微软雅黑;">角色设定： </span>
                                                    </td>
                                                    <td>
                                                        <asp:ListBox ID="Lb_Role" runat="server" CssClass="panel_style" Width="180px" Height="200">
                                                        </asp:ListBox>
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
    </form>
</body>
</html>
<script type="text/javascript" language="javascript">
    function saveBtn() {
        if (document.all.Tb_LoginName.value.trim() == '') {
            alert('登录名称为空，不能执行此操作！');
            return false;
        } else if (document.all.Tb_LoginPwd.value.trim() == '') {
            alert('登录密码为空，不能执行此操作！');
            return false;
        } else if (document.all.Lb_Role.value.trim() == '') {
            alert('角色信息为空，不能执行此操作！');
            return false;
        }
        //return true;
    }
    String.prototype.trim = function () {
        return this.replace(/(^\s*)|(\s*$)/g, "");
    }
</script>
