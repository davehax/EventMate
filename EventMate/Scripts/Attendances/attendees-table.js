/*  Repeating Table to add Attendees to an event
 *   
 */

// AttendeeTable class
function AttendeeTable(selector, options) {
    // Allow any scope under to access the "this" object by using the self variable
    var self = this;

    // private variables
    var $this = $(selector);
    var initialising = false;
    var initialised = false;
    var initDefer = $.Deferred();

    // Default config - this can be overridden by passing in an object as the second argument to the constructor
    var config = {
        // Int: must be set
        eventId: -1,
        // Boolean: [true | false] - Makes the status dropdown readonly
        statusReadonly: false,
        // String: ["Invited" | "Going" | "Maybe" | "Can't Attend"]
        statusDefault: "Invited",
    };

    $.extend(config, options);
    var data = {};

    // private methods

    // public methods
    this.initialise = function () {
        if (!initialising && !initialised) {
            initialising = true;

            var getUsers = $.ajax("/api/UsersAPI/All", { headers: { "accept": "application/json" } });
            var getStatuses = $.ajax("/api/AttendancesStatusAPI/All", { headers: { "accept": "application/json" } });

            $.when.apply(this, [getUsers, getStatuses])
                .done(function (users, statuses) {

                    // Add data to a class-instance variable "data"
                    data.users = users[0];
                    data.statuses = statuses[0];

                    // Initialising flags
                    initialising = false;
                    initialised = true;

                    initDefer.resolve();
                })
                .fail(function (error) {
                    debugger;
                    //throw error;
                    initDefer.reject(error);
                });
        }

        return initDefer;
    }

    this.renderInvite = function () {
        if (!initialised) return;

        // Build a list of users that you can click on to invite
        var $list = $('<ul class="list-group" data-name="inviteList" />');
        for (var i = 0; i < data.users.length; i++) {
            var user = data.users[i];
            var $li = $('<li class="list-group-item" data-name="inviteRow" data-id="' + user.id + '" />');
            var $label = $('<label class="control-label"><input type="checkbox" data-id="' + user.id + '" /> ' + user.firstname + ' ' + user.lastname + '</label>');
            $li.append($label);
            $list.append($li);
        }

        var $lastRow = $('<li class="list-group-item" />');
        var $saveBtn = $('<a class="btn primary" href="#">Save</a>');
        $lastRow.append($saveBtn);
        $list.append($lastRow);

        $this.append($list);

        $saveBtn.on("click", function (e) {
            e.preventDefault && e.preventDefault();
            e.stopPropagation && e.stopPropagation();

            // Build data to post to endpoint
            var statusId = data.statuses.filter(function (s) {
                return s.status.toLowerCase() === config.statusDefault.toLowerCase()
            })[0].id;

            var postData = {
                eventId: config.eventId,
                userAttendanceProxies: []
            };

            $('[data-name="inviteList"] .list-group-item[data-name="inviteRow"]').each(function (idx) {
                var $this = $(this); // shadow $this
                var $cbox = $this.find('input[type="checkbox"]');
                if ($cbox.is(":checked")) {
                    postData.userAttendanceProxies.push({
                        userId: Number($this.attr("data-id")),
                        statusId: Number(statusId)
                    });
                }
            });

            var post = $.ajax({
                url: "/api/AttendancesAPI/AddOrEditMultiple",
                type: "POST",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: JSON.stringify(postData)
            });

            post.done(function (e) {
                window.location = "/Events/Details/" + config.eventId
            })

            post.fail(function (error) {
                debugger;
            })
        })
    }

    return self;
}