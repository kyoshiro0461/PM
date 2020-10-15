﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Base/BaseTemplate.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="PMModel" %>
<%@ Import Namespace="PublicMethods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    工程量管理
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% 
        List<QuantityM> QuantityInfo = ViewBag.Quantity as List<QuantityM>;
        List<ProjectsM> ProjectsInfo = ViewBag.Projects as List<ProjectsM>;
        object keys = TempData["keys"];
        int desc = TempData["Orderby"].ConvertToInt32();
        int allpage = ViewBag.TotalPages;
        int pagecurrent = TempData["CurrentPage"].ConvertToInt32();
        //int collectpay = TempData["collectpay"].ConvertToInt32();
    %>
    <div class="wrap_mk wball">
        <div class="crumbs">
            位置:<a href="../../Main/Index">首页</a> > <a href="../../Quantity/Quantity">工程量管理</a>
        </div>
        <div class="tool">
            <a href="../../Main/Index" class="btn btn-gray"><i class="iconfont icon-undo"></i>返回</a>
            <a href="../../Quantity/Quantity" class="btn btn-gray"><i class="iconfont icon-refresh"></i>刷新</a>
           <%-- <a href="../../Quantity/Quantity?BELONG=0" class="btn btn-primary"><i class="iconfont icon-refresh"></i>集团内工程量</a>
            <a href="../../Quantity/Quantity?BELONG=1" class="btn btn-primary"><i class="iconfont icon-refresh"></i>集团外工程量</a>
            <a href="../../Quantity/Quantity?BELONG=2" class="btn btn-primary"><i class="iconfont icon-refresh"></i>挂靠工程量</a>
            <a href="../../Quantity/Quantity?BELONG=3" class="btn btn-primary"><i class="iconfont icon-refresh"></i>借用资质工程量</a>--%>
            <a href="../../Quantity/Quantity_Add" class="btn btn-primary"><i class="iconfont icon-add"></i>添加</a>

            <div class="search">
                <input type="text" value="<%=keys%>" placeholder="请输入关键词" id="keys" />
                <a href="javascript:;" id="search" class="search1">搜索</a>
            </div>
        </div>
        <div class="subwrap_mk_1" data-class="1">
            <table>
                <tr class="odd">
                    <th class="sorting js_orderby" data-orderby="SF_ID" data-desc="<%= desc%>">ID</th>
                    
                    <th>施工内容</th>
                    <th>工程量</th>
                    <th>金额</th>
                    <th>操作</th>
                </tr>
                <% if (QuantityInfo != null && QuantityInfo.Count > 0)
                    { %>
                <% foreach (QuantityM item in QuantityInfo)
                    { %>
                <tr data-uid='<%=item.QTID%>'>
                    <td><a href="../../Quantity/Quantity_List?ID=<%=item.QTID %>"><%=item.QTID %></a></td>
                    <td><%=item.QTCONTENT %></td>
                    <td><%=item.QTQUANTITY %></td>
                    <td><%=item.QTMONEY %></td>
                    <td>
                        <a href="../../Quantity/Quantity_Edit?ID=<%= item.QTID%>" class="btn_icon gree"><i class="iconfont icon-brush_fill"></i></a>
                        <a href="javascript:;" value="" class="btn_icon red btn_del"><i class="iconfont icon-trash_fill"></i></a>
                    </td>
                </tr>
                <% } %>
                <% } %>
                <%else
                    { %>
                <tr>
                    <td colspan="9">暂无数据</td>
                </tr>
                <%} %>
            </table>
            <div class="listpage">
                <a href="javascript:;" class="first" data-last="<%=pagecurrent%>">上一页</a>
                <!-- 显示1,2，3，...页  开始-->
                <div class="js_listpage">
                    <%for (int a = 1; a <= allpage; a++)
                        { %>
                    <%if (pagecurrent == a)
                        {%>
                    <a href="javascript:;" class="hover" data-page="<%=a%>"><%=a%></a>
                    <%} %><%else
                              { %>
                    <a href="javascript:;" class="page_current" data-page="<%=a%>"><%=a%></a>
                    <% }%>
                    <%} %>
                </div>
                <!-- 显示1,2，3，...页  结束-->
                <a href="javascript:;" class="next" data-next="<%=pagecurrent%>">下一页</a>
                <span>共 <%=allpage%>页，跳转到：</span>
                <input type="text" id="page_go">
                <a href="javascript:;" class="page_in">GO</a>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="../../CustomBase/Script/laypage.js"></script>
    <script type="text/javascript">
        //分页
        $('.page_current').on('click', function () {
            var orderby = $('.js_orderby').attr('data-orderby');
            var desc = $('.js_orderby').attr('data-desc');
            var currentpage = $(this).attr('data-page');
            var keys = $('#keys').val();
            location.href = "../../Quantity/Quantity?OrderBy=" + orderby + "&Desc=" + desc + "&Page=" + currentpage + "&keys=" + keys;
        });
        //上一页
        $(".first").on('click', function () {
            var orderby = $('.js_orderby').attr('data-orderby');
            var desc = $('.js_orderby').attr('data-desc');
            var keys = $('#keys').val();
            var lastpage = $(this).attr('data-last');
            lastpage = lastpage - 1;
            location.href = "../../Quantity/Quantity?OrderBy=" + orderby + "&Desc=" + desc + "&Page=" + lastpage + "&keys=" + keys;

        });
        //下一页
        $(".next").on('click', function () {
            var orderby = $('.js_orderby').attr('data-orderby');
            var desc = $('.js_orderby').attr('data-desc');
            var keys = $('#keys').val();
            var nextpage = $(this).attr('data-next');
            nextpage++;
            location.href = "../../Quantity/Quantity?OrderBy=" + orderby + "&Desc=" + desc + "&Page=" + nextpage + "&keys=" + keys;

        });
        //搜索方法
        $(".search1").on('click', function () {
            keys = $("#keys").val();

            location.href = "../../Quantity/Quantity?keys=" + keys;
        });
        //分页跳转
        $(".page_in").on('click', function () {
            var orderby = $('.js_orderby').attr('data-orderby');
            var desc = $('.js_orderby').attr('data-desc');
            page_go = $("#page_go").val();
            var keys = $('#keys').val();
            reg = new RegExp("^[0-9]*$");
            if (!reg.test(page_go) || page_go == '') {
                layer.msg("请输入数字!");
            } else {
                location.href = "../../Quantity/Quantity?OrderBy=" + orderby + "&Desc=" + desc + "&Page=" + page_go + "&keys=" + keys;
            }
        });
        //开关
        $('.js_onoff').on('click', function () {
            var t = $(this).find('input');
            var id = $(this).parent('td').parent('tr').attr('data-uid');
            var onoff = $(this).find('.onoff').attr('value');
            $.ajax({
                type: "POST",
                url: "../../AdminOperate/Customer_SetOnOff",
                data: { id: id, onoff: onoff },
                dataType: "json",
                success: function (data) {
                    var obj = JSON.parse(data);
                    t.attr('value', obj.onoff);

                    t.removeAttr('checked');
                    alert('设置成功');
                }
            });
        });
        // 删除
        $('.btn_del').on('click', function () {
            var t = $(this).parents('tr'),
               uid = $(this).parents('tr').attr('data-uid');
            var onoff_del = $(this).find('.btn_del').attr('value');
            var c = confirm('是否删除该工程量信息？');
            if (c == true) {
                t.remove();
                // 调用del删除数据库
                $.ajax({
                    type: "Post",
                    url: "../../Quantity/Delete_Quantity",
                    data: { uid, onoff_del},
                            dataType: "json",
                            success: function (data) {
                                var result = JSON.parse(data);
                                if (result.status == "0") alert(result.msg);
                            }
                });
            }
        });
        //排序
        $('.js_orderby').on('click', function () {
            var keys = $('#keys').val();
            var orderby = $(this).attr('data-orderby');
            var desc = $(this).attr('data-desc');
            desc = (desc == 0 ? 1 : 0);
            var currentpage = $('.js_listpage a.hover').attr('data-page');
            location.href = "../../Quantity/Quantity?OrderBy=" + orderby + "&Desc=" + desc + "&Page=" + currentpage + "&keys=" + keys;
        });

    </script>
</asp:Content>
