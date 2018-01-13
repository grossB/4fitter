$(document).ready(() => {

    var userId = $('#userId').text();

    $.get('/Bookmarks/User/?userId=' + userId, (data) => {

        for (var i = 0; i < data.length; i++) {

            $('#bookmarked-articles').append('<a href="/Articles/' + data[i].Article.FriendlyID + '">' + data[i].Article.Title + '</a><br />');
        }

    });
});