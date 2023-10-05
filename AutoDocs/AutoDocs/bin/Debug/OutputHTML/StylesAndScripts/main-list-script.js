$(document).ready(function() {
    $('details').on('click', function() {
        if (!$(this).attr('open')) {
            $(this).find('> ul').hide().slideDown(300);
        } else {
            $(this).find('> ul').slideUp(300);
        }
    });
});