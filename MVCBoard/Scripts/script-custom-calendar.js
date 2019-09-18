$(document).ready(function ()
{
    $('#calendar').fullCalendar({
        header:
        {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        titleFormat: {
            month: "YYYY년 MMMM",
            week: "MMM DD일",
            day: "MMM d일 dddd"
        },
        monthNames: ["1월", "2월", "3월", "4월", "5월", "6월", "7월", "8월", "9월", "10월", "11월", "12월"],
        monthNamesShort: ["1월", "2월", "3월", "4월", "5월", "6월", "7월", "8월", "9월", "10월", "11월", "12월"],
        dayNames: ["일요일", "월요일", "화요일", "수요일", "목요일", "금요일", "토요일"],
        dayNamesShort: ["일", "월", "화", "수", "목", "금", "토"],
        buttonText: {
            today: 'today',
            month: 'month',
            week: 'week',
            day: 'day',
            list: 'list'
        },
        eventLimit: true, // for all non-TimeGrid views
        views: {
            timeGrid: {
                eventLimit: 6 // adjust to 6 only for timeGridWeek/timeGridDay
            }
        },
      
        events: function (start, end, timezone, callback)
        {
            $.ajax({
                url: '/Home/GetCalendarData',
                type: "GET",
                dataType: "JSON",

                success: function (result)
                {
                    var events = [];

                    $.each(result, function (i, data)
                    {
                        events.push(
                       {
                           title: data.Title,
                           description: data.Desc,
                           start: moment(data.Start_Date).format('YYYY-MM-DD'),
                           end: moment(data.End_Date).format('YYYY-MM-DD'),
                           backgroundColor: "#9999FF",
                                borderColor: "#9999FF"
                       });
                    });

                    callback(events);
                }
            });
        },

        eventRender: function (event, element)
        {
            element.qtip(
            {
                content: event.description
            });
        },

        editable: false
    });
});