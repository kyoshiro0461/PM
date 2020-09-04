<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Base/BaseTemplate.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="PMModel" %>
<%@ Import Namespace="PM.Methods" %>
<%@ Import Namespace="System.IO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    编辑收付款信息
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% 
        List<FinanceM> financeInfo = (ViewBag.financeInfo as List<FinanceM>);
        FinanceM financeinfo = (ViewBag.FinanceInfo as FinanceM);
       
    %>

    <div class="center js_tabbody">
        <form action="../../Finance/Edit_Finance?ID=<%=financeinfo.SFID %>" method="post">
            <div class="wrap_mk wball">
                <h1>编辑收付款信息
                      <a href="../../Finance/Finance"><i class="iconfont icon-close"></i></a>
                </h1>
                <div class="subwrap_mk_2 top">
                    <div class="formbox w50">
                        <label>ID</label>
                        <span><%=financeinfo.SFID %></span>

                    </div>
                    <div class="formbox w50">
                        <label>收付款名</label>
                        <input type="text" value="<%=financeinfo.SFName %>" name="name" id="name" />
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
                <a href="../../Ower/Ower" class="btn btn-gray">取消</a>
            </div>
        </form>
        <div class="clear"></div>
    </div>
    <script type="text/javascript" src="../../CustomAdmin/Script/jquery-1.8.3.min.js" charset="UTF-8"></script>
    <script type="text/javascript" src="../../CustomAdmin/Script/third-party/template.min.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../CustomAdmin/Script/umeditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="../../CustomAdmin/Script/umeditor.min.js"></script>
    <script type="text/javascript" src="../../CustomAdmin/Script/lang/zh-cn/zh-cn.js"></script>
    <script type="text/javascript">
        //查询登录名
        $('.js_titlesearch').on('click', function () {
            var name = $(this).parent().find('#name').val();
            if (name != null && name != "") {
                $.ajax({
                    type: "POST",
                    url: "../../Ower/Add_Ower",
                    data: { name: name },
                    dataType: "json",
                    success: function (data) {
                        if (data = 0) {

                        }
                    }
                });
            }
        });
        

        //取消
        $('#closelayer').click(function () {
        })
        
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PathContent" runat="server">
</asp:Content>
