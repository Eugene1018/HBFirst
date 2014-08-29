﻿<%@ Page Language="C#" AutoEventWireup="true" Inherits="FlowWeb.ActionDialog" Codebehind="ActionDialog.aspx.cs" %>

<html xmlns:stedysoft>
<head>
    <title>动作属性页 </title>
    <link rel="stylesheet" type="text/css" href="inc/style.css">
    <link rel="stylesheet" type="text/css" href="inc/webTab/webtab.css">
    <script language="jscript" src="inc/function.js"></script>
    <script language="jscript" src="inc/shiftlang.js"></script>
    <script language="jscript" src="inc/webTab/webTab.js"></script>
    <style>
        body
        {
            background-color: buttonface;
            scroll: no;
            margin: 7px, 0px, 0px, 7px;
            border: none;
            overflow: hidden;
        }
    </style>
    <script language="JavaScript">
<!--
        function iniWindow() {
            var opener = window.dialogArguments;
            var url = opener.dialogURL;
            var actionId = url.indexOf('?actionid=') < 0 ? '' : url.slice(url.indexOf('?actionid=') + 10, url.length);

            try {
                if (opener.LANG != '') shiftLanguage(opener.LANG, "actiondialog");

                var FlowXML = opener.document.all.FlowXML;

                if (FlowXML.value != '') {
                    iniActionDialog(FlowXML, actionId);
                } else {
                    alert('打开动作属性对话框时出错!');
                    window.close();
                }
            } catch (e) {
                alert('打开动作属性对话框时出错!');
                window.close();
            }
        }
        function iniActionDialog(FlowXML, actionId) {

            xmlDoc = new ActiveXObject('MSXML2.DOMDocument');
            xmlDoc.async = false;
            xmlDoc.loadXML(FlowXML.value);

            var xmlRoot = xmlDoc.documentElement;
            var Actions = xmlRoot.getElementsByTagName("Actions").item(0);
            var fromStep = '', toStep = '';
            for (var i = 0; i < Actions.childNodes.length; i++) {
                Action = Actions.childNodes.item(i);
                id = Action.getElementsByTagName("BaseProperties").item(0).getAttribute("id");
                if (id == actionId) {
                    fromStep = Action.getElementsByTagName("BaseProperties").item(0).getAttribute("from");
                    toStep = Action.getElementsByTagName("BaseProperties").item(0).getAttribute("to");
                    //修改动作时先填充参数
                    document.all.ActionId.value = actionId;
                    document.all.ActionText.value = Action.getElementsByTagName("BaseProperties").item(0).getAttribute("text");
                    setRadioGroupValue(document.all.ActionType, Action.getElementsByTagName("BaseProperties").item(0).getAttribute("actionType"));
                    document.all.DefaultOpinion.value = Action.getElementsByTagName("BaseProperties").item(0).getAttribute("opinion").replace(/\$/g, "'");


                    document.all.StartArrow.value = Action.getElementsByTagName("VMLProperties").item(0).getAttribute("startArrow");
                    document.all.EndArrow.value = Action.getElementsByTagName("VMLProperties").item(0).getAttribute("endArrow");
                    document.all.StrokeWeight.value = Action.getElementsByTagName("VMLProperties").item(0).getAttribute("strokeWeight");

                    document.all.Plugins.value = Action.getElementsByTagName("FlowProperties").item(0).getAttribute("plugin");
                }
            }

            //生成from，to steplist   
            var Steps = xmlRoot.getElementsByTagName("Steps").item(0);
            var from = document.all.From;
            var to = document.all.To;
            for (var i = 0; i < Steps.childNodes.length; i++) {
                Step = Steps.childNodes.item(i);
                id = Step.getElementsByTagName("BaseProperties").item(0).getAttribute("id");
                text = Step.getElementsByTagName("BaseProperties").item(0).getAttribute("text");

                fromSelected = fromStep == id ? true : false;
                toSelected = toStep == id ? true : false;
                if (id != 'end') addSelectOption(from, text, id, fromSelected);
                if (id != 'begin') addSelectOption(to, text, id, toSelected);
            }
        }

        function okOnClick() {
            var opener = window.dialogArguments;
            var url = opener.dialogURL;
            var actionId = url.indexOf('?actionid=') < 0 ? '' : url.slice(url.indexOf('?actionid=') + 10, url.length);

            try {
                var FlowXML = opener.document.all.FlowXML;

                xml = getActionXML(FlowXML, actionId);
                if (xml != '') {
                    FlowXML.value = xml;
                    window.close();
                }
            } catch (e) {
                alert('关闭动作属性对话框时出错！');
                window.close();
            }
        }
        function cancelOnClick() {
            window.close();
        }
        function applyOnClick() {
            var opener = window.dialogArguments;
            var url = opener.dialogURL;
            var actionId = url.indexOf('?actionid=') < 0 ? '' : url.slice(url.indexOf('?actionid=') + 10, url.length);

            try {
                var FlowXML = opener.document.all.FlowXML;

                xml = getActionXML(FlowXML, actionId);
                if (xml != '') {
                    FlowXML.value = xml;
                    btnApply.disabled = true;
                }
            } catch (e) {
                alert('应用动作属性时出错！');
                window.close();
            }
        }

        function getActionXML(FlowXML, actionId) {
            id = document.all.ActionId.value;
            text = document.all.ActionText.value;
            opinion = document.all.DefaultOpinion.value;
            plugin = document.all.Plugins.value;

            actionType = getRadioGroupValue(document.all.ActionType);
            from = getSelectValue(document.all.From);
            to = getSelectValue(document.all.To);
            if (id == '') { alert('请先填写动作编号！'); return ''; }
            if (text == '') { alert('请先填写动作名称！'); return ''; }
            if (from == '' || to == '') { alert('请先选择起始步骤和目的步骤！'); return ''; }

            startArrow = document.all.StartArrow.value;
            endArrow = document.all.EndArrow.value;
            strokeWeight = document.all.StrokeWeight.value;

            var xml = "";
            //生成步骤xml
            xml += '<Action><BaseProperties id="' + id + '" text="' + text + '" actionType="' + actionType + '" from="' + from + '" to="' + to + '" opinion="'+opinion+'" />';
            xml += '<VMLProperties startArrow="' + startArrow + '" endArrow="' + endArrow + '" strokeWeight="' + strokeWeight + '" zIndex="" />';
            xml += '<FlowProperties plugin= "' + plugin + '"  /></Action>';

            var xmlDoc = new ActiveXObject('MSXML2.DOMDocument');
            xmlDoc.async = false;
            xmlDoc.loadXML(FlowXML.value);
            var xmlRoot = xmlDoc.documentElement;
            var Actions = xmlRoot.getElementsByTagName("Actions").item(0);

            //添加：查找编号冲突的Id
            //修改：查找原来的Id  
            for (var i = 0; i < Actions.childNodes.length; i++) {
                Action = Actions.childNodes.item(i);
                lId = Action.getElementsByTagName("BaseProperties").item(0).getAttribute("id");

                if (lId == id && actionId == '') {
                    alert('新动作编号已存在！请重新输入！'); return '';
                }
                if (lId == actionId && actionId != '') {
                    Actions.removeChild(Action); break;
                }
            }

            var xmlDoc2 = new ActiveXObject('MSXML2.DOMDocument');
            xmlDoc2.async = false;
            xmlDoc2.loadXML(xml);
            Actions.appendChild(xmlDoc2.documentElement);

            return xmlRoot.xml;
        }
