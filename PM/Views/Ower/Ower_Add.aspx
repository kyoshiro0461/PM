<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Base/BaseTemplate.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="PMModel" %>
<%@ Import Namespace="PM.Methods" %>
<%@ Import Namespace="System.IO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    添加业主
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% 
        List<OwerM> OwerInfo = (ViewBag.OwerInfo as List<OwerM>);
    %>

    <div class="center js_tabbody">
        <div class="wrap_mk wball js_top">
            <h1>添加业主
                      <a href="../../Ower/Ower"><i class="iconfont icon-close"></i></a>
            </h1>
            <div class="subwrap_mk_2 top">
                <div class="formbox w50">
                    <label>业主名</label>
                    <input type="text" name="name" id="name" />
                </div>
                
                
                <div class="clear"></div>
            </div>
            <div class="clear"></div>
        </div>
        <div class="clear"></div>
        <div class="footerbtn">
            <button type="submit" class="btn btn-primary js_submit">保存</button>
            <a href="../../Ower/Ower" class="btn btn-gray">取消</a>
        </div>
        <div class="clear"></div>
    </div>
    <script type="text/javascript" src="../../CustomBase/Script/jquery-1.8.3.min.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../../CustomBase/Script/third-party/template.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../CustomBase/Script/umeditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../CustomBase/Script/umeditor.min.js"></script>
    <script type="text/javascript" src="../../CustomBase/Script/lang/zh-cn/zh-cn.js"></script>
    <script type="text/javascript">
       //提交
        $('.js_submit').on('click', function () {
            var name = $('.js_top').parents().find('#name').val();
            $.ajax({
                type: "POST",
                url: "../../Ower/Add_Ower",
                data: { name: name },
                dataType: "json",
                success: function (data) {
                    var result = JSON.parse(data);
                    if (result.status == "1") {
                        alert(result.msg);
                        javascript: history.go(-1);
                        location.reload();
                    } else if (result.status == "0") {
                        layer.msg(result.msg);
                    }
                }
            });
        });

        //取消
        $('#closelayer').click(function () {
        })
        //实例化编辑器
        var um = UM.getEditor('myEditor');
        um.addListener('blur', function () {
            $('#focush2').html('编辑器失去焦点了')
        });
        um.addListener('focus', function () {
            $('#focush2').html('')
        });
        //按钮的操作
        function insertHtml() {
            var value = prompt('插入html代码', '');
            um.execCommand('insertHtml', value)
        }
        function isFocus() {
            alert(um.isFocus())
        }
        function doBlur() {
            um.blur()
        }
        function createEditor() {
            enableBtn();
            um = UM.getEditor('myEditor');
        };
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PathContent" runat="server">
</asp:Content>
