<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Window_RoleList.aspx.cs" Inherits="FlowWeb.SysManage.Window_RoleList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <base target="_self" />
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>���ӻ�����������</title>
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
                                                    <div align="left">
                                                        <img src="../Flow/images/tb.gif" width="16" height="16" /></div>
                                                </td>
                                                <%-- <td width="95%" class="STYLE1">
                                                    <span class="STYLE3">�㵱ǰ��λ��</span>��[���̹���]-[��������]
                                                </td>--%>
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
                                                                         <img src="../Flow/images/select.png" onclick="workFlowDialog()"  alt="ȷ��"  style="cursor: hand" />
                                                                </div>
                                                            </td>
                                                            <td class="STYLE1">
                                                                <div align="center" style="cursor: hand"  onclick="workFlowDialog()">
                                                                    ȷ��</div>
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
                             <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="b5d6e6" onmouseover="changeto()"
                                        onmouseout="changeback()">
                                        <tr>
                                            <td width="10%" height="22" background="../Flow/images/bg.gif" bgcolor="#FFFFFF">
                                                <div align="center">
                                                      <input type="checkbox" id="checkbox" value="" onclick="clickcheckboxs('checkbox')" />
                                                </div>
                                            </td>
                                            <td width="10%" height="22" background="../Flow/images/bg.gif" bgcolor="#FFFFFF">
                                                <div align="center">
                                                    <span class="STYLE1">���</span></div>
                                            </td>
                                            <td  width="15%" height="22" background="../Flow/images/bg.gif" bgcolor="#FFFFFF" class="style1">
                                                <div align="center">
                                                    <span class="STYLE1">��ɫ����</span></div>
                                            </td>
                                            <td  width="20%" height="22" background="../Flow/images/bg.gif" bgcolor="#FFFFFF" class="style2">
                                                <div align="center">
                                                    <span class="STYLE1">��ע</span></div>
                                            </td>
                                        </tr>
                                        <%=InitData()%>
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

    function workFlowDialog() {
        var cks = document.getElementsByTagName("input");
        var id = "";
        for (var i = 0; i < cks.length; i++) {
            if (cks[i].type == "checkbox" && cks[i].checked == true && cks[i].value != '') {
                id += "'" + cks[i].value + "'"+",";
                
            }
        }
        if (id == "") {
            alert('��ѡ������');
            return;
        }
        window.close();
        window.returnValue = " select  * from Sys_User where FN_RoleID IN (" + id.substring(0, id.length-1) +");";
    }

    function clickcheckboxs(obj) {
        var cks = document.getElementsByTagName("input");
        var a = document.getElementById(obj);
        for (var i = 0; i < cks.length; i++) {
            if (cks[i].type == "checkbox" && cks[i] != a) {
                cks[i].checked = a.checked;
            }
        }
    }


    var highlightcolor = '#c1ebff';
    //�˴�clickcolorֻ����winϵͳ��ɫ������ܳɹ�,�����#xxxxxx�Ĵ���Ͳ���,��û�����Ϊʲô:(
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
   
</script>