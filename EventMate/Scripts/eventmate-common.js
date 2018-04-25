window.EventMate = {};

// Define common namespaces
EventMate.Controls = {};

// Turns a plain input into a DateTime picker
// EventMate.Controls.initDateTimePicker(id: string, options: object)
EventMate.Controls.initDateTimePicker = function (id, options) {
    if (!window.jQuery || !jQuery.fn.datetimepicker) {
        throw "jQuery and jQuery DateTimePicker are required";
    }

    var selector = "#" + id;
    var selector_dtp = "#" + id + "_dtp";
    var $dateAndTime = $(selector);
    $dateAndTime.hide();
    $dateAndTime.before($('<input class="form-control text-box single-line" id="' + id + '_dtp" name="' + id + '_dtp" type="text">'));

    var $dateAndTimeDTP = $(selector_dtp);
    var dtp = $dateAndTimeDTP.datetimepicker()
    dtp.on("dp.change", function (e) {
        $dateAndTime.val(e.date.format("YYYY-MM-DD hh:mm:ssa"));
    })
}

// Turns a plain control into a Rich Text Editor
// EventMate.Controls.initQuill(id: string, options: object)
EventMate.Controls.initQuill = function (id, options) {
    var selector = "#" + id;
    var $quillSource = $(selector);
    var quillEditorId = id + "_quill";
    var quillEditorSelector = "#" + quillEditorId;

    // Build the Quill editor target
    var $quillEditor = $('<div id="' + quillEditorId + '" />');
    $quillEditor.html($quillSource.val());

    // Hide original control
    $quillSource.hide();

    // Insert Quill editor
    $quillSource.after($quillEditor);

    // Init quill object
    var quill = new Quill(quillEditorSelector, options);

    // bind event to set the value for the source element
    quill.on("text-change", function (delta, oldDelta, source) {
        $quillSource.val(quill.root.innerHTML);
    });
}