$(document).ready(function () {
    $('#input').cleditor();

    $('#button-submit').click(function () {
        $('#article-content').val(getArticleAsHtml());
    });

    $('#Title').on('input', function (e) {
        var titleValue = $('#Title').val();

        $('#FriendlyID').val(createFriendlyId(titleValue));
    });
});

function getArticleAsHtml() {
    return $('iframe').contents().find('html').html();
};

function createFriendlyId(title) {
    var result = '';
    var forbiddenChars = ['ń', 'ą', 'ś', 'ć', 'ź', 'ż', 'ó', 'ł', 'ę', '.', ',', ';', '/', '*'];

    for (var i = 0; i < title.length; i++) {
        var char = title[i].toLowerCase();

        if (char === ' ') {
            result += '-';
            continue;
        }
        if ($.inArray(char, forbiddenChars) !== -1) {
            continue;
        }
        result += char;
    }
    return result;
}

