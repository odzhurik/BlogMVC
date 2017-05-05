$("#Name").blur(function () {
    $.ajax({
        url: '/Account/CheckUserName/?userName=' + $("#Name").val(),
        type: "GET",
        dataType: 'json',
        success: function (data) {
            if (data === "Exist") {
                var errorArray = {};
                errorArray["Name"] = 'UserName is used';
                $('form').validate().showErrors(errorArray);
                $("input[type='submit']").attr("disabled", true);
            }
            if (data === "Ok") {
                $("input[type='submit']").attr("disabled", false);
            }
        },
        error: function (xhr) {
            alert('error');
        }
    });
}
);