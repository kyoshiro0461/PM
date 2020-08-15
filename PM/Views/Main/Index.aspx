<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Base/BaseTemplate.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="PMModel" %>
<%@ Import Namespace = "PublicMethods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    后台首页
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  
<div class="indextips">
    <h1>欢迎您: <span></span> ，今天是 <b></b></h1>
    您正在使用的是民安创享电商管理系统，欢迎您对本系统提出宝贵的建议。
</div>

<div class="wrap_mk wball ct pt100 m20">
    <i class="iconfont icon-dynamic"></i>
    统计组件开发中...
</div>
<script type="text/javascript">
    var n=$('.name a').text(),mydate = new Date(),t=mydate.toLocaleString();
    $('.indextips h1 span').text(n);
    $('.indextips h1 b').text(t);

   <%-- var t = null;
    t = setTimeout(time, 1000); //开始执行
    function time() {
        clearTimeout(t); //清除定时器
        $.ajax({
            type: "POST",
            url: "../../Admin/GetTime_Admin",
            data: {},
            dataType: "json",
            success: function (res) {
                var jsondata = JSON.parse(res);
                var data = jsondata.Data;
                thisData(data);

                //展示数据
            }
        });

        t = setTimeout(time, 30000);
        var thisData = function (data) {
            var str = '', content = '';
            var status = '';
           // var msgn = $('.timers a ').text();
            var count = $('.counttime').val();
           // if (data.length != count) {
             //   $('.timers a ').text(data.length);
                //content+='<ul class="m_list_mk sorting js_orderby" data-orderby="OD_ID"';
                for (var i = 0; i <= data.length - 1; i++) {
                    var bill = data[i];
                    // var biller = data[i].Take(5).ToList();
                    var btn = '', href = '';
                    //var date = jsonDateFormat(bill.LoginTime, "yyyy-MM-dd hh:mm:ss");
                    // var onoff = bill.OnOff;
                    edit = '../../Admin/Prompt_Edit?ID=' + bill.ID;
                    prompt = '../../Admin/Prompt';
                    var date = jsonDateFormat(bill.Addtime, "yyyy-MM-dd hh:mm:ss");
                    btn += '<a href=' + edit + '>';
                    if (bill.IsRead == [<%= Json.Encode(YesNoEnum.ynNo) %>]) {
                        btn += '<div class="stips unread">未读</div>' + bill.ApplicantInfo.Name + '申请对账';
                    } else {
                        btn += '<div class="stips unread">已读</div>' + bill.ApplicantInfo.Name + '申请对账';
                    }

                        btn += '<span>' + date + '</span>';
                        btn += '</a>';
                        content += '' + btn;
                    }
                    str += content + status;

                    $('.timers').html(str);

                }
            }--%>
     //   }


        //JSon日期格式转换
     
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PathContent" runat="server">
</asp:Content>
