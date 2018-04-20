moment.locale("en-au");

$(document).on("ready", function () {
    var $dateAndTime = $("#dateandtime");
    $dateAndTime.hide();
    $dateAndTime.before($('<input class="form-control text-box single-line" id="dateandtime_dtp" name="dateandtime_dtp" type="text">'));

    var $dateAndTimeDTP = $("#dateandtime_dtp");
    $dateAndTimeDTP.val($dateAndTime.val());
    var dtp = $dateAndTimeDTP.datetimepicker({
        format: "DD/MM/YYYY hh:mm:ss a",
        sideBySide: true
    })
    dtp.on("dp.change", function (e) {
        $dateAndTime.val(e.date.format("YYYY-MM-DD hh:mm:ssa"));
    })
})