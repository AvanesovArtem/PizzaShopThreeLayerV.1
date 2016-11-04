$(document).ready(function () {
    $("table").bind("DOMSubtreeModified", function () {
     
        var products = $(".ProductPrice");
        var buff = 0;
        products.each(function () {

            buff += parseInt($(this).text());
        });
        $("#resultSpan").text(buff);
    });
    var prod = $(".ProductPrice");
    var buf = 0;
    prod.each(function () {

        buf += parseInt($(this).text());
    });
    $("#resultSpan").text(buf);


    $("#FormUpload").validate({
        rules: {
            Name: {
                required: true,
                minlenght: 2,
                maxlength:10
            },
            Description: {
                required: true,
                minlenght: 2,
                maxlength: 120
            },
            Price: {
                required: true,
                minlenght: 1,
                maxlength: 120
           }
        },
        messages:{
            Name: {
               required: "Введите название продукта",
               minlength:"Не менее двух символов"
                  },
            Description: {
              required: "Введите описание продукта",
              minlength: "Не менее 5 символов",
              maxlength: "не более 120 символов"
                  },
            Price: {
                required: "Введите цену",
              
            }
        }
    });

});