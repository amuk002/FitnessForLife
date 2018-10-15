var events = [];
$(".events").each(function () {
    var title = $(".title", this).text().trim();
    var start = $(".start", this).text().trim();
    var event = {
        "title": title,
        "start": start
    };
    events.push(event);
});

$(document).ready(function () {
    $("#calendar").fullCalendar({
        locale: 'au',
        events: events,
        eventColor: '#5eb69d',
        dayClick: function (date, allDay, jsEvent, view) {
            var d = new Date(date);
            var cuurentDate = new Date();
           
            if (d.getDate() >= cuurentDate.getDate()) {
                var m = moment(d).format("YYYY-MM-DD");
                m = encodeURIComponent(m);
                uri = "/Appointments/Create?date=" + m;
                $(location).attr('href', uri);
            }
            else {
                alert("Book appointments for future and not past.");
            }
        }
    });
});

