$(function () {
    $.ajax({
        url: '/Category/GetCategories/',
        type: "GET",
        dataType: 'json',
        cache: false,
        success: function (data) {
            for (var i = 0; i < data.length; i++) {
                $('<option/>').val(data[i].ID).html(data[i].Name).appendTo('#CategoryList');
            }
        },
        error: function (xhr) {
            alert('error');
        }
    });

}
);