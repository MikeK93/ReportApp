var report = report || {};

report.ui = report.ui || {};

report.ui.CalendarCommon = function (initialDate, reportManager) {
    var cal = null;
    var todayDate = initialDate;

    var dateToTitle = function (dateFromDataAttribute) {
        var separated = dateFromDataAttribute.split('-');
        return separated[1] + '/' + separated[2] + '/' + separated[0];
    };

    var updateText = function (date) {
        $(".viewed span").text(date);
        $(".record-for-date-message span").text(date);
    };

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
            reportManager.updateReportForDate(date);
            cal.updateCal(new Date(date));
        }
    }

    $(".today span").click(function () {
        setDate(todayDate);
        
    });

    $(".date").on('click', function (e) {
        onSelectedDate(e);
    });

    setDate(todayDate);

    return {
        update: setDate,
        select: onSelectedDate,
        getSelectedDate: function() { return $("#cal").find(".active a").data('date'); }
    }
};