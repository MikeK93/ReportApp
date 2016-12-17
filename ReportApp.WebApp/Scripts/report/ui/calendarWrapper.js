var report = report || {};

report.ui = report.ui || {};

report.ui.CalendarWrapper = function(calendarPlaceholderSelector, initialDate, reportService) {
    var placeholder = $(calendarPlaceholderSelector);
    var calendar = placeholder.find('#cal').calendar({ 'date': new Date(initialDate) });
    var viewed = placeholder.find('.viewed');

    function upateTextByReportDate(reportDate) {
        viewed.find('span').text(reportDate.FullDate);
        viewed.find('span').data('date', reportDate.ShortDate);

        $(".record-for-date-message span").text(reportDate.FullDate);
    }

    function getRecords(element) {
        var date = $(element).data('date');
        reportService.updateReportForDate(date, upateTextByReportDate);
        calendar.updateCalendar(new Date(date));
    }

    placeholder.find('.today-date').on('click', function() { getRecords(this); });
    placeholder.on('click', '.calendar-day', function() { getRecords(this); });

    return {
        getSelectedDate: function() { return calendar.getSelected(); }
    }
};