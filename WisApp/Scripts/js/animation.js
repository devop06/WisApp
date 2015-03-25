
	var lastScrollTop = 0;

		$(window).scroll(function () {
		  
		var st = $(this).scrollTop();
		        if (st < lastScrollTop){
		            $('.disparition').fadeIn();
		        } else {
		          $('.disparition').fadeOut();
		        }
		        lastScrollTop = st;
		  })
