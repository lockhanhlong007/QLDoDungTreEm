$(function () {
    $('#AlertBox').removeClass('hide');
    $('#AlertBox').delay(1000).slideUp(500);
    $(".datepicker").datepicker({
        dateFormat: "yy-mm-dd",
        changeYear: true,
        changMoth: true,
        yearRange: "-100:+1",
        
    });
    
});

