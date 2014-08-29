﻿<%@ Page Language="C#" AutoEventWireup="true" Inherits="FlowWeb.FlowDialog" Codebehind="FlowDialog.aspx.cs" %>
<html>
<head>
    <title>Flow Properties </title>
    <link rel="stylesheet" type="text/css" href="inc/style.css">
    <link rel="stylesheet" type="text/css" href="inc/webTab/webtab.css">
    <script  charset="gb2312" language="javascript" type="text/javascript" src="inc/function.js"></script>
    <script  charset="gb2312" language="javascript" type="text/javascript" src="inc/shiftlang.js"></script>
    <script  charset="gb2312" language="javascript" type="text/javascript" src="inc/webTab/webTab.js"></script>
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
    <script language="javascript" type="text/javascript">
<!--
        function iniWindow() {
            var opener = window.dialogArguments;
            var url = opener.dialogURL;
            var flowId = url.indexOf('?flowid=') < 0 ? '' : url.slice(url.indexOf('?flowid=') + 8, url.length);

            try {
                if (opener.LANG != '') shiftLanguage(opener.LANG, "flowdialog");

                var FlowXML = opener.document.all.FlowXML;
                if (flowId == '') {
                    atNewFlow();
                } else {
                    if (FlowXML.value != '') {
                        atEditFlow(FlowXML, flowId);
                    } else {
                        alert('打开流程属性对话框时出错！');
                        window.close();
                    }
                }
            } catch (e) {
                alert('打开流程属性对话框时出错！');
                window.close();
            }
        }

        function okOnClick() {
            var opener = window.dialogArguments;
            var url = opener.dialogURL;
            var flowId = url.indexOf('?flowid=') < 0 ? '' : url.slice(url.indexOf('?flowid=') + 8, url.length);

            try {
                var FlowXML = opener.document.all.FlowXML;
                xml = getFlowXML(FlowXML, flowId);
                if (xml != '') {
                    FlowXML.value = xml;
                    window.close();
                    window.returnValue = 'ok';
                }

            } catch (e) {
                alert('关闭流程属性对话框时出错！');
                window.close();
            }
        }
        function cancelOnClick() {
            window.close();
        }
        function applyOnClick() {
            var opener = window.dialogArguments;
            var url = opener.dialogURL;
            var flowId = url.indexOf('?flowid=') < 0 ? '' : url.slice(url.indexOf('?flowid=') + 8, url.length);

            try {
                var FlowXML = opener.document.all.FlowXML;
                xml = getFlowXML(FlowXML, flowId);
                if (xml != '') {
                    FlowXML.value = xml;
                    window.returnValue = 'ok';
                }
            } catch (e) {
                alert('应用流程属性时出错！');
                window.close();
            }
        }
        function atNewFlow() { }

        function atEditFlow(FlowXML, flowId) {
            var xmlDoc = new ActiveXObject('MSXML2.DOMDocument');
            xmlDoc.async = false;
            xmlDoc.loadXML(FlowXML.value);
            var xmlRoot = xmlDoc.documentElement;
            var Flow = xmlRoot.getElementsByTagName("FlowConfig").item(0);

            var beginStepId = '', beginStepText = '', endStepId = '', endStepText = '';
            var Steps = xmlRoot.getElementsByTagName("Steps").item(0);
            for (var i = 0; i < Steps.childNodes.length; i++) {
                Step = Steps.childNodes.item(i);
                nType = Step.getElementsByTagName("BaseProperties").item(0).getAttribute("stepType");
                if (nType == 'BeginStep') {
                    beginStepId = Step.getElementsByTagName("BaseProperties").item(0).getAttribute("id");
                    beginStepText = Step.getElementsByTagName("BaseProperties").item(0).getAttribute("text");
                }
                if (nType == 'EndStep') {
                    endStepId = Step.getElementsByTagName("BaseProperties").item(0).getAttribute("id");
                    endStepText = Step.getElementsByTagName("BaseProperties").item(0).getAttribute("text");
                }
            }

            document.all.FlowId.value = flowId;
            document.all.FlowText.value = Flow.getElementsByTagName("BaseProperties").item(0).getAttribute("flowText");

            document.all.BeginStepId.value = beginStepId
            document.all.EndStepId.value = endStepId;
            document.all.BeginStepText.value = beginStepText;
            document.all.EndStepText.value = endStepText;

            document.all.BeginStepId.disabled = true;
            document.all.EndStepId.disabled = true;

            document.all.StepTextColor.value = Flow.getElementsByTagName("VMLProperties").item(0).getAttribute("stepTextColor");
            document.all.StepStrokeColor.value = Flow.getElementsByTagName("VMLProperties").item(0).getAttribute("stepStrokeColor");
            document.all.StepShadowColor.value = Flow.getElementsByTagName("VMLProperties").item(0).getAttribute("stepShadowColor");
            document.all.StepFocusedStrokeColor.value = Flow.getElementsByTagName("VMLProperties").item(0).getAttribute("stepFocusedStrokeColor");
            setRadioGroupValue(document.all.IsStepShadow, Flow.getElementsByTagName("VMLProperties").item(0).getAttribute("isStepShadow"));
            document.all.ActionStrokeColor.value = Flow.getElementsByTagName("VMLProperties").item(0).getAttribute("actionStrokeColor");
            document.all.ActionTextColor.value = Flow.getElementsByTagName("VMLProperties").item(0).getAttribute("actionTextColor");
            document.all.ActionFocusedStrokeColor.value = Flow.getElementsByTagName("VMLProperties").item(0).getAttribute("actionFocusedStrokeColor");
            document.all.SStepTextColor.value = Flow.getElementsByTagName("VMLProperties").item(0).getAttribute("sStepTextColor");
            document.all.SStepStrokeColor.value = Flow.getElementsByTagName("VMLProperties").item(0).getAttribute("sStepStrokeColor");
            document.all.StepColor1.value = Flow.getElementsByTagName("VMLProperties").item(0).getAttribute("stepColor1");
            document.all.StepColor2.value = Flow.getElementsByTagName("VMLProperties").item(0).getAttribute("stepColor2");
            setRadioGroupValue(document.all.IsStep3D, Flow.getElementsByTagName("VMLProperties").item(0).getAttribute("isStep3D"));
            document.all.Step3DDepth.value = Flow.getElementsByTagName("VMLProperties").item(0).getAttribute("step3DDepth");

            setRadioGroupValue(document.all.FlowMode, Flow.getElementsByTagName("FlowProperties").item(0).getAttribute("flowMode"));
            document.all.StartTime.value = Flow.getElementsByTagName("FlowProperties").item(0).getAttribute("startTime");
            document.all.EndTime.value = Flow.getElementsByTagName("FlowProperties").item(0).getAttribute("endTime");
            setRadioGroupValue(document.all.IfMonitor, Flow.getElementsByTagName("FlowProperties").item(0).getAttribute("ifMonitor"));
            setRadioGroupValue(document.all.RunMode, Flow.getElementsByTagName("FlowProperties").item(0).getAttribute("runMode"));
            setRadioGroupValue(document.all.NoteMode, Flow.getElementsByTagName("FlowProperties").item(0).getAttribute("noteMode"));
            document.all.ActiveForm.value = Flow.getElementsByTagName("FlowProperties").item(0).getAttribute("activeForm");
            document.all.AutoExe.value = Flow.getElementsByTagName("FlowProperties").item(0).getAttribute("autoExe");

        }

        function getFlowXML(FlowXML, id) {
            flowId = document.all.FlowId.value;
            flowText = document.all.FlowText.value;
            flowConditions = document.all.FlowConditions.value;
            beginStepId = document.all.BeginStepId.value;
            endStepId = document.all.EndStepId.value;
            beginStepText = document.all.BeginStepText.value;
            endStepText = document.all.EndStepText.value;
            if (flowId == '') { alert('请先填写流程编号！!'); return ''; }
            if (flowText == '') { alert('请先填写流程名称！'); return ''; }
            if (beginStepId == '' || endStepId == '') { alert('请先填写开始或结束步骤的编号！'); return ''; }
            if (beginStepText == '' || endStepText == '') { alert('请先填写开始或结束步骤的名称！'); return ''; }

            stepTextColor = document.all.StepTextColor.value;
            stepStrokeColor = document.all.StepStrokeColor.value;
            stepShadowColor = document.all.StepShadowColor.value;
            stepFocusedStrokeColor = document.all.StepFocusedStrokeColor.value;
            isStepShadow = getRadioGroupValue(document.all.IsStepShadow);
            actionStrokeColor = document.all.ActionStrokeColor.value;
            actionTextColor = document.all.ActionTextColor.value;
            actionFocusedStrokeColor = document.all.ActionFocusedStrokeColor.value;
            sStepTextColor = document.all.SStepTextColor.value;
            sStepStrokeColor = document.all.SStepStrokeColor.value;
            stepColor1 = document.all.StepColor1.value;
            stepColor2 = document.all.StepColor2.value;
            isStep3D = getRadioGroupValue(document.all.IsStep3D);
            step3DDepth = document.all.Step3DDepth.value;

            flowMode = getRadioGroupValue(document.all.FlowMode);
            startTime = document.all.StartTime.value;
            endTime = document.all.EndTime.value;
            ifMonitor = getRadioGroupValue(document.all.IfMonitor);
            runMode = getRadioGroupValue(document.all.RunMode);
            noteMode = getRadioGroupValue(document.all.NoteMode);
            activeForm = document.all.ActiveForm.value;
            autoExe = document.all.AutoExe.value;

            var xml = "";
            xml += '<WebFlow><FlowConfig>'
            xml += '<BaseProperties flowId="' + flowId + '" flowText="' + flowText + '" flowConditions="'+flowConditions+'" />';
            xml += '<VMLProperties stepTextColor="' + stepTextColor + '" stepStrokeColor="' + stepStrokeColor + '" stepShadowColor="' + stepShadowColor + '" stepFocusedStrokeColor="' + stepFocusedStrokeColor + '" isStepShadow="' + isStepShadow + '" actionStrokeColor="' + actionStrokeColor + '" actionTextColor="' + actionTextColor + '" actionFocusedStrokeColor="' + actionFocusedStrokeColor + '" sStepTextColor="' + sStepTextColor + '" sStepStrokeColor="' + sStepStrokeColor + '" stepColor1="' + stepColor1 + '" stepColor2="' + stepColor2 + '" isStep3D="' + isStep3D + '" step3DDepth="' + step3DDepth + '"/>';
            xml += '<FlowProperties flowMode="' + flowMode + '" startTime="' + startTime + '" endTime="' + endTime + '" ifMonitor="' + ifMonitor + '" runMode="' + runMode + '" noteMode="' + noteMode + '" activeForm="' + activeForm + '" autoExe="' + autoExe + '" />';
            xml += '</FlowConfig>';

            if (id == '') {
                //自动添加开始步骤
                xml += '<Steps><Step><BaseProperties id="' + beginStepId + '" text="' + beginStepText + '" stepType="BeginStep" stepIndex="0" unionPass="0" />';
                xml += '<VMLProperties width="170" height="190" x="8px" y="10px" textWeight="" strokeWeight="" isFocused="" zIndex="" />';
                xml += '<FlowProperties people="" /></Step>';
                //自动添加结束步骤
                xml += '<Step><BaseProperties id="' + endStepId + '" text="' + endStepText + '" stepType="EndStep" stepIndex="100" unionPass="0" />';
                xml += '<VMLProperties width="170" height="190" x="1813px" y="1769px" textWeight="" strokeWeight="" isFocused="" zIndex="" />';
                xml += '<FlowProperties people="" /></Step></Steps>';
                //自动添加开始到结束的动作
                //xml += '<Actions><Action><BaseProperties id="action" text="action0" actionType="PolyLine" from="begin" to="end" />';
               // xml += '<VMLProperties startArrow="" endArrow="classic" strokeWeight="" isFocused="" zIndex="" />';
               //  xml += '<FlowProperties /></Action></Actions>';

                //=========Edit CYJ 2013/6/27====
                xml += '<Actions/>';

            } else {
                var xmlDoc = new ActiveXObject('MSXML2.DOMDocument');
                xmlDoc.async = false;
                xmlDoc.loadXML(FlowXML.value);

                var xmlRoot = xmlDoc.documentElement;
                //修改开始和结束步骤
                var Steps = xmlRoot.getElementsByTagName("Steps").item(0);
                for (var i = 0; i < Steps.childNodes.length; i++) {
                    Step = Steps.childNodes.item(i);
                    nType = Step.getElementsByTagName("BaseProperties").item(0).getAttribute("stepType");
                    if (nType == 'BeginStep') {
                        Step.getElementsByTagName("BaseProperties").item(0).setAttribute("text", beginStepText);
                    }
                    if (nType == 'EndStep') {
                        Step.getElementsByTagName("BaseProperties").item(0).setAttribute("text", endStepText);
                    }
                }
                var Actions = xmlRoot.getElementsByTagName("Actions").item(0);

                xml += Steps.xml + Actions.xml;
            }

            xml += '</WebFlow>';

            return xml;
        }
