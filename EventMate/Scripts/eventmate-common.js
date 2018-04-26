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

// Adds an Image Preview to any file input controls
EventMate.Controls.addImagePreviewToFileInput = function (id) {
    if (!window.File || !window.FileReader) {
        console.log("EventMate.Controls.addImagePreviewToFileInput - File and FileReader API's are required")
    }

    var selector = "#" + id;
    var $fileInput = $(selector);
    var $imgPreview = $('<div class="" />');
    $fileInput.after($imgPreview);

    $fileInput.on("change", function (e) {
        $imgPreview.html(""); // clear
        if (e.target.files.length > 0) {

            // Create a FileReader to read the contents of the selected file to provide a Preview Image
            var fileReader = new FileReader();
            fileReader.addEventListener("load", function () {
                $imgPreview.append('<img src="' + fileReader.result + '" style="max-width: 100%;" />');
            });

            //var file = e.target.files[0];
            // .readAsDataUrl is asynchronous. 
            // On a successful read it will trigger the "load" event on the FileReader object
            // and FileReader.result will be populated with the read data
            fileReader.readAsDataURL(e.target.files[0]);

        }
    });
}