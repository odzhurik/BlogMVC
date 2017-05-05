var modelID = $("#ID").val();
$(function () {
    GetComments(modelID);
}
);
$("#AddComment").click(function (e) {
    e.preventDefault();
    $.ajax({
        url: '/Comments/Create/?PostID=' + modelID,
        type: "GET",
        dataType: "html",
        contentType: "application/html; charset=utf-8",
        success: function (data) {
            $("#CommentCreate").html(data);
        },
        error: function (xhr) {
            alert('error');
        }
    });
});
$("div#CommentCreate").on("click", "input#CreateBtn", function (e) {
    e.preventDefault();
    var data = {
        comment:
        {
            Text: $("#CommentText").val(),
            Time: $("#Time").val(),
            PostID: $("#PostID").val(),
            UserID: $("#UserID").val()
        }
    }
    $.ajax({
        type: "POST",
        url: "/Comments/Create/",
        contentType: "application/json",
        data: JSON.stringify(data)

    })
        .success(
        function () {
            $("#CommentCreate").empty();
            GetComments(modelID);
        }
        )
}
);
$("div#CommentsList").on("click", "a.EditComment", (function (e) {
    e.preventDefault();
    var id = $(this).attr("id");
    $.ajax({
        type: "GET",
        url: $(this).attr("href")
    })
        .success(
        function (result) {
            $("#" + id).html(result);
        }
        )

}));
$("div#CommentsList").on("click", "a.DeleteComment", (function (e) {
    e.preventDefault();
    $.ajax({
        type: "POST",
        url: $(this).attr("href")

    })
        .success(
        function (result) {
            GetComments(modelID);
        }
        )

}));
$("div#CommentsList").on("click", "input#EditCommentBtn", (function (e) {
    e.preventDefault();
    var data = {
        comment:
        {
            ID: $("#CommentID").val(),
            Text: $("#CommentText").val(),
            Time: $("#CommentTime").val(),
            PostID: $("#PostID").val(),
            UserID:$("#UserID").val()
        }
    }
    $.ajax({
        type: "POST",
        url: "/Comments/Edit/",
        contentType: "application/json",
        data: JSON.stringify(data)
    })
        .success(
        function (result) {
            GetComments(modelID);
        }
        )
}));
function GetComments(id) {
    $.ajax({
        type: "GET",
        url: "/Comments/GetComments/?PostID=" + id,
        cache: false
    })
        .success(
        function (result) {

            $("#CommentsList").html(result);
        }
        )
}