$('#favorites-action').click(() => {

    var userId = $('#userId').text();
    var articleId = $('#articleId').text();

    $.post("/Bookmarks/Create",
        {
            userID: userId,
            articleID: articleId
        });
});