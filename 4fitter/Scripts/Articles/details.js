$(document).ready(() => {
    var userId = $('#userId').text();
    var articleId = $('#articleId').text();

    $.get('/Bookmarks/Check/' + articleId + '?userId=' + userId, (data) => {
        if (data === 'True') {
            showFavRemoveButton();
        } else {
            showFavAddButton();
        }
    });
});

$('#favorites-add').click(() => {

    var userId = $('#userId').text();
    var articleId = $('#articleId').text();

    $.post('/Bookmarks/Create',
    {
        userID: userId,
        articleID: articleId
    }).done((data) => {
        if (data === 'OK') {
            showFavRemoveButton();
        }
        else {
            alert(data);
        }
    });
});

$('#favorites-remove').click(() => {

    var userId = $('#userId').text();
    var articleId = $('#articleId').text();

    $.post('/Bookmarks/Delete/' + articleId + '?userId=' + userId).done((data) => {
            if (data === 'OK') {
                showFavAddButton();
            }
            else {
                alert(data);
            }
        });
});

var showFavRemoveButton = () => {
    $('#favorites-remove').css('display', 'block');
    $('#favorites-add').css('display', 'none');
};

var showFavAddButton = () => {
    $('#favorites-remove').css('display', 'none');
    $('#favorites-add').css('display', 'block');
};