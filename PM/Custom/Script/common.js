   
   // 提示窗口关闭
   $('.js_close').on('click',function(){
        $(this).parents('.js_popup').hide(500);
        $('.popup_bg').hide();
   });


   // 菜单
   $('.js_menu').on('mouseover',function(){
        $('.submenu').hide();
        $(this).parents('li').find('.submenu').show(500);
   });
   $('.menu').on('mouseleave','li',function(){
        $('.submenu').hide();
   });
   // 搜索提示
   $('.js_searchtips input').on('click',function(){
        $(this).parent().find('.tips').hide();
   });

    if($('.slider').length>0){
      var l=$('.slider_1 div').length;
      for (var i=0;i<=l;){
          if($('.slider_1 div').eq(i).find('img').attr('src')==''){
            $('.slider_1 div').eq(i).remove();
            i--
          }
          i++
      }
      // banner广告
      $('.slider').slick({
          arrows: true,
          dots: true,
          autoplay:true,
          speed:1000
      });
      // 品牌
      $('.slider_1').slick({
          arrows: false,
          slidesToShow: 8,
          slidesToScroll: 8,
          autoplay: true,
          autoplaySpeed: 5000
      });
      // 宣传
      $('.index_slider').slick({
          arrows: false,
          dots: true,
          autoplay:true,
      });    
    }
    // 顶部轮播
    $('.js_slider_bar').slick({
        arrows: false,
        dots: true,
        autoplay:true,
    }); 

    // 返回顶部
    //当滚动条的位置处于距顶部100像素以下时，跳转链接出现，否则消失
    $(window).on('scroll',function(){
        if ($(window).scrollTop()>200){
            $(".shortcut").show();
            $(".header").addClass("scroll");
            $(".js_barclasss").addClass("scroll");
        }else{
            $(".shortcut").hide();
            $(".header").removeClass("scroll");
            $(".js_barclasss").removeClass("scroll");
        }
    });
    var h=document.body.clientHeight;
    //回到顶部
    $(".shortcut").click(function(){
        $('html,body').animate({
            scrollTop:'0px'
        },
        2000);     
    });

    // 列表下拉
    // $('.productlist_left .li.show').find('a span').text('-');
    // $('.subli a.js_show').parents('.li').addClass('show');

    // 分类展开收起
    $('.list_left .class .li').on('click',function(){
        $(this).siblings().removeClass('show');
        $(this).toggleClass('show');
    });


    if($(".jqzoom").length>0){
        //鼠标经过预览图片函数
        function preview(img){
          $("#preview .jqzoom img").attr("src",$(img).attr("src"));
          $("#preview .jqzoom img").attr("jqimg",$(img).attr("bimg"));
        }

        //图片放大镜效果
        $(function(){
          $(".jqzoom").jqueryzoom({xzoom:380,yzoom:410});
        });

        //图片预览小图移动效果,页面加载时触发
        $(function(){
          var tempLength = 0; //临时变量,当前移动的长度
          var viewNum = 5; //设置每次显示图片的个数量
          var moveNum = 2; //每次移动的数量
          var moveTime = 300; //移动速度,毫秒
          var scrollDiv = $(".spec-scroll .items ul"); //进行移动动画的容器
          var scrollItems = $(".spec-scroll .items ul li"); //移动容器里的集合
          var moveLength = scrollItems.eq(0).width() * moveNum; //计算每次移动的长度
          var countLength = (scrollItems.length - viewNum) * scrollItems.eq(0).width(); //计算总长度,总个数*单个长度
            
          //下一张
          $(".spec-scroll .next").bind("click",function(){
            if(tempLength < countLength){
              if((countLength - tempLength) > moveLength){
                scrollDiv.animate({left:"-=" + moveLength + "px"}, moveTime);
                tempLength += moveLength;
              }else{
                scrollDiv.animate({left:"-=" + (countLength - tempLength) + "px"}, moveTime);
                tempLength += (countLength - tempLength);
              }
            }
          });
          //上一张
          $(".spec-scroll .prev").bind("click",function(){
            if(tempLength > 0){
              if(tempLength > moveLength){
                scrollDiv.animate({left: "+=" + moveLength + "px"}, moveTime);
                tempLength -= moveLength;
              }else{
                scrollDiv.animate({left: "+=" + tempLength + "px"}, moveTime);
                tempLength = 0;
              }
            }
          });
        });
    }
    // 侧边工具栏

    $('.js_qq').on('mouseover',function(){
       $('.js_windqq').show(); 
    });
    $('.js_windqq , .js_qq').on('mouseleave',function(){
       $('.js_windqq').hide(); 
    });

    $('.js_cart').on('mouseover',function(){
       $('.js_windcart').show(); 
    });
    $('.js_windcart , .js_cart').on('mouseleave',function(){
       $('.js_windcart').hide(); 
    });

    // 我的订单收货地址
    if($('.jd_od_address').length>0){
        $('.jd_od_address').on('click','li',function(){
            $('.jd_od_address li').removeClass('down'); 
            $(this).addClass('down');  
        });
        // 订单收货地址
        $('.js_more').on('click',function(){
            if($(this).hasClass('down')){
                $(this).removeClass('down');
                $('.od_address ul').removeClass('down'); 
            }else{ 
                $(this).addClass('down');
                $('.od_address ul').addClass('down');  
            }
        });
    }

    // 品牌展开
    if($('.js_brandmore').length>0){
      $('.js_brandmore').on('click',function(){ 
            $(this).toggleClass('down'); 
            $('.brand').toggleClass('down'); 
        });
    }


    // 切换
     $('.js_tabtop').on('click','a',function(){
          var t=$(this).index(),
              tn=$(this).attr('data-num');

          $('.js_tabtop a').removeClass('down');
          $(this).addClass('down');
          $(this).parents('.js_tabbody').find('.js_tabcont').hide();
          $(this).parents('.js_tabbody').find('.js_tabcont[data-num='+tn+']').show();
     });
     $('.js_tabtop_1').on('click','a',function(){
          var t=$(this).index(),
              tn=$(this).attr('data-num');

          $('.js_tabtop_1 li').removeClass('tabhover');
          $(this).parent().addClass('tabhover');
          $(this).parents('.js_tabbody_1').find('.js_tabcont_1').hide();
          $(this).parents('.js_tabbody_1').find('.js_tabcont_1[data-num='+tn+']').show();
     });
     
     $('.js_userbtn').on('click',function(){
          $(this).parents('.js_tabbody').find('.js_tabcont').hide();
          $(this).parents('.js_tabbody').find('.js_tabcont[data-num=2]').show();
     });

     // 选择头像

     $('.js_selectface').on('click','a',function(){
        $('.js_selectface a input[type=radio]').removeAttr('checked');
        $(this).find('input[type=radio]').attr('checked','checked'); 

        $('.js_selectface a').removeClass('down');
        $(this).addClass('down');
     });

     //展示购物车清单
     var ShowCartList = function(data) {
         var cartinfo = JSON.parse(data);
         var content = "";
         if(cartinfo != null && cartinfo.VTotalNum != 0) {
             content += '<div class="tool_cartlist">';
             var items = cartinfo.ItemCollect;
             for(var i = 0; i <= items.length - 1; i++) {
                 var item = items[i];
                 if(item.ContentInfo.VType == 0) {
                     //现金
                     content += '<div class="li">';
                     content += '<a href="">';
                     content += '<img src="'+item.ContentInfo.Pic+'">';
                     content += '<div class="pdt">'+item.ContentInfo.Name+'</div>';
                     content += '<div class="clear"></div>';
                     content += '</a>';
                     content += '<div class="pdt_jg">';
                     content += '¥ '+ Math.ceil(item.ContentInfo.Money)+' 元<br/> x '+ Math.ceil(item.Num) +'';
                     content += '</div>';
                     content += '<a href="javascript:;" class="cartclose" data-id="'+item.ID+'"><i class="iconfont">&#xe60d;</i></a>';
                     content += '</div>';
                 }else{
                     //积分
                     content += '<div class="li">';
                     content += '<a href="">';
                     content += '<img src="'+item.ContentInfo.Pic+'">';
                     content += '<div class="pdt">'+item.ContentInfo.Name+'</div>';
                     content += '<div class="clear"></div>';
                     content += '</a>';
                     content += '<div class="pdt_jg">';
                     content += ' '+ Math.ceil(item.ContentInfo.Jifen)+' '+item.ContentInfo.VPointTypeName+'<br/> x '+ Math.ceil(item.Num) +'';
                     content += '</div>';
                     content += '<a href="javascript:;" class="cartclose" data-id="'+item.ID+'"><i class="iconfont">&#xe60d;</i></a>';
                     content += '</div>';
                 }
             }
             content += '</div>';
             content += '<div class="tool_cartbtn">';
             content += '共 '+ Math.ceil(cartinfo.VTotalNum) +' 件商品<br/>';
             content += '<span>';
             if(cartinfo.VTotalMoney > 0) content += ''+Math.ceil(cartinfo.VTotalMoney)+'元';
             //if(cartinfo.VTotalJifen > 0) content += ''+Math.ceil(cartinfo.VTotalJifen)+'米粒';
             if (cartinfo.PointCollect != null && cartinfo.PointCollect.length > 0) {
                 for (var i = 0; i <= cartinfo.PointCollect.length - 1; i++) {
                     if (cartinfo.PointCollect[i].Point != 0) {
                         content += '' + Math.ceil(cartinfo.PointCollect[i].Point) + cartinfo.PointCollect[i].PointTypeName;
                     }
                 }
             }
             content += '</span>';
             content += '<a href="../../Cart/Index">去购物车结算</a>';
             content += '</div>';
         }else{
             content += '<div class="nottips">购物车中还没有商品，赶紧选购吧！</div>';
         }
         document.getElementById('cartlist').innerHTML = content;
         document.querySelector("#shopCart").querySelector("span").innerHTML = Math.ceil(cartinfo.VTotalNum);
     }
    
    //右侧购物车删除
     $(document).on('click','.cartclose',function(){
         var t = $(this).parents('tr'),itemid=$(this).attr('data-id');

         t.remove();
         //调用del删除数据库
         $.ajax({
             type: "POST",
             url: "../../Cart/Del",
             data: {"itemid":itemid},
             dataType: "json",
             success: function(data){
                 ShowCartList(data);
             }
         });
     });

    
    //if($('#search-form').length>0){
  //      var proposals = ['百度1', '百度2', '百度3', '百度4', '百度5', '百度6', '百度7','呵呵呵呵呵呵呵','百度','新浪','a1','a2','a3','a4','b1','b2','b3','b4'];
