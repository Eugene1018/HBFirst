<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlowTest.aspx.cs" Inherits="FlowWeb.Flow.FlowTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
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
                                                    <span class="STYLE3">�㵱ǰ��λ��</span>��[���̹���]-[���̲���]
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="54%">
                                        <table border="0" align="right" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="90">
                                                    <table width="90%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="STYLE1">
                                                                <div align="center">
                                                                    <input type="checkbox" id="checkboxall" value="" onclick="clickcheckboxs('checkboxall')" />
                                                                </div>
                                                            </td>
                                                            <td class="STYLE1">
                                                                <div align="center" style="cursor: pointer">
                                                                    ȫѡ|��ѡ</div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="80" colspan="2">
                                                    <table width="90%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="STYLE1">
                                                                <div align="center">
                                                                    <img src="images/tick.png" width="14" height="14" alt="��������" style="cursor: pointer"
                                                                        onclick='workFlowDialog()' />
                                                                </div>
                                                            </td>
                                                            <td class="STYLE1">
                                                                <div align="center" style="cursor: pointer" onclick='workFlowDialog()'>
                                                                    ��������</div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="80" colspan="2">
                                                    <table width="90%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="STYLE1">
                                                                <div align="center">
                                                                    <img src="images/refuse.png" width="14" height="16" alt="��������" style="cursor: pointer"
                                                                        onclick='refuseDialog()' />
                                                                </div>
                                                            </td>
                                                            <td class="STYLE1">
                                                                <div align="center" style="cursor: pointer" onclick='refuseDialog()'>
                                                                    ��������</div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="80" colspan="2">
                                                    <table width="90%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="STYLE1">
                                                                <div align="center">
                                                                    <img src="images/filter.png" alt="�鿴����" style="cursor: pointer" onclick='showFlowDialog()' />
                                                                </div>
                                                            </td>
                                                            <td class="STYLE1">
                                                                <div align="center" style="cursor: pointer" onclick='showFlowDialog()'>
                                                                    �鿴����</div>
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
                            <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="b5d6e6" onmouseover="changeto()"
                                onmouseout="changeback()" ondblclick="clickto()">
                                <tr>
                                    <td width="3%" height="22" background="images/bg.gif" bgcolor="#FFFFFF">
                                        <div align="center">
                                            <input type="checkbox" id="checkbox" value="" onclick="clickcheckboxs('checkbox')" />
                                        </div>
                                    </td>
                                    <td width="3%" height="22" background="images/bg.gif" bgcolor="#FFFFFF">
                                        <div align="center">
                                            <span class="STYLE1">���</span></div>
                                    </td>
                                    <td width="12%" height="22" background="images/bg.gif" bgcolor="#FFFFFF">
                                        <div align="center">
                                            <span class="STYLE1">���պ���</span></div>
                                    </td>
                                    <td width="14%" height="22" background="images/bg.gif" bgcolor="#FFFFFF">
                                        <div align="center">
                                            <span class="STYLE1">����ʱ��</span></div>
                                    </td>
                                    <td width="18%" background="images/bg.gif" bgcolor="#FFFFFF">
                                        <div align="center">
                                            <span class="STYLE1">�ʼ���ַ</span></div>
                                    </td>
                                    <td width="23%" height="22" background="images/bg.gif" bgcolor="#FFFFFF">
                                        <div align="center">
                                            <span class="STYLE1">����</span></div>
                                    </td>
                                    <td width="15%" height="22" background="images/bg.gif" bgcolor="#FFFFFF" class="STYLE1">
                                        <div align="center">
                                            <span class="STYLE1">��������</span>
                                        </div>
                                    </td>
                                </tr>
                                <%=InitData()%>
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
<script type="text/javascript" language="javascript">
    function workFlowDialog() {
        //var cks = document.getElementsByTagName("input");
        var cks = document.all.checkboxid;
        var id = "";
        for (var i = 0; i < cks.length; i++) {
            if (cks[i].type == "checkbox" && cks[i].checked == true && cks[i].value != '') {
                id += cks[i].value + "$";
               // source = cks[i];
               // break;
            }
        }
        if (id == "") {
            alert('��ѡ�����ݣ���ִ�д˲���');
            return;
        }
        //=============================
        //        while (source.tagName != "TD")
        //            source = source.parentElement;
        //        source = source.parentElement;
        //        cs = source.children;
        //        bb = cs[cs.length - 2].innerText;
        //        if (bb == "������") {
        //            alert('ֻ�ܶ�δ��������ͨ��������ִ�д˲�����');
        //            return;
        //        }
        //=====================
        // var dialogURL = id == null ? 'Window_FlowList.aspx' : 'Window_FlowList.aspx?id=' + id;
        // var dialog = window.showModalDialog(dialogURL, window, "dialogWidth:373px; dialogHeight:460px; center:yes; help:no; resizable:no; status:no;");

        var dialogURL = id == null ? 'Windows_BatchFlow.aspx' : 'Windows_BatchFlow.aspx?id=' + id;
        var dialog = window.showModalDialog(dialogURL, window, "dialogWidth:320px; dialogHeight:460px; center:yes; help:no; resizable:no; status:no;");

        if (dialog == "ok") {
            window.location.href = window.location.href;
            window.location.reload;
        }
        return dialog;
    }
    function showFlowDialog() {
        var cks = document.getElementsByTagName("input");
        var id = "";
        for (var i = 0; i < cks.length; i++) {
            if (cks[i].type == "checkbox" && cks[i].checked == true && cks[i].value != '') {
                id = cks[i].value;
                source = cks[i];
                break;
            }
        }
        if (id == "") {
            alert('��ѡ�����ݣ���ִ�д˲���');
            return;
        }
        //=====================
        while (source.tagName != "TD")
            source = source.parentElement;
        source = source.parentElement;
        cs = source.children;
        bb = cs[cs.length - 2].innerText;
        if (bb == "") {
            alert('�ȷ������̣���ִ�д˲�����');
            return;
        }
        //=====================
        var dialogURL = id == null ? 'Test.aspx' : 'Test.aspx?id=' + encodeURI(id);
        var dialog = window.showModalDialog(dialogURL, window, "dialogWidth:825px; dialogHeight:450px; center:yes; help:no; resizable:no; status:no;");
        if (dialog == "ok") {
            window.location.href = window.location.href;
            window.location.reload;
        }

    }
    function refuseDialog() {
        var cks = document.getElementsByTagName("input");
        var id = "";
        for (var i = 0; i < cks.length; i++) {
            if (cks[i].type == "checkbox" && cks[i].checked == true && cks[i].value != '') {
                id += cks[i].value;
                source = cks[i];
                break;
            }
        }
        if (id == "") {
            alert('��ѡ�����ݣ���ִ�д˲���');
            return;
        }

        //=====================
        while (source.tagName != "TD")
            source = source.parentElement;
        source = source.parentElement;
        cs = source.children;
        bb = cs[cs.length - 2].innerText;
        if (bb == "") {
            alert('û�����̣�����ִ�д˲�����');
            return;
        }
        //=====================
        if (confirm("ȷ��Ҫ������") == false) return;
        var dialogURL = id == null ? 'FormAudit.aspx' : 'FormAudit.aspx?op=5&id=' + encodeURI(id);
        var dialog = window.showModalDialog(dialogURL, window, "dialogWidth:0px; dialogHeight:0px; center:yes; help:no; resizable:no; status:no;");
        if (dialog == "ok") {
            window.location.href = window.location.href;
            window.location.reload;
        }

    }

    function checkclick() {
        var objs = document.getElementsByTagName("input");
        var nock = 0;
        var isck = 0;
        for (var i = 0; i < objs.length; i++) {
            if (objs[i].type == 'checkbox') {
                var obj = objs[i];
                if (obj.checked == false && obj.id != "checkbox" && obj.id != "checkboxall") {
                    nock += 1;
                } else if (obj.checked == true && obj.id != "checkbox" && obj.id != "checkboxall") {
                    isck += 1;
                }
                //if (obj != event.srcElement && obj.checked == true) {
                // obj.checked = false;
                // while (obj.tagName != "TR")
                // obj = obj.parentElement;
                // tds = obj.children;
                // for (j = 0; j < tds.length; j++) {
                // tds[j].style.backgroundColor = '';
                // }

            }
        }
        if (nock != objs.length - 3) {
            document.all.checkbox.checked = false;
            document.all.checkboxall.checked = false;
        }
        if (isck == objs.length - 3) {
            document.all.checkbox.checked = true;
            document.all.checkboxall.checked = true;
        }
        if (event.srcElement.checked) {
            var bg = event.srcElement;
            while (bg.tagName != "TR")
                bg = bg.parentElement;
            tds = bg.children;
            for (j = 0; j < tds.length; j++) {
                tds[j].style.backgroundColor = clickcolor;
            }
        } else {
            var bg = event.srcElement;
            while (bg.tagName != "TR")
                bg = bg.parentElement;
            tds = bg.children;
            for (j = 0; j < tds.length; j++) {
                tds[j].style.backgroundColor = '';
            }
        }
    }



    function clickcheckboxs(obj) {
        var cks = document.getElementsByTagName("input");
        var a = document.getElementById(obj);
        for (var i = 0; i < cks.length; i++) {
            if (cks[i].type == "checkbox" && cks[i] != a) {
                cks[i].checked = a.checked;
                if (cks[i].id == "checkboxall") continue;
                bg = cks[i];
                while (bg.tagName != "TR")
                    bg = bg.parentElement;
                tds = bg.children;
                if (cks[i].checked == true) {
                    for (j = 0; j < tds.length; j++) {
                        tds[j].style.backgroundColor = clickcolor;
                    }
                } else {
                    for (j = 0; j < tds.length; j++) {
                        tds[j].style.backgroundColor = '';
                    }
                }
            }
        }
    }


    var highlightcolor = '#c1ebff';
    //�˴�clickcolorֻ����winϵͳ��ɫ������ܳɹ�,�����#xxxxxx�Ĵ���Ͳ���,��û�����Ϊʲô:(
    var clickcolor = '#51b2f6';
    function changeto() {
        source = event.srcElement;
        if (source == null || typeof (source) === "undefined") return;
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
        //        trs = source.parentElement.children;
        //        for (i = 0; i < trs.length; i++) {
        //            tds = trs[i].children;
        //            for (j = 0; j < tds.length; j++) {
        //                tds[j].style.backgroundColor = "";
        //            }
        //        }
        cs[0].all[1].checked = !cs[0].all[1].checked;

        var objs = document.getElementsByTagName("input");
        var nock = 0;
        var isck = 0;
        for (var i = 0; i < objs.length; i++) {
            if (objs[i].type == 'checkbox') {
                var obj = objs[i];
                if (obj.checked == false && obj.id != "checkbox" && obj.id != "checkboxall") {
                    nock += 1;
                } else if (obj.checked == true && obj.id != "checkbox" && obj.id != "checkboxall") {
                    isck += 1;
                }
            }
        }
        if (nock != objs.length - 3) {
            document.all.checkbox.checked = false;
            document.all.checkboxall.checked = false;
        }
        if (isck == objs.length - 3) {
            document.all.checkbox.checked = true;
            document.all.checkboxall.checked = true;
        }
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
