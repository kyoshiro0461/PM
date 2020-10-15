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
                    
                    <%--<%if (paym == null)
                      {%>
                    <div>
                        <h1>订单备注</h1>
                        <%foreach (OrderItemM temp in orderm.ItemCollect)
                          {%>
                        <%if (temp.ContentInfo.SortInfo.Tid == LDWebCommon.TopSortItemID.tsProduct.ConvertToInt32())
                          {%>
                        <input type="hidden" value='<%= type="cash"%>' />
                        <%}
                          else if (temp.ContentInfo.SortInfo.Tid == LDWebCommon.TopSortItemID.tsTeamstyle.ConvertToInt32())
                          {%>
                        <div class="formbox w50">
                            <label>调整<%=type=orderm.VPointTypeName %></label>
                            <input type="number" name="floatjifen" id="floatjifen" value="<%=PublicMethods.Methods.Round(orderm.FloatJifen) %>" step="0.01" />
                        </div>
                        <%} %>
                        <%} %>
                        <%if (type == "cash")
                          {%>
                        <div class="formbox w50">
                            <label>调整现金</label>
                            <input type="number" name="floatmoney" id="floatmoney" value="<%=PublicMethods.Methods.Round(orderm.FloatMoney) %>" step="0.01" />
                        </div>
                        <%} %>
                        <div class="formbox w50">
                            <label>用户备注</label>
                            <textarea name="content" id="content"><%=orderm.Content %></textarea>
                        </div>
                        <div class="formbox w50">
                            <label>管理员备注</label>
                            <textarea name="remarks"><%=orderm.Remarks %></textarea>
                        </div>
                    </div>
                    <%}else{ %>
                    <div>
                        <h1>订单备注</h1>
                        <%foreach (OrderItemM temp in orderm.ItemCollect) {%>
                        <%if (temp.ContentInfo.SortInfo.Tid == LDWebCommon.TopSortItemID.tsProduct.ConvertToInt32()){%>
                        <input type="hidden" value='<%= type="cash"%>' /> <%}
                          else if (temp.ContentInfo.SortInfo.Tid == LDWebCommon.TopSortItemID.tsTeamstyle.ConvertToInt32()) {%>
                        <div class="formbox w50">
                            <label>调整<%=orderm.VPointTypeName%></label>
                            <span><%=PublicMethods.Methods.Round(orderm.FloatJifen) %></span>
                        </div>
                        <%} %>
                        <%} %>
                        <%if (type == "cash") {%>
                        <div class="formbox w50">
                            <label>调整现金</label>
                            <span><%=PublicMethods.Methods.Round(orderm.FloatMoney) %></span>
                        </div>
                        <%} %>
                        <div class="formbox w50">
                            <label>用户备注</label>
                            <span><%=orderm.Content %></span>
                        </div>
                        <div class="formbox w50">
                            <label>管理员备注</label>
                            <span><%=orderm.Remarks %></span>
                        </div>
                    </div>
                    <%} %>
                    <div>
                    <% if (orderm.ItemCollect != null && orderm.ItemCollect.Count > 0)
                       { %>
                    <div>
                        <h1>订单明细详情</h1>
                        <div class="formbox w100 pd0">
                            <table>
                                <tr>
                                    <th>ID</th>
                                    <th>产品编号/名称</th>
                                    <th>用户编号/名称</th>
                                    <th>产品所属区域</th>
                                    <th>支付方式</th>
                                    <th>支付额</th>
                                    <th>数量</th>
                                    <th>总支付</th>
                                </tr>
                                <% if (orderm.ItemCollect != null && orderm.ItemCollect.Count > 0)
                                   { %>
                                <% foreach (OrderItemM item in orderm.ItemCollect)
                                   { %>
                                <tr>
                                    <td><%=item.ID%></td>
                                    <td><%=item.ContentID%>/<%=item.ContentInfo.Name %></td>
                                    <%if (Convert.ToInt32(item.UserID) == 0)
                                      {%>
                                    <td>游客</td>
                                    <%}
                                      else
                                      {%>
                                    <td><%=item.UserID %>/<%=item.UserInfo.Name %></td>
                                    <%} %>
                                    <%if (item.ContentInfo.RegionInfo.ID == 0)
                                      {%>
                                    <td>全国</td>
                                    <%}
                                      else
                                      { %>
                                    <td><%=item.ContentInfo.RegionInfo.Title%></td>
                                    <%} %>
                                    <%if (item.ContentInfo.IsReserve == true)
                                      {%>
                                    <td><%=(item.ContentInfo.Isjifen==true?item.ContentInfo.VPointTypeName+"支付":"现金支付") %>(订购商品)</td>
                                    <td><%=(item.ContentInfo.Isjifen==true?PublicMethods.Methods.Round(item.Jifen):PublicMethods.Methods.Round(item.Money)) %></td>
                                    <td><%=item.Num %></td>
                                    <td><%=(item.ContentInfo.Isjifen==true?PublicMethods.Methods.Round(item.TotalJifen):PublicMethods.Methods.Round(item.TotalMoney)) %></td>
                                    <%}
                                      else if (item.ContentInfo.VType == ProductType.ptProduct)
                                      {%>
                                    <td>现金支付</td>
                                    <td><%=PublicMethods.Methods.Round(item.Money)%></td>
                                    <td><%=item.Num %></td>
                                    <td><%=PublicMethods.Methods.Round(item.TotalMoney)%></td>
                                    <%}
                                      else if (item.ContentInfo.VType == ProductType.ptTeamstyle)
                                      {%>
                                    <td><%=orderm.VPointTypeName %></td>
                                    <td><%=PublicMethods.Methods.Round(item.Jifen)%>米粒</td>
                                    <td><%=item.Num %></td>
                                    <td><%=PublicMethods.Methods.Round(item.TotalJifen)%></td>
                                    <%}
                                      else if (item.TotalJifen == 0 || item.TotalMoney == 0)
                                      { %>
                                    <td><%=(item.ContentInfo.Isjifen==true?item.ContentInfo.VPointTypeName+"支付":"现金支付") %>(订购商品)</td>
                                    <td><%=(item.ContentInfo.Isjifen==true?PublicMethods.Methods.Round(item.Jifen):PublicMethods.Methods.Round(item.Money)) %></td>
                                    <td><%=item.Num %></td>
                                    <td><%=(item.ContentInfo.Isjifen==true?PublicMethods.Methods.Round(item.TotalJifen):PublicMethods.Methods.Round(item.TotalMoney)) %></td>
                                    <%} %>
                                </tr>
                                <% } %>
                                <% } %>
                            </table>
                        </div>
                    </div>
                    <%} %>
                    <h1>收货信息</h1>
                    <div class="formbox w50">
                        <label>收货人</label>
                        <span><%=orderm.TrueName %></span>
                    </div>
                    <div class="formbox w50">
                        <label>手机</label>
                        <span><%=orderm.Mobile %></span>
                    </div>
                    <div class="formbox w100">
                        <label>地址</label>
                        <span><%= orderm.Province %> <%= orderm.City %> <%= orderm.District %> <%=orderm.Address %></span>
                    </div>
                    
                        <%if (paym != null)
                          {%>
                        <h1>支付记录信息</h1>
                        <div class="formbox w30">
                            <label>支付方式：</label>
                            <%foreach (OrderItemM temp in orderm.ItemCollect)
                              {%>
                            <%if (temp.ContentInfo.SortInfo.Tid == LDWebCommon.TopSortItemID.tsProduct.ConvertToInt32())
                              {%>
                            <span>现金</span>
                            <%}
                              else if (temp.ContentInfo.SortInfo.Tid == LDWebCommon.TopSortItemID.tsTeamstyle.ConvertToInt32())
                              {%>
                            <span><%=orderm.VPointTypeName %></span><%} %>
                            <%} %>
                        </div>
                        <div class="formbox w30">
                            <label>收款类型：</label>
                            <span><%=paym.Way%></span>
                        </div>
                        <div class="formbox w30">
                            <label>支付：</label>
                            <%if (paym.Way == "")
                              {%>
                            <span><%=PublicMethods.Methods.Round(paym.Jifen) %></span><%}
                              else
                              {%><span><%=PublicMethods.Methods.Round(paym.Money) %></span><%} %>
                        </div>
                        <div class="formbox w30">
                            <label>收款人/银行：</label>
                            <span><%=paym.Name %></span>
                        </div>
                        <div class="formbox w30">
                            <label>收款卡号：</label>
                            <span><%=paym.No %></span>
                        </div>
                        <div class="formbox w30">
                            <label>备注：</label>
                            <span><%=paym.Rem %></span>
                        </div>
                        <div class="formbox w30">
                            <label>创建时间：</label>
                            <span><%=paym.AddTime %></span>
                        </div>
                        <%}%>
                    </div>
                    <div>
                        <%if (postm != null)
                          {%>
                        <h1>物流信息</h1>
                        <div class="formbox w30">
                            <label>发货方式：</label>
                            <%if (postm.Way == PostWay.pwDelivery)
                              {%>
                            <span>送货</span><%}
                              else if (postm.Way == PostWay.pwExpress)
                              {%>
                            <span>快递</span><%}
                              else if (postm.Way == PostWay.pwVirtual)
                              {%>
                            <span>虚拟</span><%}
                              else
                              {%>
                            <span>其他</span><%} %>
                        </div>
                        <div class="formbox w30">
                            <label>快递公司：</label>
                            <span><%=postm.Company%></span>
                        </div>
                        <div class="formbox w30">
                            <label>快递号：</label>
                            <span><%=postm.No %></span>
                        </div>
                        <div class="formbox w30">
                            <label>发货内容：</label>
                            <span><%=postm.Content %></span>
                        </div>
                        <div class="formbox w30">
                            <label>备注：</label>
                            <span><%=postm.Rem %></span>
                        </div>
                        <div class="formbox w30">
                            <label>创建时间：</label>
                            <span><%=postm.Addtime %></span>
                        </div>
                        <%} %>
                    </div>
                    <div>
                        <%if (planem.Count > 0)
                          {%>
                        <h1>机票订单详情</h1>
                        <div class="formbox w100 pd0">
                            <table>
                                <tr>
                                    <th>出发日期</th>
                                    <th>出发地</th>
                                    <th>目的地</th>
                                    <th>乘机人姓名</th>
                                    <th>证件类型</th>
                                    <th>证件号码</th>
                                    <th>联系电话</th>
                                    <th>乘机人类型</th>
                                    <th>是否携带儿童</th>
                                    <th>是否提交</th>
                                    <th>是否支付完成</th>
                                    <th>是否处理</th>
                                </tr>
                                <% if (planem != null && planem.Count > 0)
                                   { %>
                                <% foreach (PlaneM item in planem)
                                   { %>
                                <tr data-uid="<%=item.ID %>">
                                    <td><%=item.Date%></td>
                                    <td><%=item.Start%></td>
                                    <td><%=item.End %></td>
                                    <td><%=item.Passenger%></td>
                                    <%--证件类型开始--%>
                                    <%--<%if (item.CertificateType == CertificatesType.ctHomePermit)
                                      {%>
                                    <td>回乡证</td>
                                    <%}
                                      else if (item.CertificateType == CertificatesType.ctID)
                                      { %>
                                    <td>身份证</td>
                                    <%}
                                      else if (item.CertificateType == CertificatesType.ctMTP)
                                      { %>
                                    <td>台胞证</td>
                                    <%}
                                      else if (item.CertificateType == CertificatesType.ctOfficer)
                                      { %>
                                    <td>军官证</td>
                                    <%}
                                      else if (item.CertificateType == CertificatesType.ctPassport)
                                      { %>
                                    <td>护照</td>
                                    <%}
                                      else
                                      { %>
                                    <td>居留证</td>
                                    <%} %>
                                    <%--证件类型结束--%>
                                    <%--<td><%=item.Certificate%></td>
                                    <td><%=item.Tel%></td>--%>
                                    <%--乘机人类型开始--%>
                                    <%--<%if (item.Type == PassengerType.ptAdult)
                                      {%>
                                    <td>成人</td>
                                    <%}
                                      else if (item.Type == PassengerType.ptChildren)
                                      { %>
                                    <td>儿童</td>
                                    <%}
                                      else
                                      {%>
                                    <td>老人</td>
                                    <%} %>--%>
                                    <%--乘机人类型结束--%>
                                    <%--<td><%=(item.Ischild==YesNoEnum.ynNo?"否":"是")%></td>
                                    <td><%=(item.IsSubmit==YesNoEnum.ynYes?"是":"否") %></td>
                                    <td><%=(item.IsPayOver==YesNoEnum.ynYes?"是":"否") %></td>
                                    <td>
                                        <div class="btn_switch js_plane">
                                            <input type="checkbox" value="<%= item.IsDealt.ConvertToInt32() %>" <%= (item.IsDealt == YesNoEnum.ynYes ? "checked='checked'" : "") %> class="switch plane" />
                                            <label></label>
                                        </div>
                                    </td>
                                </tr>
                                <% } %>
                                <% } %>
                            </table>
                        </div>
                        <%}
                          else if (oilm.Count > 0)
                          {%>
                        <h1>油卡订单详情</h1>
                        <div class="formbox w100 pd0">
                            <table>
                                <tr>
                                    <th>充值卡号</th>
                                    <th>油品公司</th>
                                    <th>充值金额</th>
                                    <th>数量</th>
                                    <th>总价</th>
                                    <th>是否提交</th>
                                    <th>是否支付完成</th>
                                    <th>是否处理</th>
                                </tr>
                                <% if (oilm != null && oilm.Count > 0)
                                   { %>
                                <% foreach (OilM item in oilm)
                                   { %>
                                <tr data-uid="<%=item.ID %>">
                                    <td><%=item.Cardnum%></td>
                                    <td><%=item.Company%></td>
                                    <td><%=PublicMethods.Methods.Round(item.Money) %></td>
                                    <td><%=item.Num%></td>
                                    <td><%=PublicMethods.Methods.Round((item.Money)*(item.Num))%></td>
                                    <td><%=(item.IsSubmit==YesNoEnum.ynYes?"是":"否") %></td>
                                    <td><%=(item.IsPayOver==YesNoEnum.ynYes?"是":"否") %></td>
                                    <td>
                                        <div class="btn_switch js_oil">
                                            <input type="checkbox" value="<%= item.IsDealt.ConvertToInt32() %>" <%= (item.IsDealt == YesNoEnum.ynYes ? "checked='checked'" : "") %> class="switch oil" />
                                            <label></label>
                                        </div>
                                    </td>
                                </tr>
                                <% } %>
                                <% } %>
                            </table>
                        </div>
                        <%}
                          else if (telm.Count > 0)
                          {%>
                        <h1>话费订单详情</h1>
                        <div class="formbox w100 pd0">
                            <table>
                                <tr>
                                    <th>充值号码</th>
                                    <th>运营公司</th>
                                    <th>充值金额</th>
                                    <th>数量</th>
                                    <th>总价</th>
                                    <th>是否提交</th>
                                    <th>是否支付完成</th>
                                    <th>是否处理</th>
                                </tr>
                                <% if (telm != null && telm.Count > 0)
                                   { %>
                                <% foreach (TelM item in telm)
                                   { %>
                                <tr data-uid="<%=item.ID %>">
                                    <td><%=item.Tel%></td>
                                    <td><%=item.Operator%></td>
                                    <td><%=PublicMethods.Methods.Round(item.Money) %></td>
                                    <td><%=item.Num%></td>
                                    <td><%=PublicMethods.Methods.Round((item.Money)*(item.Num))%></td>
                                    <td><%=(item.IsSubmit==YesNoEnum.ynYes?"是":"否") %></td>
                                    <td><%=(item.IsPayOver==YesNoEnum.ynYes?"是":"否") %></td>
                                    <td>
                                        <div class="btn_switch js_tel">
                                            <input type="checkbox" value="<%= item.IsDealt.ConvertToInt32() %>" <%= (item.IsDealt == YesNoEnum.ynYes ? "checked='checked'" : "") %> class="switch tel" />
                                            <label></label>
                                        </div>
                                    </td>
                                </tr>
                                <% } %>
                                <% } %>
                            </table>
                        </div>
                        <%}
                          else if (trainm.Count > 0)
                          { %>
                        <h1>高铁订单详情</h1>
                        <div class="formbox w100 pd0">
                            <table>
                                <tr>
                                    <th>出发日期</th>
                                    <th>出发地</th>
                                    <th>目的地</th>
                                    <th>乘车人姓名</th>
                                    <th>证件类型</th>
                                    <th>证件号码</th>
                                    <th>联系电话</th>
                                    <th>乘车人类型</th>
                                    <th>是否提交</th>
                                    <th>是否支付完成</th>
                                    <th>是否处理</th>
                                </tr>
                                <% if (trainm != null && trainm.Count > 0)
                                   { %>
                                <% foreach (TrainM item in trainm)
                                   { %>
                                <tr data-uid="<%=item.ID %>">
                                    <td><%=item.Date%></td>
                                    <td><%=item.Start%></td>
                                    <td><%=item.End %></td>
                                    <td><%=item.Passenger%></td>--%>
                                    <%--证件类型开始--%>
                                    <%--<%if (item.CertificateType == CertificatesType.ctHomePermit)
                                      {%>
                                    <td>回乡证</td>
                                    <%}
                                      else if (item.CertificateType == CertificatesType.ctID)
                                      { %>
                                    <td>身份证</td>
                                    <%}
                                      else if (item.CertificateType == CertificatesType.ctMTP)
                                      { %>
                                    <td>台胞证</td>
                                    <%}
                                      else if (item.CertificateType == CertificatesType.ctOfficer)
                                      { %>
                                    <td>军官证</td>
                                    <%}
                                      else if (item.CertificateType == CertificatesType.ctPassport)
                                      { %>
                                    <td>护照</td>
                                    <%}
                                      else
                                      { %>
                                    <td>居留证</td>
                                    <%} %>--%>
                                    <%--<%--证件类型结束--%>
                                   <%-- <td><%=item.Certificate%></td>
                                    <td><%=item.Tel%></td>--%>
                                    <%--乘机人类型开始--%>
                                    <%--<%if (item.Type == PassengerType.ptAdult)
                                      {%>
                                    <td>成人</td>
                                    <%}
                                      else if (item.Type == PassengerType.ptChildren)
                                      { %>
                                    <td>儿童</td>
                                    <%}
                                      else
                                      {%>
                                    <td>老人</td>
                                    <%} %>--%>
                                    <%--乘机人类型结束--%>
                                    <%--<td><%=(item.IsSubmit==YesNoEnum.ynYes?"是":"否") %></td>
                                    <td><%=(item.IsPayOver==YesNoEnum.ynYes?"是":"否") %></td>
                                    <td>
                                        <div class="btn_switch js_train">
                                            <input type="checkbox" value="<%= item.IsDealt.ConvertToInt32() %>" <%= (item.IsDealt == YesNoEnum.ynYes ? "checked='checked'" : "") %> class="switch train" />
                                            <label></label>
                                        </div>
                                    </td>
                                </tr>
                                <% } %>
                                <% } %>
                            </table>
                        </div>
                        <%}
                          else if (reservem.Count > 0)
                          {%>
                        <h1>订购订单详情</h1>
                        <div class="formbox w100 pd0">
                            <table>
                                <tr>
                                    <th>联系人</th>
                                    <th>联系人手机</th>
                                    <th>地址</th>
                                    <th>订购时间</th>
                                    <th>备注</th>
                                    <th>是否提交</th>
                                    <th>是否支付完成</th>
                                    <th>是否处理</th>
                                </tr>
                                <% if (reservem != null && reservem.Count > 0)
                                   { %>
                                <% foreach (ReserveM item in reservem)
                                   { %>
                                <tr data-uid="<%=item.ID %>">
                                    <td><%=item.Name%></td>
                                    <td><%=item.Mobile%></td>
                                    <td><%=item.Address %></td>
                                    <td><%=item.AddTime %></td>
                                    <td><%=item.Rem%></td>
                                    <td><%=(item.IsSubmit==YesNoEnum.ynYes?"是":"否") %></td>
                                    <td><%=(item.IsPayOver==YesNoEnum.ynYes?"是":"否") %></td>
                                    <td>
                                        <div class="btn_switch js_onoff">
                                            <input type="checkbox" value="<%= item.IsDealt.ConvertToInt32() %>" <%= (item.IsDealt == YesNoEnum.ynYes ? "checked='checked'" : "") %> class="switch onoff" />
                                            <label></label>
                                        </div>
                                    </td>
                                </tr>
                                <% } %>
                                <% } %>
                            </table>
                        </div>
                        <%}
                          else
                          {%>
                        <%} %>
                    </div>--%>
                    <div class="clear"></div>
                </div>
                <div class="clear"></div>
            </div>
            <div class="clear"></div>
            <div class="footerbtn">
                <%--<button type="submit" class="btn btn-primary">保存</button>--%>
                <a href="../../Finance/Finance?PRID=<%=financeinfo.SFPRID %>" class="btn btn-gray">关闭</a>
            </div>
        </form>
        <div class="clear"></div>
    </div>
    <script type="text/javascript">
        //是否处理开关(订购)
        $('.js_onoff').on('click', function () {
            var t = $(this).find('input');
            var id = $(this).parent('td').parent('tr').attr('data-uid');
            var onoff = $(this).find('.onoff').attr('value');
            $.ajax({
                type: "POST",
                url: "../../AdminOperate/Order_SetDealt",
                data: { id: id, onoff: onoff },
                dataType: "json",
                success: function (data) {
                    var obj = JSON.parse(data);
                    t.attr('value', obj.onoff);
                    if (obj.onoff == [<%= YesNoEnum.ynYes.ConvertToInt32() %>])
                         t.prop('checked', true);
                     else
                         t.removeAttr('checked');
                     alert('设置成功');
                 }
             });
         });
         //是否处理开关(高铁)
         $('.js_train').on('click', function () {
             var t = $(this).find('input');
             var id = $(this).parent('td').parent('tr').attr('data-uid');
             var onoff = $(this).find('.train').attr('value');
             $.ajax({
                 type: "POST",
                 url: "../../AdminOperate/Order_SetDealtTrain",
                 data: { id: id, onoff: onoff },
                 dataType: "json",
                 success: function (data) {
                     var obj = JSON.parse(data);
                     t.attr('value', obj.onoff);
                     if (obj.onoff == [<%= YesNoEnum.ynYes.ConvertToInt32() %>])
                         t.prop('checked', true);
                     else
                         t.removeAttr('checked');
                     alert('设置成功');
                 }
             });
         });
         //是否处理开关(飞机票)
         $('.js_plane').on('click', function () {
             var t = $(this).find('input');
             var id = $(this).parent('td').parent('tr').attr('data-uid');
             var onoff = $(this).find('.plane').attr('value');
             $.ajax({
                 type: "POST",
                 url: "../../AdminOperate/Order_SetDealtPlane",
                 data: { id: id, onoff: onoff },
                 dataType: "json",
                 success: function (data) {
                     var obj = JSON.parse(data);
                     t.attr('value', obj.onoff);
                     if (obj.onoff == [<%= YesNoEnum.ynYes.ConvertToInt32() %>])
                         t.prop('checked', true);
                     else
                         t.removeAttr('checked');
                     alert('设置成功');
                 }
             });
         });
         //是否处理开关(油票)
         $('.js_oil').on('click', function () {
             var t = $(this).find('input');
             var id = $(this).parent('td').parent('tr').attr('data-uid');
             var onoff = $(this).find('.oil').attr('value');
             $.ajax({
                 type: "POST",
                 url: "../../AdminOperate/Order_SetDealtOil",
                 data: { id: id, onoff: onoff },
                 dataType: "json",
                 success: function (data) {
                     var obj = JSON.parse(data);
                     t.attr('value', obj.onoff);
                     if (obj.onoff == [<%= YesNoEnum.ynYes.ConvertToInt32() %>])
                         t.prop('checked', true);
                     else
                         t.removeAttr('checked');
                     alert('设置成功');
                 }
             });
         });
         //是否处理开关(话费)
         $('.js_tel').on('click', function () {
             var t = $(this).find('input');
             var id = $(this).parent('td').parent('tr').attr('data-uid');
             var onoff = $(this).find('.tel').attr('value');
             $.ajax({
                 type: "POST",
                 url: "../../AdminOperate/Order_SetDealtTel",
                 data: { id: id, onoff: onoff },
                 dataType: "json",
                 success: function (data) {
                     var obj = JSON.parse(data);
                     t.attr('value', obj.onoff);
                     if (obj.onoff == [<%= YesNoEnum.ynYes.ConvertToInt32() %>])
                         t.prop('checked', true);
                     else
                         t.removeAttr('checked');
                     alert('设置成功');
                 }
             });
         });
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="PathContent" runat="server">
</asp:Content>
