<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Base/BaseTemplate.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="PMModel" %>
<%@ Import Namespace="PM.Methods" %>
<%@ Import Namespace="System.IO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    添加合同
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% 
        List<ContractM> ContractInfo = (ViewBag.ContractInfo as List<ContractM>);
        string prid = TempData["prid"].ToString();
    %>

    <div class="center js_tabbody">
        <form action ="../../Contract/Add_Contract?PRID=<%=prid %>" method="post">
        <div class="wrap_mk wball">
            <h1>添加合同
                <a href="../../Contract/Contract"><i class="iconfont icon-close"></i></a>
            </h1>
            <div class="subwrap_mk_2 top">
                <div class="formbox w50">
                    <label>合同名称</label>
                    <input type="text" name="name" id="name" />
                </div>
                 <div class="formbox w50">
                        <label>隶属</label>
                        <select name="belong" id="belong">
                            <option value="0">业主合同</option>
                            <option value="1">供应商合同</option>
                            <option value="2">施工队合同</option>
                        </select>
                    </div>
                
                <div class="formbox w50">
                    <label>合同编号</label>
                    <input type="text" name="ctno" id="ctno" />
                </div>
                
                <div class="formbox w50">
                    <label>合同金额</label>
                    <input type="text" name="money" id="money" />
                </div>
                <div class ="formbox w50">
                    <label>签订时间</label>
                    <input type="text"  id="time_contract" name="time_contract" value="" >
                </div>
                <div class="clear"></div>
            </div>
            <div class="clear"></div>
        </div>
        <div class="clear"></div>
        <div class="footerbtn">
            <button type="submit" class="btn btn-primary js_submit">保存</button>
            <a href="../../Contract/Contract?PRID=<%= prid %>" class="btn btn-gray">取消</a>
        </div>
        </form>
        <div class="clear"></div>
    </div>
    <link rel="stylesheet" type="text/css" href="../../CustomBase/Style/jquery.datetimepicker.css"/>
    <script type="text/javascript" src="../../CustomBase/Script/jquery.datetimepicker.full.min.js" ></script>
    <script type="text/javascript">
        $.datetimepicker.setLocale('ch');
        $("#time_contract").datetimepicker({
            format: "Y-m-d",
            timepicker: false,
            todayButton:true,
        });
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PathContent" runat="server">
</asp:Content>
