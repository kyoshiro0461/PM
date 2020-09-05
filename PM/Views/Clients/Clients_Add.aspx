<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Base/BaseTemplate.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="PMModel" %>
<%@ Import Namespace="PM.Methods" %>
<%@ Import Namespace="System.IO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    添加客户
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% 
        List<ClientsM> ClientsInfo = (ViewBag.ClientsInfo as List<ClientsM>);
        string belong = TempData["belong"].ToString();
    %>

    <div class="center js_tabbody">
        <form action ="../../Clients/Add_Clients" method="post">
        <div class="wrap_mk wball">
            <h1>添加客户
                <a href="../../Clients/Clients?BELONG=<%=belong %>"><i class="iconfont icon-close"></i></a>
            </h1>
            <div class="subwrap_mk_2 top">
                <div class="formbox w50">
                    <label>客户名称</label>
                    <input type="text" name="name" id="name" />
                </div>
                <div class="formbox w50">
                        <label>隶属</label>
                    
                        <select name="belong" id="belong">
                            <%if (belong == "0")
                                { %>
                            <option value="0">业主</option>
                            <option value="1">施工队</option>
                            <option value="2">材料商</option>
                            <%} %>
                            <%if (belong == "1")
                                { %>
                            <option value="1">施工队</option>
                            <option value="0">业主</option>
                            <option value="2">材料商</option>
                            <%} %>
                            <%if (belong == "2")
                                { %>
                            <option value="2">材料商</option>
                            <option value="0">业主</option>
                            <option value="1">施工队</option>
                             <%} %>
                         </select>
                    </div>

                <div class="formbox w50">
                    <label>联系人</label>
                    <input type="text" name="person" id="person" />
                </div>

                <div class="formbox w50">
                    <label>联系方式</label>
                    <input type="text" name="tel" id="tel" />
                </div>

                <div class="formbox w50">
                    <label>地址</label>
                    <input type="text" name="address" id="address" />
                </div>
                
                <div class="formbox w50">
                    <label>社会统一信用代码</label>
                    <input type="text" name="code" id="code" />
                </div>

                <div class="formbox w50">
                    <label>开户行</label>
                    <input type="text" name="bank" id="bank" />
                </div>

                <div class="formbox w50">
                    <label>账号</label>
                    <input type="text" name="account" id="account" />
                </div>
                <div class="clear"></div>
            </div>
            <div class="clear"></div>
        </div>
        <div class="clear"></div>
        <div class="footerbtn">
            <button type="submit" class="btn btn-primary js_submit">保存</button>
            <a href="../../Clients/Clients?BELONG=<%=belong%>" class="btn btn-gray">取消</a>
        </div>
        </form>
        <div class="clear"></div>
    </div>
   
    <script type="text/javascript">
      
        $('#closelayer').click(function () {
        })
     
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PathContent" runat="server">
</asp:Content>
