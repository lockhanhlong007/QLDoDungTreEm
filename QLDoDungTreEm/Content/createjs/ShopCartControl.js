var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {

        $('.close').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: String($(this).data('id')) },
                url: '/ShopCart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/ShopCart/Index";
                    }
                }
            })
        });

        $('.value-plus').on('click', function () {
            var divUpd = $(this).parent().find('.value'),
                newVal = parseInt(divUpd.text(), 10) + 1;
            divUpd.text(newVal);
            var listProduct = $(this).parent().find('.value');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    quantity: $(item).text(),
                    Product: {
                        MaSP: $(item).data('id')
                    }
                });
            });
            $.ajax({
                url: '/ShopCart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/ShopCart/Index";
                    }
                }
            })
        });

        $('.value-minus').on('click', function () {
            var divUpd = $(this).parent().find('.value'),
                newVal = parseInt(divUpd.text(), 10) - 1;
            if (newVal >= 1) divUpd.text(newVal);
            var listProduct = $(this).parent().find('.value');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    quantity: $(item).text(),
                    Product: {
                        MaSP: $(item).data('id')
                    }
                });
            });
            $.ajax({
                url: '/ShopCart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/ShopCart/Index";
                    }
                }
            })
        });


    }
}
cart.init();