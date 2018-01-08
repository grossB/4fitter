$(document).ready(function () {
    $("#input").cleditor();

    $('#button-submit').click(function () {
        $("#article-content").val(getArticleAsHtml());
    });
});

function getArticleAsHtml() {
    return $("iframe").contents().find("html").html();
};

