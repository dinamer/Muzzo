var GigsController = function (attendanceService) {

    var button;

    var init = function (container) {

        $(container).on("click", ".jsAttend", toggleAttendance);
    };

    var toggleAttendance = function (e) {
        
        button = $(e.target);
        
        var gigId = button.attr("data-gig-id");

            if (button.hasClass("btn-default"))
                AttendanceService.createAttenance(gigId, done, fail);
            else
                AttendanceService.deleteAttenance(gigId, done, fail);
    };


    var fail = function () {

        bootbox.alert("Something went wrong.");

    };

    var done = function () {

        var newText = (button.text() == "Going?") ? "Going" : "Going?";
        
        button.toggleClass("btn-default").toggleClass("btn-info").text(newText);

    };



    return {

        init: init

    }

}(AttendanceService);