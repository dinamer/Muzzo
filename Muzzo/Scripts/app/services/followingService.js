var FollowingService = function () {

    var createFollowing = function (followeeId, fail, done) {

        $.post("/api/followings", { followeeId: followeeId })
            .done(done)
            .fail(fail);

    };


    var deleteFollowing = function (followeeId, fail, done) {

        $.ajax({
            url: "/api/followings/" + followeeId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail);
    };


    return {

        createFollowing: createFollowing,
        deleteFollowing: deleteFollowing

    }
}();





