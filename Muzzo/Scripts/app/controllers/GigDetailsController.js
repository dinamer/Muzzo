var GigDetailsController = function (followingService) {

    var button;

    var init = function () {

        $(".jsFollow").click(toggleFollow);
    };

    var toggleFollow = function (e) {

        button = $(e.target);

        var followeeId = button.attr("data-followee-id");

            if (button.hasClass("btn-default"))
                    FollowingService.createFollowing(followeeId, fail, done);
            else
                    FollowingService.deleteFollowing(followeeId, fail, done);
    };

    var done = function () {
        
        var newText = (button.text() == "Follow") ? "Following" : "Follow";
            
        button.toggleClass("btn-info").toggleClass("btn-default").text(newText);

    };


    var fail = function () {

        bootbox.alert("Something went wrong.");
    };


    return { init: init }

}(FollowingService);








