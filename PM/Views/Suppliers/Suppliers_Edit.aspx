<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Base/BaseTemplate.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="PMModel" %>
<%@ Import Namespace="PM.Methods" %>
<%@ Import Namespace="System.IO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    编辑供应商信息
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% 
        List<SuppliersM> SuppliersInfo = (ViewBag.SuppliersInfo as List<SuppliersM>);
        SuppliersM owerinfo = (ViewBag.SuppliersInfo as SuppliersM);
       
    %>

    <div class="center js_tabbody">
        <form action="../../Suppliers/Edit_Suppliers?ID=<%=owerinfo.SPID %>" method="post">
            <div class="wrap_mk wball">
                <h1>编辑供应商信息
                      <a href="../../Suppliers/Suppliers"><i class="iconfont icon-close"></i></a>
                </h1>
                <div class="subwrap_mk_2 top">
                    <div class="formbox w50">
                        <label>ID</label>
                        <span><%=owerinfo.SPID %></span>

                    </div>
                    <div class="formbox w50">
                        <label>供应商名</label>
                        <input type="text" value="<%=owerinfo.Name %>" name="name" id="name" />
                    </div>
                    
                    
                   
                    <div class="clear"></div>
                </div>
                <div class="clear"></div>
            </div>
            <div class="clear"></div>
            <div class="footerbtn">
                <button type="submit" class="btn btn-primary js_submit">保存</button>
                <a href="../../Suppliers/Suppliers" class="btn btn-gray">取消</a>
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
                    url: "../../Suppliers/Add_Suppliers",
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
