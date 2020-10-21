<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Base/BaseTemplate.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="PMModel" %>
<%@ Import Namespace="PM.Methods" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="PublicMethods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    客户信息
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% 
        List<FinanceM> FinanceInfo = (ViewBag.FinanceInfo as List<FinanceM>);
        List<ProjectsM> ProjectsInfo = (ViewBag.Projects as List<ProjectsM>);
        FinanceM financeinfo = (ViewBag.FinanceInfo as FinanceM);
    %>

    <div class="center js_tabbody">
        <form action="../../Finance/Finance_Edit?ID=<%=financeinfo.SFID%>" method="post">
            <div class="wrap_mk wball">
                <h1>收付款信息
                       <a href="../../Finance/Finance?PRID=<%=financeinfo.SFPRID %>"><i class="iconfont icon-close"></i></a>
                </h1>
                <div class="subwrap_mk_2">
                    <h1>单据详情</h1>
                    <div class="formbox w30">
                        <label>单据编号</label>
                        <span><%=financeinfo.SFID %></span>
                    </div>

                    <div class="formbox w30">
                        <label>合同名称</label>
                        <span><%=financeinfo.SFCNID %></span>
                     </div>
                     <div class="formbox w30">
                        <label>项目名称</label>
                        <span><% foreach (ProjectsM projectsm in ProjectsInfo) { %>
	    				     <%=(financeinfo.SFPRID==projectsm.PRID ?  projectsm.PRName:"") %>
                                <%} %></span>
                     </div>
                    <div class="formbox w30">
                        <label>单据性质</label>
                        <%if (financeinfo.SFCOLLECTPAY == 1)
                            {%>
                        <span>收款</span>
                        <%} %>
                         <%if (financeinfo.SFCOLLECTPAY  == 2)
                             { %>
                        <span>付款</span>
                        <%} %>
                    </div>
                    <div class="formbox w30">
                        <label>金额</label>
                        <span><%=financeinfo.SFMONEY %></span>
                    </div>
                    <div class="formbox w30">
                        <label>凭证编号</label>
                        <span><%=financeinfo.SFACCOUNT %></span>
                    </div>
                    <div class="formbox w30">
                        <label>日期</label>
                        <span><%=financeinfo.SFDATE%></span>
                    </div>
                    
                    
                    <div class="clear"></div>
                </div>
                <div class="clear"></div>
            </div>
            <div class="clear"></div>
            <div class="footerbtn">
                
                <a href="../../Finance/Finance?PRID=<%=financeinfo.SFPRID %>" class="btn btn-gray">关闭</a>
            </div>
        </form>
        <div class="clear"></div>
    </div>
    <script type="text/javascript">
       
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PathContent" runat="server">
</asp:Content>
