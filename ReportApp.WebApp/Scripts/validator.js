function Validator() {
    var isValid = function (value, maxLength, acceptedTitleCharecters) {
        if (!value)
            return false;

        value = value.trim();
        if (value.length > maxLength)
            return false;

        for (var i = 0; i < value.length; i++) {
            if (value[i].search(acceptedTitleCharecters))
                return false;
        }

        return true;
    };

    return {
        isTitleValid: function (title, titleValidationMessage) {
            if (!isValid(title, 50, /[a-zA-Z0-9\-_ ]+/gi)) {
                titleValidationMessage.slideDown();
                return false;
            }

            titleValidationMessage.slideUp();
            return true;
        },
        isDescriptionValid: function (description, descriptionValidatioMessage) {
            if (!isValid(description, 400, /[a-zA-Z0-9\-_ ,.\!\?]/gi)) {
                descriptionValidatioMessage.slideDown();
                return false;
            }

            descriptionValidatioMessage.slideUp();
            return true;
        },
        isMoneySpentValid: function (moneySpent, moneySpentValidationMessage) {
            if (!moneySpent) {
                moneySpentValidationMessage.slideDown();
                return false;
            }

            var number = new Number(moneySpent);
            if (!isNaN(number)) {
                moneySpentValidationMessage.slideUp();
                return true;
            }

            moneySpentValidationMessage.slideDown();
            return false;
        }
    }
};