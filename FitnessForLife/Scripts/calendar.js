var appointments = [];
$(".appointments").each(function () {
    var username = $(".username", this).text().trim();
    var datetime = $(".datetime", this).text().trim();
    var branch = $(".branch", this).text().trim();
    var consultant = $(".consultant", this).text().trim();
    var appointment = {
        "title": username,
        "start": datetime
    };
    appointments.push(appointment);
});

$(document).ready(function () {
    $("#calendar").fullCalendar({
        locale: 'au',
        events: appointments,
        eventColor: '#5eb69d',
        dayClick: function (date, allDay, jsEvent, view) {
            var d = new Date(date);
            var m = moment(d).format("YYYY-MM-DD");
            m = encodeURIComponent(m);
            var uri = "/Appointments/Create?date=" + m;
            $(location).attr('href', uri);
        }
    });
});

