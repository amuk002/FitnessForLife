var appointments = [];
$(".appointments").each(function () {
    var title = $(".title", this).text().trim();
    var start = $(".start", this).text().trim();
    var appointment = {
        "title": title,
        "start": start
    };
    appointments.push(appointment);
});

$("#calendar").fullCalendar({
    locale: 'au',
    events: appointments,

    dayClick: function (date, allDay, jsEvent, view) {
        var d = new Date(date);
        var m = moment(d).format("YYYY-MM-DD");
        m = encodeURIComponent(m);
        var uri = "/Events/Create?date=" + m;
        $(location).attr('href', uri);
    }
});