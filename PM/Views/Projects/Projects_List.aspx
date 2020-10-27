<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Base/BaseTemplate.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="PMModel" %>
<%@ Import Namespace="PM.Methods" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="PublicMethods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    项目信息
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% 
        List<ProjectsM> ProjectsInfo = (ViewBag.ProjectsInfo as List<ProjectsM>);
        List<ClientsM> ClientsInfo = (ViewBag.ClientsInfo as List<ClientsM>);
        List<ContractM> ContractInfo = (ViewBag.ContractInfo as List<ContractM>);
        List<FinanceM> FinanceInfo = (ViewBag.FinanceInfo as List<FinanceM>);
        List<QuantityM> QuantityInfo = (ViewBag.QuantityInfo as List<QuantityM>);
        ProjectsM projectsInfo = (ViewBag.ProjectsInfo as ProjectsM);
    %>

    <div class="center js_tabbody">

        <div class="wrap_mk wball">
            <h1>项目详情</h1>
            <div class="subwrap_mk_2">
                <h1>项目概览</h1>
                <div class="formbox w30">
                    <label>项目编号</label>
                    <span><%=projectsInfo.PRID%></span>
                </div>

                <div class="formbox w30">
                    <label>项目名称</label>
                    <span><%=projectsInfo.PRName%> </span>
                </div>
                <div class="formbox w30">
                    <label>项目性质</label>
                    <% if (projectsInfo.PRBelong.ConvertToInt32() == 0)
                        {
                    %>

                    <span>集团内项目</span>
                    <% } %>
                    <% if (projectsInfo.PRBelong.ConvertToInt32() == 1)
                        {
                    %>

                    <span>集团外项目</span>
                    <% } %>
                    <% if (projectsInfo.PRBelong.ConvertToInt32() == 2)
                        {
                    %>

                    <span>借用资质项目</span>
                    <% } %>
                    <% if (projectsInfo.PRBelong.ConvertToInt32() == 3)
                        {
                    %>

                    <span>挂靠项目</span>
                    <% } %>
                </div>
                <div class="formbox w30">
                    <label>项目业主</label>
                    <span>
                        <% foreach (ClientsM clients in ClientsInfo)
                            { %>
                        <%=(clients.CLID==projectsInfo.PRID ?  clients.CLNAME:"") %>
                        <%} %>

                    </span>
                </div>

                <div class="formbox w30">
                    <label>合同份数</label>
                    <span id="cntotal"></span>
                </div>
                <div class="formbox w30">
                    <label>合同金额</label>
                    <span id="cnmoney"></span>
                </div>
                <div class="formbox w30">
                    <label>预算成本</label>
                    <span></span>
                </div>
                <div class="formbox w30">
                    <label>已收款额</label>
                    <span id="sk"></span>
                </div>
                <div class="formbox w30">
                    <label>已付款额</label>
                    <span id="fkmoney"></span>
                </div>
                <h1>合同明细
                        <div class="js_cntag">展开</div>
                </h1>
                <div class="table js_cntable" style="display: none;">
                    <table id="cntable">
                        <tr class="odd">
                            <th>ID</th>
                            <th>合同名称</th>
                            <th>合同金额</th>
                            <th>签订时间</th>
                        </tr>
                        <%if (ContractInfo != null && ContractInfo.Count > 0)
                            {%>
                        <%foreach (ContractM contract in ContractInfo)
                            { %>
                        <% if (contract.CTPrid == projectsInfo.PRID)
                            { %>
                        <tr class="trmoney">

                            <td><%=contract.CTID%> </td>
                            <td><%=contract.CTName %></td>
                            <td class="tdmoney"><%=contract.CTMoney %></td>
                            <td><%=contract.CTDate %></td>
                        </tr>
                        <% } %>
                        <% } %>
                        <tr id="cnsum">
                        </tr>
                        <% } %>
                    </table>
                </div>
                <h1>收款明细
                        <div class="js_sftag">展开</div>
                </h1>
                <div class="table js_sftable" style="display: none;">
                    <table id="sftable">
                        <tr class="odd">
                            <th>收款单号</th>
                            <th>往来客户名称</th>
                            <th>收款金额</th>
                            <th>付款时间</th>
                        </tr>
                        <%if (FinanceInfo != null && FinanceInfo.Count > 0)
                            {%>
                        <%foreach (FinanceM finance in FinanceInfo)
                            { %>
                        <% if (finance.SFPRID == projectsInfo.PRID && finance.SFCOLLECTPAY == 1)
                            { %>

                        <tr class="trmoney">

                            <td><%=finance.SFID%> </td>
                            <td></td>
                            <td class="tdmoney"><%=finance.SFMONEY %></td>
                            <td><%=finance.SFDATE %></td>
                        </tr>

                        <% } %>
                        <% } %>
                        <tr id="sfsum">
                        </tr>
                        <% } %>
                    </table>
                </div>
                <h1>付款明细
                        <div class="js_fktag">展开</div>
                </h1>
                <div class="table js_fktable" style="display: none;">
                    <table id="fktable">
                        <tr class="odd">
                            <th>付款单号</th>
                            <th>往来客户名称</th>
                            <th>付款金额</th>

                        </tr>
                        <%if (FinanceInfo != null && FinanceInfo.Count > 0)
                            {%>
                        <%foreach (FinanceM finance in FinanceInfo)
                            { %>
                        <% if (finance.SFPRID == projectsInfo.PRID && finance.SFCOLLECTPAY == 2)
                            { %>

                        <tr class="trmoney">

                            <td><%=finance.SFID%> </td>
                            <td></td>
                            <td class="tdmoney"><%=finance.SFMONEY %></td>

                        </tr>

                        <% } %>
                        <% } %>
                        <tr id="fksum">
                        </tr>
                        <% } %>
                    </table>
                </div>
                <h1>工程量明细
                        <div class="js_qttag">展开</div>
                </h1>
                <div class="table js_qttable" style="display: none;">
                    <table id="qttable">
                        <thead>
                            <tr class="odd">
                                <th>往来客户名称</th>
                                <th>施工项目</th>
                                <th>工程量</th>

                            </tr>
                        </thead>
                        <tbody>
                            <%if (QuantityInfo != null && QuantityInfo.Count > 0)
                                {%>
                            <%foreach (QuantityM quantity in QuantityInfo)
                                {%>
                            <% if (quantity.QTPRID == projectsInfo.PRID)
                                { %>

                            <tr class="trmoney">

                                <td id="clid"><%=quantity.QTCLID %></td>
                                <td><%=quantity.QTCONTENT %></td>
                                <td class="tdmoney"><%=quantity.QTQUANTITY %></td>

                            </tr>

                            <% } %>
                            <% } %>
                            <% } %>
                        </tbody>
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


        //合同展开收缩按钮
        $('.js_cntag').text('展开').addClass('down');
        $('.js_cntag').on('click', function () {
            if ($(this).hasClass('down')) {
                $(this).text('收起');
            } else {
                $(this).text('展开');
            }
            $('.js_cntable').toggle();
            $(this).toggleClass('down');
        });

        //收款展开收缩按钮
        $('.js_sftag').text('展开').addClass('down');
        $('.js_sftag').on('click', function () {
            if ($(this).hasClass('down')) {
                $(this).text('收起');
            } else {
                $(this).text('展开');
            }
            $('.js_sftable').toggle();
            $(this).toggleClass('down');
        });

        //付款展开收缩按钮
        $('.js_fktag').text('展开').addClass('down');
        $('.js_fktag').on('click', function () {
            if ($(this).hasClass('down')) {
                $(this).text('收起');
            } else {
                $(this).text('展开');
            }
            $('.js_fktable').toggle();
            $(this).toggleClass('down');
        });

        //工程量展开收缩按钮
        $('.js_qttag').text('展开').addClass('down');
        $('.js_qttag').on('click', function () {
            if ($(this).hasClass('down')) {
                $(this).text('收起');
            } else {
                $(this).text('展开');
            }
            $('.js_qttable').toggle();
            $(this).toggleClass('down');
        });

        //sftable求和
        $(document).ready(function () {

            var totalRow = 0
            $('#sftable tr').each(function () {
                $(this).find('td:eq(2)').each(function () {
                    totalRow += parseFloat($(this).text());
                });
            });

            $('#sfsum').append('<td>合计</td><td></td><td>' + totalRow + '</td><td></td>');
            $('#sk').text(totalRow);
        });

        //cntable求和
        $(document).ready(function () {

            var gettable = document.getElementById("cntable")
            var rows = gettable.rows.length - 2;
            var totalRow = 0
            $('#cntable tr').each(function () {
                $(this).find('td:eq(2)').each(function () {
                    totalRow += parseFloat($(this).text());
                });
            });

            $('#cnsum').append('<td>合计</td><td></td><td>' + totalRow + '</td><td></td>');
            $('#cnmoney').text(totalRow);
            $('#cntotal').text(rows);
        });

        //fktable求和
        $(document).ready(function () {

            var gettable = document.getElementById("fktable")
            var rows = gettable.rows.length - 2;
            var totalRow = 0
            $('#fktable tr').each(function () {
                $(this).find('td:eq(2)').each(function () {
                    totalRow += parseFloat($(this).text());
                });
            });

            $('#fksum').append('<td>合计</td><td></td><td>' + totalRow + '</td>');
            $('#fkmoney').text(totalRow);
            $('#fktotal').text(rows);
        });

        //相同施工单位归集到一起
        $(document).ready(function () {
            var table = document.getElementById("qttable");
            var tbody = table.tBodies[0];
            var tr = tbody.rows;
            

            var trValue = new Array();
            for (var i = 0; i < tr.length; i++) {
                trValue[i] = tr[i];  //将表格中各行的信息存储在新建的数组中
                arr = tr[i];
            }
            
            //trValue.sort(compareTrs());  //进行排序
            trValue.sort(function (tr1, tr2) {
                var value1 = tr1.cells[0].innerHTML;
                var value2 = tr2.cells[0].innerHTML;
                return value1.localeCompare(value2);
            });
            var fragment = document.createDocumentFragment();  //新建一个代码片段，用于保存排序后的结果
            for (var i = 0; i < trValue.length; i++) {
                fragment.appendChild(trValue[i]);
            }
            tbody.appendChild(fragment); //将排序的结果替换掉之前的值
             var totalRow = 0
            $('#qttable tr').each(function () {
                $(this).find('td:eq(2)').each(function () {
                    totalRow += parseFloat($(this).text());
                });
            });
            //在table最后增加一行合计
            $('#qttable').append('<tr><td>合计</td><td>' + totalRow + '</td><td></td></tr>');
            //声明小计数据
            var totalSum = 0;

            //循环表格中的所有行
            for (var i = 0; i < tr.length; i++) {
                var j = 1;
                j += i;
                var b = Number(i) - 1
                if (b == -1) {
                    b = tr.length - 1;
                }
                console.log(i);
                console.log(j);
                console.log(b);
                if (j < tr.length) {
                    var beforTr = tr[b].cells[0].innerHTML;//beforTr为本次循环行中的上一行
                    var nowTr = tr[i].cells[0].innerHTML;//nowTr为本次循环行中的行
                    var nextTr = tr[j].cells[0].innerHTML;//nextTr为本次循环行中的下一行
                    
                    var nowName = tr[i].cells[0].className//nowName为本次循环行中的类名用于判断此行是不是合计行；
                    if (nowTr == nextTr || (nowTr == beforTr && nowTr !== nextTr)) {//判断本行与下一行是否相等或者本行与上一行相等且本行不等于下一行
                        if (nowTr == nextTr) {//本行和下一行相等合计数据等于+=这一行的数据
                            totalSum += Number(tr[i].cells[2].innerHTML);
                        } else {
                            // 本行与上一行相等且本行不等于下一行（此行是相同的最后一行数据要加上）
                            totalSum += Number(tr[i].cells[2].innerHTML);
                        }
                    } else if (nowTr !== nextTr && nowTr !== beforTr && nowName !== "ad") {//判断本次只有一行数据且不是合计行
                    totalSum = Number(tr[i].cells[2].innerHTML);
                    }
                    if (nowTr !== nextTr && nowName !== "ad") {//在本行不等于下一行且本行不是合计行的情况下添加小计行
                        var Wtr = "<tr>+<td class='ad'colspan='2'>小计</td><td>" + totalSum+"</td> +</tr > ";
                        $(tr[i]).after(Wtr);
                        totalSum = 0;
                    }
                }
            }
        });
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PathContent" runat="server">
</asp:Content>