//
//        $(document).ready(function(){
//            $('#search-form').autocomplete({
 //             hints: proposals,
 //             width: 300,
 //             height: 30
  //          });
 //       });
 //   }
    // 区域切换

    $('.js_regiont').on('click',function(){
        layer.open({
            type: 1,
            title: '区域切换',
            area: ['700px', '400px'],
            shadeClose: true,
            content: $(".area_cont")
        });
    });

    if($(".area_cont").length>0){
        $(".area").treemenu({delay:300}).openActive();
        var h='(当前位置)',dataid=$('.current').attr('data-id');
        if(dataid!=0){
            $('.current').after(h);
        }
        $('.current').parents('li').addClass('tree-opened').removeClass('tree-closed');
        $('.current').parents('ul').show();
        $('.current').parents('ul').siblings().show();
        $('.current').siblings('ul').show();
        var t=$('.current').text();
        $('.point span em').text(t);
    }

    //订单查询
    $('.js_ordersearch').on('click', function() {
        layer.open({
            type: 1,
            title: '订单查询',
            area: ['280px', '150px'],
            shadeClose: true,
            content: $(".ordersearch"),
            btn: ['确定'],
            yes: function(index, layero){
                var content = $('#query').val().trim();
                if(content != null && content != "" && content != undefined)
                {
                    location.href = "../../Order/Query?Content=" + content;
                    layer.closeAll();
                }else
                {
                    layer.msg('查询条件不可为空');
                }
            }
        });
    });
    // 会员中心米粒历史记录
    if($('#js_ts_b').length>0 && $('#js_ts_1 li').length>1){
        var ts = document.getElementById('js_ts_b'),ts1 = document.getElementById('js_ts_1'),ts2 = document.getElementById('js_ts_2'),ts1_li=$('#js_ts_1 li');
        ts2.innerHTML=ts1.innerHTML;
        function Marquee(){
            if(ts.scrollLeft-ts2.offsetWidth>=0){
                ts.scrollLeft-=ts1.offsetWidth;
            }else{
                ts.scrollLeft++;
            }
        }
        var myvar=setInterval(Marquee,50);
        ts.onmouseout=function (){myvar=setInterval(Marquee,50);}
        ts.onmouseover=function(){clearInterval(myvar);}
    }

    // 历史米粒点击
    $('.js_tsmore').on('click',function(){
        layer.open({
            type: 1,
            title: '米粒历史记录',
            area: ['800px', '500px'],
            shadeClose: true,
            content: $(".user_historyjf_wind")
        });
    });

    // 关闭顶部广告
    $('.bar_banner .close').on('click',function(){
        $('.bar_banner').hide();
    });
    