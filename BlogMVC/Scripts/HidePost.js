$("#HidePost").click(function (e) {
    e.preventDefault();
    $.ajax({
        url: $(this).attr("href"),
        type: "GET",
        dataType: 'json',
        success: function (data) {
            if (data === "Ok") {
                location.reload();
            }
        },
        error: function (xhr) {
            alert('error');
        }
    });
}
);