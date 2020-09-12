<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Base/BaseTemplate.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="PMModel" %>
<%@ Import Namespace="PM.Methods" %>
<%@ Import Namespace="System.IO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    编辑客户信息
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% 
        List<ClientsM> ClientsInfo = (ViewBag.ClientsInfo as List<ClientsM>);
        ClientsM clientsinfo = (ViewBag.ClientsInfo as ClientsM);
       
    %>

    <div class="center js_tabbody">
        <form action="../../Clients/Edit_Clients?ID=<%=clientsinfo.CLID %>" method="post">
            <div class="wrap_mk wball">
                <h1>编辑客户信息
                      <a href="../../Clients/Clients?BELONG=<%=clientsinfo.CLBELONG %>"><i class="iconfont icon-close"></i></a>
                </h1>
                <div class="subwrap_mk_2 top">
                    <div class="formbox w50">
                        <label>ID</label>
                        <span><%=clientsinfo.CLID %></span>

                    </div>
                    <div class="formbox w50">
                        <label>客户名</label>
                        <input type="text" value="<%=clientsinfo.CLNAME %>" name="name" id="name" />
                    </div>
                     <div class="formbox w50">
                        <label>隶属</label>
                    
                        <select name="belong" id="belong">
                            <%if (clientsinfo.CLBELONG == 0)
                                { %>
                            <option value="0">业主</option>
                            <option value="1">施工队</option>
                            <option value="2">材料商</option>
                            <%} %>
                            <%if (clientsinfo.CLBELONG == 1)
                                { %>
                            <option value="1">施工队</option>
                            <option value="0">业主</option>
                            <option value="2">材料商</option>
                            <%} %>
                            <%if (clientsinfo.CLBELONG == 2)
                                { %>
                            <option value="2">材料商</option>
                            <option value="0">业主</option>
                            <option value="1">施工队</option>
                             <%} %>
                         </select>
                    </div>

                <div class="formbox w50">
                    <label>联系人</label>
                    <input type="text" value="<%=clientsinfo.CLPERSON %>" name="person" id="person" />
                </div>

                <div class="formbox w50">
                    <label>联系方式</label>
                    <input type="text" value="<%=clientsinfo.CLTEL %>" name="tel" id="tel" />
                </div>

                <div class="formbox w50">
                    <label>地址</label>
                    <input type="text" value="<%=clientsinfo.CLADDRESS %>" name="address" id="address" />
                </div>
                
                <div class="formbox w50">
                    <label>社会统一信用代码</label>
                    <input type="text" value="<%=clientsinfo.CLCODE %>" name="code" id="code" />
                </div>

                <div class="formbox w50">
                    <label>开户行</label>
                    <input type="text" value="<%=clientsinfo.CLBANK %>" name="bank" id="bank" />
                </div>

                <div class="formbox w50">
                    <label>账号</label>
                    <input type="text" value="<%=clientsinfo.CLACCOUNT %>" name="account" id="account" />
                </div>
                    
                   
                    <div class="clear"></div>
                </div>
                <div class="clear"></div>
            </div>
            <div class="clear"></div>
            <div class="footerbtn">
                <button type="submit" class="btn btn-primary js_submit">保存</button>
                <a href="../../Clients/Clients?BELONG=<%=clientsinfo.CLBELONG %>" class="btn btn-gray">取消</a>
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
       
        
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PathContent" runat="server">
</asp:Content>
