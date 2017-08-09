var init = parseInt(document.getElementById("init-slide").value);



$(document).ready(function () {
    $('.your-class').slick({
});

$('.slider-for').slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    arrows: false,
    fade: true,
    asNavFor: '.slider-nav'
});
$('.slider-nav').slick({
    slidesToShow: 3,
    slidesToScroll: 1,
    asNavFor: '.slider-for',
    dots: true,
    centerMode: true,
    focusOnSelect: true,
    variableWidth: true,
    initialSlide: init

});

 

});



