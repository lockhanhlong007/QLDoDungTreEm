var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/DonHang/ChangeTinhTrangGiao",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.TinhTrangGiaoHang == true) {
                        btn.text('Đã Giao');
                    }
                    else {
                        btn.text('Chưa Giao');
                    }
                }
            });
        });
    }
}
user.init();