//-->
    </script>
</head>
<body onload='iniWindow()' onunload=''>
    <input type="hidden" name="TempXML">
    <table border="0" cellpadding="0" cellspacing="0" height="385px">
        <thead>
            <tr id="WebTab">
                <td class="selectedtab" id="tab1" onmouseover='hoverTab("tab1")' onclick="switchTab('tab1','contents1');">
                    <span id="tabpage1">基本属性</span>
                </td>
                <td class="tab" id="tab2" onmouseover='hoverTab("tab2")' onclick="switchTab('tab2','contents2');">
                    <span id="tabpage2">步骤样式</span>
                </td>
                <td class="tab" id="tab3" onmouseover='hoverTab("tab3")' onclick="switchTab('tab3','contents3');">
                    <span id="tabpage3">动作样式</span>
                </td>
                <td class="tab" id="tab4" onmouseover='hoverTab("tab4")' onclick="switchTab('tab4','contents4');">
                    <span id="tabpage4">工作流属性</span>
                </td>
                <td class="tabspacer" width="70">
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
                                                    <span id="tabpage1_2">流程编号</span>&nbsp;&nbsp;<input type="text" name="FlowId" value="<%=GetGuid() %>"
                                                        class="txtput" style="width:220px" disabled="disabled">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage1_3">流程名称</span>&nbsp;&nbsp;<input type="text" name="FlowText" value=""
                                                        class="txtput" style="border-color:Red;width:220px" >
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                             <tr valign="top">
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage1_condition">启动条件</span>&nbsp;&nbsp;<input type="text" name="FlowConditions"
                                                        value="" class="txtput" style="height:50;width:220px;vertical-align:text-top">
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
                                </td>
                            </tr>
                            <tr valign="top">
                                <td>
                                </td>
                                <td width="100%" valign="top">
                                    <fieldset style="border: 1px solid #C0C0C0;">
                                        <legend align="left" style="font-size: 9pt;">&nbsp;<span id="tabpage1_4">开始与结束</span>&nbsp;</legend>
                                        <table border="0" width="100%" height="100%" style="font-size: 9pt;">
                                            <tr valign="top" style="display:none">
                                                <td width="5">
                                                </td>
                                                <td>
                                                    <span id="tabpage1_5">开始步骤编号</span>&nbsp;&nbsp;<input type="text" name="BeginStepId"
                                                        value="<%=GetGuid() %>" disabled="disabled" class="txtput">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top" style="display:none">
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage1_6">结束步骤编号</span>&nbsp;&nbsp;<input type="text" name="EndStepId"
                                                        value="<%=GetGuid() %>" disabled="disabled" class="txtput">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage1_7">开始步骤名称</span>&nbsp;&nbsp;<input type="text" name="BeginStepText"
                                                        value="" class="txtput" disabled="disabled" style="width:195px">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage1_8">结束步骤名称</span>&nbsp;&nbsp;<input type="text" name="EndStepText"
                                                        value="" class="txtput" disabled="disabled"  style="width:195px">
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
                                        <legend align="left" style="font-size: 9pt;">&nbsp;<span id="tabpage2_1">步骤通用样式</span>&nbsp;</legend>
                                        <table border="0" width="100%" height="100%" style="font-size: 9pt;">
                                            <tr valign="top">
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage2_2">主色调</span>&nbsp;&nbsp;<input type="text" name="StepColor1"
                                                        value="green" class="txtput" size="10">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage2_3">渲染色</span>&nbsp;&nbsp;<input type="text" name="StepColor2"
                                                        value="white" class="txtput" size="10">&nbsp;
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage2_4">文本色</span>&nbsp;&nbsp;<input type="text" name="StepTextColor"
                                                        value="blue" class="txtput" size="10">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td width="5">
                                                </td>
                                                <td>
                                                    <span id="tabpage2_5">边框色</span>&nbsp;&nbsp;<input type="text" name="StepStrokeColor"
                                                        value="green" class="txtput" size="10" style="width:180px"><font style="font-size: 10pt;" color="#919CD0">&nbsp;<span
                                                            id="tabpage2_20">（3D时无效）</span></font>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage2_6">选中色</span>&nbsp;&nbsp;<input type="text" name="StepFocusedStrokeColor"
                                                        value="yellow" class="txtput" size="10" style="width:180px"><font style="font-size: 10pt;" color="#919CD0">&nbsp;<span
                                                            id="tabpage2_21">（3D时无效）</span></font>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage2_7">有无阴影</span>&nbsp;&nbsp;<font style="font-size: 10pt;" color="#919CD0"><input
                                                        type="radio" name="IsStepShadow" value="T" checked><span id="tabpage2_8">有阴影</span>&nbsp;<input
                                                            type="radio" name="IsStepShadow" value="F"><span id="tabpage2_9">无阴影</span>&nbsp;<span
                                                                id="tabpage2_22">（3D时无效）</span></font>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage2_10">阴影色</span>&nbsp;&nbsp;<input type="text" name="StepShadowColor"
                                                        value="#b3b3b3" class="txtput" size="10" style="width:180px"><font style="font-size: 10pt;" color="#919CD0">&nbsp;<span
                                                            id="tabpage2_23">（3D时无效）</span></font>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage2_11">2D/3D视角</span>&nbsp;&nbsp;<font style="font-size: 10pt;" color="#919CD0"><input
                                                        type="radio" name="IsStep3D" value="false" checked><span id="tabpage2_12">2D</span>&nbsp;<input
                                                            type="radio" name="IsStep3D" value="true"><span id="tabpage2_13">3D</span>&nbsp;</font>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage2_14">3D深度</span>&nbsp;&nbsp;<input type="text" name="Step3DDepth"
                                                        value="20" class="txtput" size="10">
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
                                </td>
                            </tr>
                            <tr valign="top">
                                <td>
                                </td>
                                <td width="100%" valign="top">
                                    <fieldset style="border: 1px solid #C0C0C0;">
                                        <legend align="left" style="font-size: 9pt;">&nbsp;<span id="tabpage2_15">起止步骤样式</span>&nbsp;</legend>
                                        <table border="0" width="100%" height="100%" style="font-size: 9pt;">
                                            <tr valign="top">
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage2_16">文本色</span>&nbsp;&nbsp;<input type="text" name="SStepTextColor"
                                                        value="green" class="txtput" size="10">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td width="5">
                                                </td>
                                                <td>
                                                    <span id="tabpage2_17">边框色</span>&nbsp;&nbsp;<input type="text" name="SStepStrokeColor"
                                                        value="green" class="txtput" size="10">
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
                        <table border="0" width="100%" height="100%">
                            <tr valign="top">
                                <td>
                                </td>
                                <td width="100%" valign="top">
                                    <fieldset style="border: 1px solid #C0C0C0;">
                                        <legend align="left" style="font-size: 9pt;">&nbsp;<span id="tabpage3_1">动作样式</span>&nbsp;</legend>
                                        <table border="0" width="100%" height="100%" style="font-size: 9pt;">
                                            <tr valign="top">
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage3_2">线段色</span>&nbsp;&nbsp;<input type="text" name="ActionStrokeColor"
                                                        value="green" class="txtput" size="10">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td width="5">
                                                </td>
                                                <td>
                                                    <span id="tabpage3_3">文本色</span>&nbsp;&nbsp;<input type="text" name="ActionTextColor"
                                                        value="#FF8C00" class="txtput" size="10">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage3_4">选中色</span>&nbsp;&nbsp;<input type="text" name="ActionFocusedStrokeColor"
                                                        value="yellow" class="txtput" size="10">
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
                    <!-- Tab Page 3 Content End -->
                    <!-- Tab Page 4 Content Begin -->
                    <div class="contents" id="contents4">
                        <table border="0" width="100%" height="100%">
                            <tr valign="top">
                                <td>
                                </td>
                                <td width="100%" valign="top">
                                    <fieldset style="border: 1px solid #C0C0C0;">
                                        <legend align="left" style="font-size: 9pt;">&nbsp;<span id="tabpage4_1">运行设定</span>&nbsp;</legend>
                                        <table border="0" width="100%" height="100%" style="font-size: 9pt;">
                                            <tr valign="top">
                                                <td width="5">
                                                </td>
                                                <td>
                                                    <span id="tabpage4_2">流转模式</span>&nbsp;&nbsp;<font style="font-size: 10pt;" color="#919CD0"><input
                                                        type="radio" name="FlowMode" value="1" checked="checked"><span id="tabpage4_3">正式流转</span>&nbsp;<input
                                                            type="radio" name="FlowMode" value="0" ><span id="tabpage4_4">模拟流转</span>&nbsp;</font>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td width="5">
                                                </td>
                                                <td>
                                                    <span id="tabpage4_5">开始时间</span>&nbsp;&nbsp;<input type="text" name="StartTime"
                                                        value="" class="txtput">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top" >
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage4_6">结束时间</span>&nbsp;&nbsp;<input type="text" name="EndTime" value=""
                                                        class="txtput">
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top" style="display:none">
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage4_7">是否监控</span>&nbsp;&nbsp;<font style="font-size: 10pt;" color="#919CD0"><input
                                                        type="radio" name="IfMonitor" value="1" checked="checked"><span id="tabpage4_8">可监控</span>&nbsp;<input
                                                            type="radio" name="IfMonitor" value="0"><span id="tabpage4_9">不可监控</span>&nbsp;</font>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage4_10">运行模式</span>&nbsp;&nbsp;<font style="font-size: 10pt;" color="#919CD0"><input
                                                        type="radio" name="RunMode" value="1" checked="checked"><span id="tabpage4_11">人机交互</span>&nbsp;<input
                                                            type="radio" name="RunMode" value="0"><span id="tabpage4_12">自动运行</span>&nbsp;</font>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td>
                                                </td>
                                                <td>
                                                    <span id="tabpage4_13">通知模式</span>&nbsp;&nbsp;<font style="font-size: 10pt;" color="#919CD0"><input
                                                        type="radio" name="NoteMode" value="1"><span id="tabpage4_14">内部消息</span>&nbsp;<input
                                                            type="radio" name="NoteMode" value="0" checked="checked"><span id="tabpage4_15">外部邮件</span>&nbsp;</font>
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
                                </td>
                            </tr>
                            <tr valign="top">
                                <td>
                                </td>
                                <td width="100%" valign="top">
                                    <fieldset style="border: 1px solid #C0C0C0;">
                                        <legend align="left" style="font-size: 9pt;">&nbsp;<span id="tabpage4_16">人机交互模式</span>&nbsp;</legend>
                                        <table border="0" width="100%" height="100%" style="font-size: 9pt;">
                                            <tr valign="top">
                                                <td width="5">
                                                </td>
                                                <td>
                                                    <span id="tabpage4_17">交互表单</span>&nbsp;&nbsp;<input type="text" name="ActiveForm"
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
                                </td>
                            </tr>
                            <tr valign="top" style="display:none">
                                <td>
                                </td>
                                <td width="100%" valign="top">
                                    <fieldset style="border: 1px solid #C0C0C0;">
                                        <legend align="left" style="font-size: 9pt;">&nbsp;<span id="tabpage4_18">自动运行模式</span>&nbsp;</legend>
                                        <table border="0" width="100%" height="100%" style="font-size: 9pt;">
                                            <tr valign="top">
                                                <td width="5">
                                                </td>
                                                <td>
                                                    <span id="tabpage4_19">运行程序</span>&nbsp;&nbsp;<input type="text" name="AutoExe" value=""
                                                        class="txtput">
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
                    <!-- Tab Page 4 Content End -->
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
