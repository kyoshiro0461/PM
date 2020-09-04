﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Base/BaseTemplate.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="PMModel" %>
<%@ Import Namespace="PM.Methods" %>
<%@ Import Namespace="System.IO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    添加收付款
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% 
        List<FinanceM> FinanceInfo = (ViewBag.FinanceInfo as List<FinanceM>);
    %>

    <div class="center js_tabbody">
        <form action ="../../Finance/Add_Finance" method="post">
        <div class="wrap_mk wball">
            <h1>添加收付款
                <a href="../../Finance/Finance"><i class="iconfont icon-close"></i></a>
            </h1>
            <div class="subwrap_mk_2 top">
                <div class="formbox w50">
                    <label>收付款名</label>
                    <input type="text" name="name" id="name" />
                </div>
                 <div class="formbox w50">
                        <label>隶属</label>
                        <select name="belong" id="belong">
                            <option value="0">集团内收付款</option>
                            <option value="1">集团外收付款</option>
                            <option value="2">挂靠收付款</option>
                            <option value="3">借用资质收付款</option>
                        </select>
                    </div>
                
                <div class="clear"></div>
            </div>
            <div class="clear"></div>
        </div>
        <div class="clear"></div>
        <div class="footerbtn">
            <button type="submit" class="btn btn-primary js_submit">保存</button>
            <a href="../../Finance/Finance" class="btn btn-gray">取消</a>
        </div>
        </form>
        <div class="clear"></div>
    </div>
   
    <script type="text/javascript">
       ////提交
       // $('.js_submit').on('click', function () {
       //     var name = $('.js_top').parents().find('#name').val();
       //     $.ajax({
       //         type: "POST",
       //         url: "../../Ower/Add_Ower",
       //         data: { name: name },
       //         dataType: "json",
       //         success: function (data) {
       //             var result = JSON.parse(data);
       //             if (result.status == "1") {
       //                 alert(result.msg);
       //                 javascript: history.go(-1);
       //                 location.reload();
       //             } else if (result.status == "0") {
       //                 layer.msg(result.msg);
       //             }
       //         }
       //     });
       // });

        //取消
        $('#closelayer').click(function () {
        })
        ////实例化编辑器
        //var um = UM.getEditor('myEditor');
        //um.addListener('blur', function () {
        //    $('#focush2').html('编辑器失去焦点了')
        //});
        //um.addListener('focus', function () {
        //    $('#focush2').html('')
        //});
        ////按钮的操作
        //function insertHtml() {
        //    var value = prompt('插入html代码', '');
        //    um.execCommand('insertHtml', value)
        //}
        //function isFocus() {
        //    alert(um.isFocus())
        //}
        //function doBlur() {
        //    um.blur()
        //}
        //function createEditor() {
        //    enableBtn();
        //    um = UM.getEditor('myEditor');
        //};
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PathContent" runat="server">
</asp:Content>
