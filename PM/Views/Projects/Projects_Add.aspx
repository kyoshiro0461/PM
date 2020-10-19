<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Base/BaseTemplate.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="PMModel" %>
<%@ Import Namespace="PM.Methods" %>
<%@ Import Namespace="System.IO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    添加项目
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% 
        List<ProjectsM> ProjectsInfo = (ViewBag.ProjectsInfo as List<ProjectsM>);
        List<ClientsM> ClientsInfo = (TempData["ClientsInfo"] as List<ClientsM>);
        TempData["ClientsInfo"] = ClientsInfo;
        %>

    <div class="center js_tabbody">
        <form action="../../Projects/Add_Projects" method="post">
            <div class="wrap_mk wball">
                <h1>添加项目
                <a href="../../Projects/Projects"><i class="iconfont icon-close"></i></a>
                </h1>
                <div class="subwrap_mk_2 top">
                    <div class="formbox w50">
                        <label>项目名</label>
                        <input type="text" name="name" id="name" />
                    </div>
                    <div class="formbox w50">
                        <label>隶属</label>
                        <select name="belong" id="belong">
                            <option value="-1">请选择</option>
                            <option value="0">集团内项目</option>
                            <option value="1">集团外项目</option>
                            <option value="2">挂靠项目</option>
                            <option value="3">借用资质项目</option>
                        </select>
                    </div>
                    <div class="formbox w50">
                        <label>往来客户</label>
                        <select id="combobox" name="combobox">
                            
                        </select>
                    </div>
                    <div class="clear"></div>
                </div>
                <div class="clear"></div>
            </div>
            <div class="clear"></div>
            <div class="footerbtn">
                <button type="submit" class="btn btn-primary js_submit">保存</button>
                <a href="../../Projects/Projects" class="btn btn-gray">取消</a>
            </div>
        </form>
        <div class="clear"></div>
    </div>

    <script type="text/javascript">
        $('#closelayer').click(function () {
        });
        
        $('#belong').change(function () {
            var belong = $(this).find('option:selected').attr('value');
            $('#combobox').empty();
            if (belong != -1) {
                $.ajax({
                    type: "POST",
                    url: "../../Projects/GetBelong",
                    data: { belong: belong },
                    dataType: "json",
                    success: function (data) {
                        var ClientsInfo = JSON.parse(data);
                        $('#combobox').append('<option selected value= -1>请选择</option>');

                        for (var i = 0; i < ClientsInfo.length; i++) {
                            var temp = ClientsInfo[i];
                            $('#combobox').append('<option value=' + temp.CLID + ' data-title=' + temp.CLNAME + '>' + temp.CLNAME + '</option>');
                        }
                    }
                })
            } else {
                $('#combobox').append('<option selected value=0>请选择</option>');
                
            }
        });


    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PathContent" runat="server">
</asp:Content>
