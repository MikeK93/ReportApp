calendarCommon = function (initialDate) {
    setDate = function (date) {
        $("#cal").first().empty();
        $("#cal").calendar({ 'date': new Date(date) });
    }

    setDate(initialDate);

    return {
        update: setDate
    }
};