var AttendanceService = function () {

    var createAttendance = function (gigId, done, fail) {
        $.post("/api/attendances", { gigId: gigId })
                .done(done)
                .fail(fail);
    };

    var deleteAttenance = function (gigId, done, fail) {
        $.ajax({
            url: "/api/attendances/" + gigId,
            method: "DELETE"
        })
                .done(done)
                .fail(fail);
    };

    return {

        createAttenance: createAttendance,
        deleteAttenance: deleteAttenance
    }

}();