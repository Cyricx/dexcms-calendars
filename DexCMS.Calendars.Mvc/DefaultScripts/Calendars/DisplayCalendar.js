$(document).ready(function () {
    var isLocal = '@isLocal';
    var currentTimezone = isLocal == 'True' ? 'local' : null;
    var date = new Date();
    var d = date.getDate();
    var m = date.getMonth();
    var y = date.getFullYear();

    var tooltip = $('<div/>').qtip({
        id: 'fullcalendar',
        prerender: true,
        content: {
            text: ' ',
            title: {
                button: true
            }
        },
        position: {
            my: 'bottom center',
            at: 'top center',
            target: 'mouse',
            viewport: $('#calendar'),
            adjust: {
                screen: true
            }
        },
        show: false,
        hide: false,
        style: { classes: 'calendar-details' }
    }).qtip('api');

    $('#calendar').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        timezone: currentTimezone,
        ignoreTimezone: false,
        displayEventEnd: true,
        eventLimit: true, 
        eventLimitText: 'events',
        events: {
            url: DEXCMS_GLOBALS.ROOT_PATH + '/Calendar/GetEvents',
            error: function () {
                $('#script-warning').show();
            },
            success: function (data) {
            }
        },
        loading: function (bool) {
            if (bool) {
                $('#loading').css('opacity', '1');
            } else {
                $('#loading').css('opacity', '0');
            }
        },
        eventRender: function (event, element) {
            element.addClass(event.status.toLowerCase().replace(' ', '-')).addClass(event.type.toLowerCase().replace(' ', '-'));
            if (event.end) {
                var startMoment = moment(event.start),
                    endMoment = moment(event.end);

                if (startMoment.format("M-D") != endMoment.format("M-D")) {
                    var newTime = startMoment.format("M/D h:mm") + startMoment.format("a").substring(0, 1)
                        + " - " +
                        endMoment.format("M/D h:mm") + endMoment.format("a").substring(0, 1);

                    element.find(".fc-time").text(newTime);
                }
            }//end event time fix

            //add location info
            var fcLocation = $('<span></span>').text(event.location).addClass('fc-location');
            element.find('.fc-content').append(fcLocation);
        },//end event render
        dayClick: function () { tooltip.hide() },
        eventResizeStart: function () { tooltip.hide() },
        eventDragStart: function () { tooltip.hide() },
        viewDisplay: function () { tooltip.hide() },
        eventClick: function (data, event, view) {
            var timeInfo = '';
            var startMoment = moment(data.start);
            if (data.end) {
                endMoment = moment(data.end);
                if (startMoment.format("M-D") != endMoment.format("M-D")) {
                    timeInfo = startMoment.format("M/D h:mm") + startMoment.format("a").substring(0, 1)
                        + " to " +
                        endMoment.format("M/D h:mm") + endMoment.format("a").substring(0, 1);
                } else {
                    timeInfo = startMoment.format("M/D h:mm") + startMoment.format("a").substring(0, 1)
                            + " to " +
                        endMoment.format("h:mm") + endMoment.format("a").substring(0, 1);
                }
            } else {
                timeInfo = startMoment.format("M/D h:mm") + startMoment.format("a").substring(0, 1);
            }
            var content =
                "<div>" +

                    "<h3>" + data.title + "</h3>" +
                    "<span class='" + data.type.toLowerCase().replace(' ', '-') + "'>" + data.type + "</span>" +
                    "<em>" + timeInfo + "</em>" +
                "</div>" +
                "<div>" +
                    "<strong>Location: </strong><span>" + data.location + "</span>" +
                "</div>";
            if (data.details) {
                content +=
               "<div>" +
                   "<strong>Details:</strong><p>" + data.details + "</p>" +
               "</div>"
            }
            tooltip.set({
                'position.target': this,
                'content.text': content
            }).reposition(event).show(event);
        }
    });//end full calendar
});
