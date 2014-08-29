<%@ Page Language="C#" AutoEventWireup="true" Inherits="FlowWeb.Login" CodeBehind="Login.aspx.cs" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>可视化工作流后台管理</title>
    <style type="text/css">
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            background-color: #016aa9;
            overflow: hidden;
        }
        .STYLE1
        {
            color: #000000;
            font-size: 12px;
        }
        .btn_Sub
        {
            margin-left: 3px;
            margin-top: 3px;
        }
        -- ></style>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" style="vertical-align: middle">
        <tr>
            <td>
                <table width="962" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="235" background="Main/images/login_03.gif">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td height="53">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="394" height="53" background="Main/images/login_05.gif">
                                        &nbsp;
                                    </td>
                                    <td width="206" background="Main/images/login_06.gif">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="16%" height="25">
                                                    <div align="right">
                                                        <span class="STYLE1">用户</span></div>
                                                </td>
                                                <td width="57%" height="25">
                                                    <div align="center">
                                                        <asp:TextBox ID="txt_UserName" Style="width: 105px; height: 17px; background-color: #292929;
                                                            border: solid 1px #7dbad7; font-size: 12px; color: #6cd0ff" runat="server"></asp:TextBox>
                                                    </div>
                                                </td>
                                                <td width="27%" height="25">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="25">
                                                    <div align="right">
                                                        <span class="STYLE1">密码</span></div>
                                                </td>
                                                <td height="25">
                                                    <div align="center">
                                                        <asp:TextBox ID="txt_UserPwd" Style="width: 105px; height: 17px; background-color: #292929;
                                                            border: solid 1px #7dbad7; font-size: 12px; color: #6cd0ff" runat="server" TextMode="Password"></asp:TextBox>
                                                    </div>
                                                </td>
                                                <td height="25">
                                                    <div align="left">
                                                        <asp:Button runat="server" BackColor="#292929" BorderStyle="None" BorderWidth="0"
                                                            BorderColor="#292929" ForeColor="White" Text="登录" Width="50px" ID="btn_Sub" OnClick="btn_Sub_Click"
                                                            CssClass="btn_Sub" OnClientClick="return checkBox()"></asp:Button>
                                                        <script language="javascript" type="text/javascript">
                                                            function checkBox() {
                                                                var name = document.getElementById("txt_UserName").value;
                                                                var pwd = document.getElementById("txt_UserPwd").value;
                                                                if (name.trim() == '') {
                                                                    alert('请输入登录名称！');
                                                                    return false
                                                                }
                                                                if (pwd.trim() == '') {
                                                                    alert('请输入密码！');
                                                                    return false;
                                                                }
                                                            }
                                                            String.prototype.trim = function () {
                                                                return this.replace(/(^\s*)|(\s*$)/g, "");
                                                            }
                                                        </script>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="362" background="Main/images/login_07.gif">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="213" background="Main/images/login_08.gif">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
