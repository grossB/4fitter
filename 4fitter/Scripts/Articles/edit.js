$(document).ready(function () {
    $('#input').cleditor();

    var taggle;
    var rawTags = $('#raw-tags').val();

    if (rawTags === "") {
        taggle = new Taggle('tags');
    }
    else {
        taggle = new Taggle('tags', {
            tags: rawTags.split(',')
        });
    }

    $('#button-submit').click(function () {
        $('#article-content').val(getArticleAsHtml());
        $('#raw-tags').val(getRawTags(taggle.tag.values));
    });

    $('#Title').on('input', function (e) {
        var titleValue = $('#Title').val();

        $('#FriendlyID').val(createFriendlyId(titleValue));
    });
});

function getArticleAsHtml() {
    return $('iframe').contents().find('html').html();
}

function createFriendlyId(title) {
    var result = '';
    var forbiddenChars = ['ń', 'ą', 'ś', 'ć', 'ź', 'ż', 'ó', 'ł', 'ę', '.', ',', ';', '/', '*', '[', ']', '!', '?'];

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

function getRawTags(tagsArray) {
    var result = "";

    for (var i = 0; i < tagsArray.length; i++) {
        result += i < tagsArray.length - 1 ? tagsArray[i] + ',' : tagsArray[i];
    }

    return result;
}