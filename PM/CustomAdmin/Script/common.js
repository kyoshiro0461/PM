// 切换
$('.js_tabtop').on('click','.li span',function(){
   var t=$(this).parents('.li').index(),
       tn=$(this).parents('.li').attr('data-num');

   $('.js_tabtop .li').removeClass('current');
   $(this).parents('.li').addClass('current');
   $(this).parents('.js_tabbody').find('.js_tabcont').hide();
   $(this).parents('.js_tabbody').find('.js_tabcont[data-num='+tn+']').show();
});
// 右侧菜单
$('.js_title').on('click',function(){
   $('.class .ul').hide();
   $(this).parent().find('.ul').show();
});
// $('.class').on('click','.li a',function(){
//    if($(this).hasClass('off')){
//        if($(this).parents(".li").hasClass('show')){
//            $(this).parents(".li").toggleClass('show');
//        }else{
//            $('.class .li').removeClass('show');
//            $(this).parents(".li").toggleClass('show');
//        }
//    }else{
//        $('.class .li').removeClass('show');
//        $(this).parents(".li").addClass('show');

//        var i=$(this).data('num'),text=$(this).text(),tab=$('.js_tabtop .li'),k=false,all=$('.js_tabtop .li').length;

//        $('.js_tabtop .li').removeClass('current');
//        $('.js_tabbody .js_tabcont').hide();

//        for (var b=1;b<=all;){
//            var l=tab.eq(b).data('num');
//            if(l==i){
//                k=true;
//                $('.js_tabtop .li[data-num='+i+']').addClass('current');
//                $('.js_tabcont[data-num='+i+']').show();
//                return
//            }
//            b++;
//        }
//        if(k==false){
//            $(".js_tabtop").append("<div class='li current'><span>"+text+"</span><a herf='javascript:;'></a></div>").find(".li").last().attr("data-num",i);
//            $(".js_tabbody").append("<div class='primary js_tabcont' style='display:block'>"+text+"建设中...</div>").find(".primary:last").last().attr("data-num",i);
//        }
//    }
// });

$('.js_tabtop').on('click','.li a',function(){
   var m=$(this).parent().data('num');
   $(this).parent().remove();
   $('.js_tabcont[data-num='+m+']').remove();
   $('.js_tabtop .li').removeClass('current');
   $('.js_tabtop .li').eq(0).addClass('current');
   $('.js_tabcont').hide();
   $('.js_tabcont').eq(0).show();
   $('.class .li').removeClass('show');
});

// 菜单
$('.js_sub').on('click',function(){
  if($(this).hasClass('current')){
     $(this).removeClass('current');
     $('.othermenu').hide(500);
  }else{
     $(this).parent().siblings().find('.js_sub').removeClass('current');
     $(this).addClass('current');
     $('.othermenu').hide(500);
     $(this).parent().find('.othermenu').show(500);
  }
});

// 获取页面高度
var bodyh=$(window).height();
if(screen.width < 720){
    if($('.footerbtn').length>0){
        $('.primary').height(bodyh-130);
    }else{
        $('.primary').height(bodyh-60);
    }
}else{
  $('.primary').height(bodyh-81);
}
function adjust(obj){
  bodyh=$(window).height();
  if(screen.width < 720){
    if($('.footerbtn').length>0){
        $('.primary').height(bodyh-130);
    }else{
        $('.primary').height(bodyh-60);
    }
 }else{
    $('.primary').height(bodyh-81);
 }
}
window.onload=function(){
 window.onresize = adjust;
 adjust();
}


// 提示窗口关闭
$('.js_dz').on('click',function(){
   $('.js_popup').show(500);
   $('.popup_bg').show();
});
$('.js_close').on('click',function(){
   $(this).parents('.js_popup').hide(500);
   $('.popup_bg').hide();
});

// 侧栏收起
$('.js_up').on('click',function(){
   $('.container').toggleClass('up');
});


// 分页
if($('.js_listpage').length>0){
    var a=$('.js_listpage a'),pageCount=a.length,t=$('.js_listpage a.hover'),dqPage=t.index(),item="<div class='more'> . . . </div>";
    if(dqPage==0){
      $(".first").hide();
    }
    if(dqPage==pageCount-1){
      $(".next").hide();
    }
    if(pageCount>5){
        t.siblings().hide();
        if(dqPage<5){
            if(dqPage>2){
                a.eq(dqPage-1).show();
                a.eq(dqPage-2).show();
                a.eq(dqPage+1).show();
                a.eq(dqPage+2).show();
                if(dqPage==3){
                  $('.js_listpage a:first').show();
                }else if(dqPage>3){
                  $('.js_listpage a:first').show().after(item);
                }
            }else{
               for(var i=0;i<5;){
                    a.eq(i).show();
                    i++;
                }
            }
            if(dqPage <= pageCount-2) {//最后一页追加“...”代表省略的页
                $('.js_listpage a:last').before(item);
            }
            $('.js_listpage a:last').show();
        }else if(dqPage>=5 ){
            a.eq(dqPage-1).show();
            a.eq(dqPage-2).show();
            a.eq(dqPage+1).show();
            a.eq(dqPage+2).show();
            if(pageCount-dqPage>4){
              $('.js_listpage a:last').show().before(item);
            }else{
              $('.js_listpage a:last').show();
            }
            $('.js_listpage a:first').show().after(item);
        }
    }
}
// 状态点击
if($('.icon_state').length>0){
  $('.icon_state a').on('click',function(){
      $(this).toggleClass('down');
  });
}
//单选
$('.js_radio input[type=radio]').on('click', function () {
    $(this).attr('checked', true).siblings().attr('checked', false);

    if ($(this).hasClass('last')) {
       var t= $(this).siblings('#other').val();
    } else {
        var t = $(this).val();
    }

    $(this).siblings('.first').val(t);
    
});

