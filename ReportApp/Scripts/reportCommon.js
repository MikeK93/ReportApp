function reportCommon(initialDate) {

    this.setDate = function (date) {
        $("#cal").calendar({ 'date': initialDate });
    };

    this.setDate(initialDate);

    return this;
};