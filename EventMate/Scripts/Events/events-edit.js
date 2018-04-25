moment.locale("en-au");

// Encapsulate functions inside the "EventMate" namespace
var EventMate = window.EventMate || {};
//EventMate.Create = {};

$(document).on("ready", function () {
    EventMate.Controls.initDateTimePicker("dateandtime", {
        format: "DD/MM/YYYY hh:mm:ss a",
        sideBySide: true
    });

    // Copy value into Dummy field
    //$("#DescriptionDummy").val($("#description").val());

    EventMate.Controls.initQuill("DescriptionDummy", {
        theme: "snow"
    });
})