// 区域
$('.province-list').find('.ecity').each(function () {
    var input_checked = $(this).find('.citys .selected').size();
    var input_all = $(this).find('.citys .checkitem').size();
    if (input_all > 0 && input_all == input_checked) {
        $(this).find('.J_City').addClass('selected');
    }
    input_checked = $(this).parent().parent().find('.selected').size();
    input_all = $(this).parent().parent().find('.checkitem').size();
    if (input_all > 0 && input_all == input_checked) {
        $(this).parent().parent().find('.J_Province').addClass('selected');
    }
    var count = 0;
    $(this).find('.citys .checkitem').each(function () {
        if ($(this).hasClass('selected')) {
            count++;
        }
    });
    if (count > 0) {
        $(this).find('.check-num').html('(' + count + ')');
    }
});

$('.zt').on('click', function () {
    if ($(this).siblings('.citys').css('display') == 'none') {
        $('.citys').hide();
        $(this).siblings('.citys').show();
    } else {
        $(this).siblings('.citys').hide();
    }
});
$('.close_button').on('click', function () {
    $(this).parent().parent().hide();
});



$('.J_Province').click(function () {
    if ($(this).hasClass('selected')) {
        var p=$(this).parents('.ecity').siblings().find('.J_Province.selected').length;
        if(p>0){
            $(this).removeClass('selected');
            $(this).parent().parent().parent().find('.checkitem').removeClass('selected');
            $(this).parent().parent().parent().find('.province-list').find('.ecity').each(function () {
                $(this).find('.check-num').html('');
            });
        }else{
            layer.msg('亲，最少要留一个哦～');
        }
    } else {
        $(this).addClass('selected');
        $(this).parent().parent().parent().find('.checkitem').each(function () {
            $(this).addClass('selected');
        });
        $(this).parent().parent().parent().find('.province-list').find('.ecity').each(function () {
            check_num = '(' + $(this).find('.citys').find('.selected').size() + ')';
            if (check_num == '(0)') {
                check_num = '';
            }
            $(this).find('.check-num').html(check_num);
        });
    }
});

$('.J_City').on('click', function () {
    if ($(this).hasClass('selected')) {
        $(this).removeClass('selected');
        $(this).parent().find('.check-num').eq(0).html('');
        $(this).parent().find('.citys').eq(0).find('.checkitem').removeClass('selected');
        $(this).parent().parent().parent().parent().find('.J_Province').removeClass('selected');
    } else {
        $(this).addClass('selected');
        $(this).parent().find('.citys').eq(0).find('.checkitem').each(function () {
            $(this).addClass('selected');
        });
        var check_num = '(' + $(this).parent().find('.citys').eq(0).find('.selected').size() + ')';
        if (check_num == '(0)') {
            check_num = '';
        }
        $(this).parent().find('.check-num').eq(0).html(check_num);
        var input_checked = $(this).parent().parent().parent().find('.selected').size();
        var input_all = $(this).parent().parent().parent().find('.checkitem').size();
        if (input_all == input_checked) {
            $(this).parent().parent().parent().parent().find('.J_Province').addClass('selected');
        }
    }
});

$('.J_Area').on('click', function () {
    if ($(this).hasClass('selected')) {
        $(this).removeClass('selected');
        $(this).parent().parent().parent().find('.J_City').removeClass('selected');
        $(this).parent().parent().parent().parent().parent().parent().find('.J_Province').removeClass('selected');
    } else {
        $(this).addClass('selected');
        var input_checked = $(this).parent().parent().find('.selected').size();
        var input_all = $(this).parent().parent().find('.checkitem').size();
        if (input_all == input_checked) {
            $(this).parent().parent().parent().find('.J_City').addClass('selected');
        }
        input_checked = $(this).parent().parent().parent().parent().parent().find('.selected').size();
        input_all = $(this).parent().parent().parent().parent().parent().find('.checkitem').size();
        if (input_all == input_checked) {
            $(this).parent().parent().parent().parent().parent().parent().find('.J_Province').addClass('selected');
        }
    }
    var check_num = '(' + $(this).parent().parent().find('.selected').size() + ')';
    if (check_num == '(0)') {
        check_num = '';
    }
    $(this).parent().parent().parent().find('.check-num').eq(0).html(check_num);
});

// 区域默认勾选
if($('.citylist.add').length>0){
    $('.citylist .J_Province').addClass('selected');
    var a=$('.citylist .J_Province.selected').length,c='';
    for(var i=0;i<a;i++){
       var t=$('.citylist .ecity').eq(i).find('.J_Province.selected').attr('district_id');
       c+= ','+t;
       $('#regionid').val(c);
    }
}

//截取地址参数
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

// 菜单

$('.m_nav').on('click',function(){
    $('.m_subnav').toggle();
    $(this).toggleClass('down');
});


// 
if($('.js_leftnav').length>0){
    $('.container').removeClass('pd0');
}

// 获取sortby
//选中
function GetQueryString(name){
     var reg = new RegExp("(^|&)"+ name +"=([^&]*)(&|$)");
     var r = window.location.search.substr(1).match(reg);
     if(r!=null)return  unescape(r[2]); return null;
}
if(GetQueryString("SortBy")){
    var s=GetQueryString("SortBy"),a=$('a[data-sortby='+s+']');
    if(a.parents('.li').length>0){
        a.parents('.ul').show(); 
        a.parents('.li').addClass('show'); 
    }
}
if($('.footerbtn').length>0){
    $('.primary').addClass('pdbt100');
}