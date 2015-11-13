function CalendarCommon(initialDate, reportManager) {
    var cal = null;
    var todayDate = initialDate;

    dateToTitle = function (dateFromDataAttribute) {
        var separated = dateFromDataAttribute.split('-');
        return separated[1] + '/' + separated[2] + '/' + separated[0];
    };

    updateText = function (date) {
        $(".viewed span").text(date);
        $(".record-for-date-message span").text(date);
        reportManager.updateReportForDate(date);
    };

    $(".today span").click(function () { setDate(todayDate); });

    var onSelectedDate = function (sender) {
        var selected = dateToTitle($(sender).data('date'));

        if ($(cal).data('selected-date') != selected) {
            $(cal).data('selected-date', selected);
            updateText(selected);
            reportManager.updateReportForDate(selected);
        }
    };

    var setDate = function (date) {
        if (!cal) {
            cal = $("#cal").calendar({ 'date': new Date(date) });
            updateText(date);
            $(cal).data('selected-date', date);
        }
        else {
            updateText(date);
            cal.updateCal(new Date(date));
        }
    }

    setDate(todayDate);

    return {
        update: setDate,
        selection: onSelectedDate
    }
};