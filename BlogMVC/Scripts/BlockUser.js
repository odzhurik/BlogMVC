$("table").on("click", "a.BlockLink", function (e) {
    e.preventDefault();
    $.ajax(
        {
            url: $(this).attr("href"),
            type: 'POST',
            dataType: 'json',
            cache: false,
            success: function (result) {
                if (result === "Ok") {
                    location.reload();
                }
            }
        }
    );
}
);