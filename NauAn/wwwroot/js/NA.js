$(document).ready(function () {
    $.ajax({
        method: 'GET',
        url: '/danhmuc',
        async: false,
        contentType: 'application/json;charset=utf-8',
        dataType: 'json'
    }).done(function (res) {
        $.each(res, function (index, item) {
            var div = '<div class="detail-nav" recordID="' + item.id + '"><a href>' + item.name + '</a></div>';
            $("#side-bar").append(div);
        })
    })
    $(document).on("click", '.detail-nav', function (e) {    
        e.preventDefault()
        var id = $(this).attr('recordID');
        let url = '/PostCategory/' + id;

        window.location.replace(url);
    });
    $(document).on("click", '#btnSearch', function (e) {
        debugger
        e.preventDefault()
        var searchString = $("#search").val();
        let url = '/SearchPost/' + searchString;

        window.location.replace(url);
    });

    //$.ajax({
    //    method: 'GET',
    //    url: '/HotPost',
    //    async: false,
    //    contentType: 'application/json;charset=utf-8',
    //    dataType: 'json'
    //}).done(function (res) {
    //    debugger
    //    $.each(res, function (index, item) {
    //        var div = '<div' + item.PostName+'</div>';
    //        $("#hot-post").append(div);
    //    })
    //    })

    $.ajax({
        url: '/HotPost',
        type: 'GET',
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $('#milestonesContainer').html(data);
        }
    });
})