//-->
    </script>
</head>
<body onload='iniWindow()' onunload=''>
    <table border="0" cellpadding="0" cellspacing="0" height="385px">
        <thead>
            <tr id="WebTab">
                <td class="selectedtab" id="tab1" onmouseover='hoverTab("tab1")' onclick="switchTab('tab1','contents1');">
                    <span id="tabpage1">基本属性</span>
                </td>
                <td class="tab" id="tab2" onmouseover='hoverTab("tab2")' onclick="switchTab('tab2','contents2');">
                    <span id="tabpage2">图表属性</span>
                </td>
                <td class="tab" id="tab3" onmouseover='hoverTab("tab3")' onclick="switchTab('tab3','contents3');">
                    <span id="tabpage3">插件定义</span>
                </td>
                <td class="tabspacer" width="140">
                    &nbsp;
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td id="contentscell" colspan="5">
                    <!-- Tab Page 1 Content Begin -->
                    <div class="selectedcontents" id="contents1">
                        <table border="0" width="100%" height="100%">
                            <tr valign="top">
                                <td>
                                </td>
                                <td width="100%" valign="top">
                                    <fieldset style="border: 1px solid #C0C0C0;">
                                        <legend align="left" style="font-size: 9pt;">&nbsp;<span id="tabpage1_1">基本属性</span>&nbsp;</legend>
                                        <table border="0" width="100%" height="100%" style="font-size: 9pt;">
                                            <tr valign="top" style="display:none">
                                                <td width="5">
                                                </td>
                                                <td>
                                                    <span id="tabpage1_2">动作编号</span>&nbsp;&nbsp;<input type="text" name="ActionId" value="<%=GetGuid() %>"
                                                        class="txtput" disabled="disabled">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage1_3">动作名称</span>&nbsp;&nbsp;<input type="text" name="ActionText"
                                                        value="" class="txtput" style="border-color:Red;width:220px">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top" style="display:none">
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage1_4">线段类型</span>&nbsp;&nbsp;<font style="font-size: 10pt;" color="#919CD0"><input
                                                        type="radio" name="ActionType" value="PolyLine" checked="checked"><span id="tabpage1_5">折线</span>&nbsp;<input
                                                            type="radio" name="ActionType" value="Line"><span id="tabpage1_6">直线</span>&nbsp;</font>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td width="5">
                                                </td>
                                                <td>
                                                    <span id="tabpage1_7">起始步骤</span>&nbsp;&nbsp;<select name="From" class="txtput" style="width:220px"></select>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage1_8">目的步骤</span>&nbsp;&nbsp;<select name="To" class="txtput"  style="width:220px"></select>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr height="3">
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>

                            <tr valign="top">
                                <td>
                                </td>
                                <td width="100%" valign="top">
                                 
                                       <fieldset style="border: 1px solid #C0C0C0;">
                                        <legend align="left" style="font-size: 9pt;">&nbsp;<span id="Span3">默认意见</span>&nbsp;</legend>
                                        <textarea style="margin: 10,0,10,10;width:295px;height:210px"  class="txtput" name="DefaultOpinion"></textarea>
                                    </fieldset>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>


                            <tr height="100%">
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <!-- Tab Page 1 Content End -->
                    <!-- Tab Page 2 Content Begin -->
                    <div class="contents" id="contents2">
                        <table border="0" width="100%" height="100%">
                            <tr valign="top">
                                <td>
                                </td>
                                <td width="100%" valign="top">
                                    <fieldset style="border: 1px solid #C0C0C0;">
                                        <legend align="left" style="font-size: 9pt;">&nbsp;<span id="tabpage2_1">动作样式</span>&nbsp;</legend>
                                        <table border="0" width="100%" height="100%" style="font-size: 9pt;">
                                            <tr valign="top">
                                                <td width="5">
                                                </td>
                                                <td>
                                                    <span id="tabpage2_2">开始箭头</span>&nbsp;&nbsp;<input type="text" name="StartArrow"
                                                        value="" class="txtput">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td width="5">
                                                </td>
                                                <td>
                                                    <span id="tabpage2_3">结束箭头</span>&nbsp;&nbsp;<input type="text" name="EndArrow" value="Classic"
                                                        class="txtput">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage2_4">线条粗细</span>&nbsp;&nbsp;<input type="text" name="StrokeWeight"
                                                        value="" class="txtput">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr height="3">
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr height="100%">
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <!-- Tab Page 2 Content End -->
                    <!-- Tab Page 3 Content Begin -->
                    <div class="contents" id="contents3">
                        <table width="100%" height="100%" style="font-size: 10pt;">
                            <tr>
                                <td width="100%" valign="top">
                                    <fieldset style="border: 1px solid #C0C0C0;">
                                        <legend align="left" style="font-size: 9pt;">&nbsp;<span id="Span2">插件信息</span>&nbsp;</legend>
                                        <textarea style="margin: 10,0,10,10;width:315px" rows="20" class="txtput" name="Plugins"></textarea>
                                    </fieldset>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <!-- Tab Page 3 Content End -->
                </td>
            </tr>
        </tbody>
    </table>
    <table cellspacing="1" cellpadding="0" border="0" style="position: absolute; top: 400px;
        left: 0px;">
        <tr>
            <td width="100%">
            </td>
            <td>
                <input type="button" id="btnOk" class="btn" value="确 定" onclick="jscript: okOnClick();">&nbsp;&nbsp;&nbsp;
            </td>
            <td>
                <input type="button" id="btnCancel" class="btn" value="取 消" onclick="jscript: cancelOnClick();">&nbsp;&nbsp;&nbsp;
            </td>
            <td>
                <input type="button" id="btnApply" class="btn" value="应 用" onclick="jscript: applyOnClick();">&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>
</body>
</html>
