$(document).ready(function () {
    $(function () {
        $.ajax({
            url: '/Category/GetCategories/',
            type: "GET",
            dataType: 'json',
            cache: false,
            success: function (data) {
                for (var i = 0; i < data.length; i++) {
                    $('<a/>').attr("href", "/Blog/GetByCategory/" + data[i].ID).html(data[i].Name).appendTo('#CategoryListBlog');
                }
            }

        });
    }
    );
    $(function () {
        $.ajax({
            url: '/Category/GetCategories/',
            type: "GET",
            dataType: 'json',
            cache: false,
            success: function (data) {
                for (var i = 0; i < data.length; i++) {
                    $('<a/>').attr("href", "/Post/GetByCategory/" + data[i].ID).html(data[i].Name).appendTo('#CategoryListPost');
                }
            }

        });
    }
    );
    $("#CategoryListBlog").on("click", "a", function (e) {
        e.preventDefault();
        $.ajax({
            url: $(this).attr("href"),
            type: "GET",
            dataType: 'json',
            cache: false,
            success: function (data)
            {
                $('#BlogsList').empty();
                for (var i = 0; i < data.length; i++)
                {
                    $('<p/>').html(
                    $('<a/>').attr("href", "/Post/Index/" + data[i].ID).html(data[i].Title)).appendTo('#BlogsList');
                }
            }
        });
    }
    );
    $("#CategoryListPost").on("click", "a", function (e) {
        e.preventDefault();
        $.ajax({
            url: $(this).attr("href"),
            type: "GET",
            dataType: 'json',
            cache: false,
            success: function (data) {
                $('#PostsList').empty();
                for (var i = 0; i < data.length; i++) {
                    $('<p/>').html(
                        $('<a/>').attr("href", "/Post/Details/" + data[i].ID).html(data[i].Title)).appendTo("#PostsList");
                }
            }
        });
    }
    );
});