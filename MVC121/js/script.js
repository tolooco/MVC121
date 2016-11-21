

Pace.on("start", function(){
    $("#preloader").show();
});


(function ($) {
  "use strict";
Pace.on("done", function(){
  

function getMainColor(className) {
    var classes = document.styleSheets[0].rules || document.styleSheets[0].cssRules;
  
    for (var x = 0; x < classes.length; x++) {
        if (classes[x].selectorText == className) {
            return  classes[x].style.color ;
        }
    }
}

var mainColor = getMainColor(".main-color");


 
      $('#status').fadeOut(); // will first fade out the loading animation
    $('#preloader').delay(1000).fadeOut('slow'); // will fade out the white DIV that covers the website.
    $('body').delay(1000).css({'overflow-x': 'hidden'}).css({'overflow-y': 'auto'});


  FastClick.attach(document.body);

  $('.le-animate').addClass('animation-init');
  $('.le-page').addClass('hidden');
  $('.le-page.active').removeClass('hidden');
      openPage('#home');
      $('.le-animate.play-on-start').each(function(){
  animationTrigger($(this).attr('data-animation-in'), $(this), $(this).attr('data-delay'));
});

    // set initial div height / width
    if($(window).width()>992){
    var winWidth = $(window).width();
    var winHeight = $(window).height();

   

 
  }else{
        
     var winWidth = $(document).width();
    var winHeight = 'auto';
  }
   $('.wrapper').css({
      width: winWidth,
      height: winHeight
    });
    if( $(window).height()<600){
           $('.wrapper').css({
        'min-height': 600
      });
        }
        
    // make sure div stays full width/height on resize
     $(window).resize(function () {
     
           if($(window).width()>992 && $(window).height()>600){
     winWidth = $(window).width();
  winHeight = $(window).height();
      $('.wrapper').css({
        'width': winWidth,
        'height': winHeight
      });
    }else{
      
           winWidth = $(window).width();
  winHeight = $(document).height();
       $('.wrapper').css({
        'width': winWidth,
         'height': winHeight
      });
       
    }
    });
    function getImgSize(el, imgSrc) {
      var newImg = new Image();
      newImg.onload = function () {
        var height = newImg.height;
        var width = newImg.width;
        el.css('height', height);
      };
      newImg.src = imgSrc;
    }

    if ($('.bg-image[data-bg-image]').length > 0) {
      $('.bg-image[data-bg-image]').each(function () {
        var el = $(this);
        var sz = getImgSize(el, el.attr("data-bg-image"));
        el.css('background-position', 'center').css('background-image', "url('" + el.attr("data-bg-image") + "')").css('background-size', 'cover').css('background-repeat', 'no-repeat');
      });
    }

    if ($('.bg-color[data-bg-color]').length > 0) {
      $('.bg-color[data-bg-color]').each(function () {
        var el = $(this);
        el.css('background-color', el.attr("data-bg-color"));
      });
    }



    /*
     * Replace all SVG images with inline SVG
     */
    $('img.svg').each(function () {
      var $img = jQuery(this);
      var imgID = $img.attr('id');
      var imgClass = $img.attr('class');
      var imgURL = $img.attr('src');
      jQuery.get(imgURL, function (data) {
        // Get the SVG tag, ignore the rest
        var $svg = jQuery(data).find('svg');
        // Add replaced image's ID to the new SVG
        if (typeof imgID !== 'undefined') {
          $svg = $svg.attr('id', imgID);
        }
        // Add replaced image's classes to the new SVG
        if (typeof imgClass !== 'undefined') {
          $svg = $svg.attr('class', imgClass + ' replaced-svg');
        }

        // Remove any invalid XML tags as per http://validator.w3.org
        $svg = $svg.removeAttr('xmlns:a');
        // Replace image with new SVG
        $img.replaceWith($svg);
      }, 'xml');
    });
    $('[data-placeholder]').focus(function () {
      var input = $(this);
      if (input.val() == input.attr('data-placeholder')) {
        input.val('');
      }
    }).blur(function () {
      var input = $(this);
      if (input.val() == '' || input.val() == input.attr('data-placeholder')) {
        input.addClass('placeholder');
        input.val(input.attr('data-placeholder'));
      }
    }).blur();
    $('[data-placeholder]').parents('form').submit(function () {
      $(this).find('[data-placeholder]').each(function () {
        var input = $(this);
        if (input.val() == input.attr('data-placeholder')) {
          input.val('');
        }
      });
    });



$(".nice-scroll").each(function(){
   $(this).niceScroll({
          cursorcolor:mainColor,
        mousescrollstep: 126, // scrolling speed with mouse wheel (pixel)
        touchbehavior: true,
        cursorborder:0,
        
        railalign: $(this).attr('data-scroll-align')
      });
});
       
  
if($('.skill-meter').length>0){
$('.skill-meter').each(function(){
  var value=  $(this).attr('data-value');
  for(var i=0;i<value;i++){
      $(this).append('<div class="skill-bar up"></div>');
  }
 for(var i=0;i<5-value;i++){
      $(this).append('<div class="skill-bar"></div>');
  }
   $(this).append('<div class="skill-bar junk"></div>');
});
}


//start Homepage;
  
//    Animations manager


$('.le-animate[data-stay]').each(function(){
  animationTrigger($(this).attr('data-animation-in'), $(this), $(this).attr('data-delay'));

  animationTrigger($(this).attr('data-animation-out'), $(this), $(this).attr('data-stay'));


});


    animationTrigger($('#avatar').attr('data-animation-in'), $('#avatar'), $('#avatar').attr('data-delay'));




    function openPage(pageID) {

      var prevPage = $('.le-page.active').length > 0 ? $('.le-page.active') : null;

      //end Previous Page animations.

      if (prevPage !== null) {
        
if(prevPage.attr('ID')==='contact'){
  $('#avatar').addClass('move-down');
      }else{
          $('#avatar').removeClass('move-down');
      }

        prevPage.removeClass('active');
        var totalAnimEls = prevPage.find('.le-animate').length;
        var i = 0;

        prevPage.find('.le-animate').each(function (el) {
          i++;
          var prevPageAnimEl = $(this);
          var animOut = prevPageAnimEl.attr('data-animation-out');
          var animIn = prevPageAnimEl.attr('data-animation-in');

          prevPageAnimEl.velocity("stop");//stop all animations that made by jquery




          if (animOut !== undefined) {


            animationTrigger(animOut, prevPageAnimEl, 0);

           
          }else{
          prevPageAnimEl.velocity("reverse",{display:"none"});
          }
          prevPageAnimEl.addClass('animating').addClass('animation-outro');

   
     
          setTimeout(function(){
             if(prevPageAnimEl.hasClass('animation-outro')){ 
 prevPageAnimEl.removeClass('animation-done').removeClass('animation-outro').removeClass('animating').addClass('animation-init');
   
            
           
          }   
      if(prevPage!==null && !prevPage.hasClass('hidden')){
           prevPage.addClass('hidden');
         }
          },1500);





          if (i >= totalAnimEls) {
         
            
            startPage(pageID);
          }

        });


        //----------------//

      } else {
        startPage(pageID);
      }
    }

    function startPage(pageID) {
     



      $(pageID).addClass('active');
 if($(pageID).hasClass('hidden')){
           $(pageID).removeClass('hidden');
         }
      var activePage = $('.le-page.active');

if($(pageID).hasClass('hide-avatar')){
  $('#avatar').addClass('is-hidden');
           animationTrigger('bounceDownOut', $('#avatar'), 0);
}
if($(pageID).hasClass('single-post')){
 $('.background-lines div').addClass('narrow');
}else{
$('.background-lines div').removeClass('narrow');
}

if(pageID==='#contact'){
      checkContactForm();
  $('#avatar').addClass('move-up');
      }else{
          $('#avatar').removeClass('move-up');
      }



if($(pageID).hasClass('show-avatar') && $('#avatar').hasClass('is-hidden')){
  $('#avatar').removeClass('is-hidden');
 var anim= $('#avatar').attr('data-animation-in');
           animationTrigger(anim, $('#avatar'), 0);
}
  
      activePage.find('.le-animate').each(function () {
        var el = $(this);
        if(!el.hasClass('no-play-first')){
        var animIn = el.attr('data-animation-in');
        var delay = el.attr('data-delay');



        animationTrigger(animIn, el, delay);

        }
      });

    }



    function animationTrigger(animType, el, delay, duration) {
      
      delay = parseInt(delay);
      if (duration === undefined) {
        duration = 1000;
      }


      switch (animType) {
        
         case 'showIn':
           el.velocity("fadeIn", {display: "block",delay: 0, duration: 0, begin: function(e) {  startElAnim(el); } , complete: function(e){ endElAnim(el); } });

          break;
         case 'bounceIn':
           el.velocity("transition.expandIn", {display: "block",delay: delay, duration: duration, begin: function(e) {  startElAnim(el); } , complete: function(e){ endElAnim(el); } });

          break;
        case 'fadeIn':
           el.velocity("fadeIn", {display: "block",delay: delay, duration: duration, begin: function(e) {  startElAnim(el); } , complete: function(e){ endElAnim(el); } });

          break;
           case 'fadeOut':
           el.velocity("fadeOut", {display: "none",delay: delay, duration: duration, begin: function(e) {  startElAnim(el); } , complete: function(e){ endElAnim(el); } });

          break;
         case 'expandIn':
           el.velocity("transition.expandIn", {display: "block",delay: delay, duration: duration, begin: function(e) {  startElAnim(el); } , complete: function(e){ endElAnim(el); } });

          break;
         case 'flipYOut':
           el.velocity("transition.flipYOut", {display: "none" ,delay: delay, duration: duration, begin: function(e) {  startElAnim(el); } , complete: function(e){ endElAnim(el); } });

          break;
        case 'bounceRightIn':
           el.velocity("transition.bounceRightIn", {display: "block",delay: delay, duration: duration, begin: function(e) {  startElAnim(el); } , complete: function(e){ endElAnim(el); } });

          break;
        case 'bounceLeftIn':
             el.velocity("transition.bounceLeftIn", {display: "block",delay: delay, duration: duration, begin: function(e) {  startElAnim(el); } , complete: function(e){ endElAnim(el); } });
          break;
        case 'bounceDownIn':
          el.velocity("transition.bounceDownIn", {display: "block",delay: delay, duration: duration, begin: function(e) {  startElAnim(el); } , complete: function(e){ endElAnim(el); } });
          break;
        case 'bounceUpIn':
          el.velocity("transition.bounceUpIn", {display: "block",delay: delay, duration: duration, begin: function(e) {  startElAnim(el); } , complete: function(e){ endElAnim(el); } });
          break;

        case 'bounceRightOut':
          el.velocity("transition.bounceRightOut", {display: "none" , delay: delay, duration: duration, begin: function(e) {  startElAnim(el); } , complete: function(e){ endElAnim(el); } });
          break;
        case 'bounceLeftOut':
          el.velocity("transition.bounceLeftOut", {display: "none" ,delay: delay, duration: duration, begin: function(e) {  startElAnim(el); } , complete: function(e){ endElAnim(el); } });
          break;
        case 'bounceDownOut':
          el.velocity("transition.bounceDownOut", {display: "none" ,delay: delay, duration: duration, begin: function(e) {  startElAnim(el); } , complete: function(e){ endElAnim(el); } });
          break;
        case 'bounceUpOut':
          el.velocity("transition.bounceUpOut", {display: "none" ,delay: delay, duration: duration, begin: function(e) {  startElAnim(el); } , complete: function(e){ endElAnim(el); } });
          break;

        case 'slideRightIn':
          el.velocity("transition.slideRightIn", {display: "block",delay: delay, duration: duration,  begin: function(e) {  startElAnim(el); } , complete: function(e){ endElAnim(el); } });
          break;

        case 'slideLeftIn':
          el.velocity("transition.slideLeftIn", {display: "block",delay: delay, duration: duration,  begin: function(e) {  startElAnim(el); } , complete: function(e){ endElAnim(el); } });
          break;

        case 'slideUpIn':
          el.velocity("transition.slideUpIn", {display: "block",delay: delay, duration: duration, begin: function(e) {  startElAnim(el); } , complete: function(e){ endElAnim(el); } });
          break;
        case 'slideDownIn':
          el.velocity("transition.slideDownIn", {display: "block",delay: delay, duration: duration, begin: function(e) {  startElAnim(el); } , complete: function(e){ endElAnim(el); } });
          break;

        case 'slideRightOut':
          el.velocity("transition.slideRightOut", {display: "none" ,delay: delay, duration: duration, begin: function(e) {  startElAnim(el); } , complete: function(e){ endElAnim(el); } });
          break;
        case 'slideLeftOut':
          el.velocity("transition.slideLeftOut", {display: "none" ,delay: delay, duration: duration, begin: function(e) {  startElAnim(el); } , complete: function(e){ endElAnim(el); } });
          break;
        case 'slideUpOut':

          el.velocity("transition.slideUpOut", {display: "none" ,delay: delay, duration: duration, begin: function(e) {  startElAnim(el); } , complete: function(e){ endElAnim(el); } });
          break;

        case 'slideDownOut':

          el.velocity("transition.slideDownOut", {display: "none" ,delay: delay, duration: duration });
          break;

        default:

          break;
      }

   
     function startElAnim(el) {
       el.addClass('animating').removeClass('animation-init');
      };

 function endElAnim(el) {
       el.removeClass('animating').addClass('animation-done');
     
      };



    }



    $('.page-turner').click(function (e) {
      var target = $(this).attr('href');
       $('.page-turner').address(target);

    
    });


 $(".owl-carousel").owlCarousel({
      pagination: false,
      items: 4, //10 items above 1000px browser width
      itemsDesktop: [1200, 3], //5 items between 1000px and 901px
      itemsDesktopSmall: [990, 2], // betweem 900px and 601px
      itemsTablet: [570, 1], //2 items between 600 and 0
     
      itemsMobile: false // itemsMobile disabled - inherit from itemsTablet option
    });
    var owl = $(".owl-carousel").data('owlCarousel');

    $(".owl-carousel").parent().find('.nav-buttons .btn-prev').click(function (e) {
      e.preventDefault();
      owl.prev();
    });

    $(".owl-carousel").parent().find('.nav-buttons .btn-next').click(function (e) {
      e.preventDefault();
      owl.next();
    });


  $('.goto-top').click(function (e) {
    e.preventDefault();
    $('html,body').animate({
      scrollTop: 0
    }, 2000);
  });
  if ($('a[data-rel="prettyphoto"]').length > 0) {
    $('a[data-rel="prettyphoto"]').prettyPhoto();
  }
  if ($('a[data-rel="prettyPhoto"]').length > 0) {
    $('a[data-rel="prettyPhoto"]').prettyPhoto();
  }






//hashtag navigation address setup (deeplink)
  $('.nav-menu a').address($(this).attr('href'));
  
  $('.top-drop-menu').change(function () {
    var loc = ($(this).find('option:selected').val());
    $('.nav-menu a').address(loc);
  });
  
  $.address.change(function (event) {
    var pageID = event.value.split('/')[1];
    if (pageID != '' && pageID.indexOf('.') === -1) {
      var el = $(".nav-menu [href=#" + pageID + "]");
      $('.nav-menu .active').removeClass('active');
    
      openPage("#"+pageID);
      el.parent().addClass('active');
      $('select.nav option').each(function () {
        var val = $(this).val();
        if (val === "#" + pageID) {
          $('select.nav option:selected').removeAttr('selected');
          $(this).attr('selected', 'selected');
        }
      });
      scrollToSection("#" + pageID);
    } else {
      if (pageID.indexOf('.') > -1) {
        window.location = pageID;
      }
    }
  });
  $('select.nav').change(function () {
    var loc = ($(this).find('option:selected').val());
    scrollToSection(loc);
  });
  function scrollToSection(destSection) {

//    $('html, body').stop().animate({
//      scrollTop: $(destSection).offset().top + scrollOffset
//    }, 2000, 'easeInOutExpo');
  }

  $('.nav-menu a').bind('click', function (event) {
    event.preventDefault();
    var clickedMenu = $(this);
    $('.nav-menu .active').toggleClass('active');
    clickedMenu.parent().toggleClass('active');
            // scrollToSection(clickedMenu.attr('href'));
  });
  

    
        });
    //Contact form setup
    

  function checkContactForm() {
    if ($(".contact-form").length > 0) {
      var formStatus = $(".contact-form").validate();
      //   ===================================================== 
      //sending contact form
      $(".contact-form").submit(function (e) {
        e.preventDefault();
        //  triggers contact form validation
        if (formStatus.errorList.length === 0)
        {
          $(".contact-form .submit").fadeOut(function () {
            $('#loading').css('visibility', 'visible');
            $.post('submit.ASP.NET,C#,MVC,SQL', $(".contact-form").serialize(),
                    function (data) {
                      $(".contact-form input,.contact-form textarea").not('.submit').val('');
                      $('.message-box').html(data);
                      $('#loading').css('visibility', 'hidden');
                      $(".contact-form").css('display', 'none');
                      //$(".contact-form .submit").removeClass('disabled').css('display', 'block');
                    }
            );
          });
        }
      });
    }
  }

})(jQuery);
// Sticky Nav
$(window).scroll(function (e) {
  var nav_anchor = $(".top-menu-holder");
  var gotop = $(document);
  if ($(this).scrollTop() >= 500) {
    $('.goto-top').css({'opacity': 1});
  } else if ($(this).scrollTop() < 500)
  {
    $('.goto-top').css({'opacity': 0});
  }
  if ($(this).scrollTop() >= $('header').height())
  {
    nav_anchor.addClass('split');
  }
  else if ($(this).scrollTop() < $('header').height())
  {
    nav_anchor.removeClass('split');
  }
});
/**
 Provides requestAnimationFrame in a cross browser way.
 @author paulirish / http://paulirish.com/ */
if (!window.requestAnimationFrame) {
  window.requestAnimationFrame = (function () {
    return window.webkitRequestAnimationFrame ||
            window.mozRequestAnimationFrame ||
            window.oRequestAnimationFrame ||
            window.msRequestAnimationFrame ||
            function (/* function FrameRequestCallback / callback, / DOMElement Element */ element) {
            };
  })();
}