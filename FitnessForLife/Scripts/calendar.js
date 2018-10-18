var appointments = [];
$(".appointments").each(function () {
    var title = $(".title", this).text().trim();
    var start = $(".start", this).text().trim();
    var time = $(".time", this).text().trim();
    var appointment = {
        "title": title,
        "start": start
    };
    appointments.push(appointment);
});

$(document).ready(function () {
    $("#calendar").fullCalendar({
        locale: 'au',
        events: appointments,
        eventColor: '#78C2AD',
        eventTextColor: '#fff',
        eventLimit: true,
        dayClick: function (date, allDay, jsEvent, view) {
            var d = new Date(date);
            var m = moment(d).format("YYYY-MM-DD");
            m = encodeURIComponent(m);
            var uri = "/Appointments/Create?date=" + m;
            $(location).attr('href', uri);
        }
    })
});