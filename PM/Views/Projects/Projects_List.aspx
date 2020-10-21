﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Base/BaseTemplate.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="PMModel" %>
<%@ Import Namespace="PM.Methods" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="PublicMethods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    客户信息
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div class="center js_tabbody">

        <div class="wrap_mk wball">
            <h1>项目详情</h1>
            <div class="subwrap_mk_2">
                <h1>项目概览</h1>
                <div class="formbox w30">
                    <label>项目编号</label>
                    <span></span>
                </div>

                <div class="formbox w30">
                    <label>项目名称</label>
                    <span></span>
                </div>
                <div class="formbox w30">
                    <label>项目性质</label>
                    <span></span>
                </div>
                <div class="formbox w30">
                    <label>项目业主</label>
                    <span></span>
                </div>
                <div class="formbox w30">
                    <label>合同名称</label>
                    <span></span>
                </div>
                <div class="formbox w30">
                    <label>合同编号</label>
                    <span></span>
                </div>
                <div class="formbox w30">
                    <label>合同金额</label>
                    <span></span>
                </div>
                <div class="formbox w30">
                    <label>预算成本</label>
                    <span></span>
                </div>
                <div class="formbox w30">
                    <label>已收款额</label>
                    <span></span>
                </div>
                <div class="formbox w30">
                    <label>已付款额</label>
                    <span></span>
                </div>
                <h1>收款明细
                        <div class="js_tag">展开</div>
                </h1>
                <div class="table js_table" style="display: none;">
                    <table id="mytable">
                        <tr class="odd">
                            <th>付款单号</th>
                            <th>往来客户名称</th>
                            <th>付款金额</th>
                            <th>付款时间</th>
                        </tr>

                        <tr class="trmoney">
                            <td>1</td>
                            <td>131</td>
                            <td class="tdmoney">2000</td>
                            <td>2222-22-22</td>
                        </tr>

                        <tr id="sum">
                            
                        </tr>
                    </table>
                </div>
                <div class="clear"></div>
            </div>
            <div class="clear"></div>
        </div>
        <div class="clear"></div>
        <div class="footerbtn">

            <a href="../../Finance/Finance?PRID= %>" class="btn btn-gray">关闭</a>
        </div>

        <div class="clear"></div>
    </div>

    <script type="text/javascript">
        //展开收缩按钮
        $('.js_tag').text('展开').addClass('down');
        $('.js_tag').on('click', function () {
            if ($(this).hasClass('down')) {
                $(this).text('收起');
            } else {
                $(this).text('展开');
            }
            $('.js_table').toggle();
            $(this).toggleClass('down');
        });

        //table求和
        $(document).ready(function() {
	
	var totalRow = 0
	$('#mytable tr').each(function() {
		$(this).find('td:eq(2)').each(function(){
				totalRow += parseFloat($(this).text()); 
		});
	});
	
	$('#sum').append('<td>合计</td><td></td><td>'+totalRow+'</td><td></td>');
});


    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PathContent" runat="server">
</asp:Content>
