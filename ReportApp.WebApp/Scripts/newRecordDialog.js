function NewRecordDialog(dialogSelector, reportManager) {
    var $dialog = $(dialogSelector);
    var $title = $dialog.find("#title");
    var $moneySpent = $dialog.find("#money-spent");
    var $description = $dialog.find("#description");
    var $tags = $dialog.find("#tags");
    var $selectedDate = $dialog.find(".active a").data('date');

    var $titleValidationMessage = $dialog.find(".validation-tips #title-validation-message");
    var $descriptionValidationMessage = $dialog.find(".validation-tips #description-validation-message");
    var $moneySpentValidationMessage = $dialog.find(".validation-tips #money-spent-validation-message");

    var validator = new Validator();

    function cleanUpDialog() {
        $title.val("");
        $moneySpent.val("");
        $description.val("");
        $tags.val("");

        $titleValidationMessage.hide();
        $descriptionValidationMessage.hide();
        $moneySpentValidationMessage.hide();
    };

    $dialog.find('.btn-dismiss').on('click', function (e) {
        cleanUpDialog();
        $dialog.modal('hide');
    });

    $dialog.find('.btn-save').on('click', function (e) {

        var isModelValid = true;

        if (!validator.isTitleValid($title.val(), $titleValidationMessage))
            isModelValid = false;
        if (!validator.isDescriptionValid($description.val(), $descriptionValidationMessage))
            isModelValid = false;
        if (!validator.isMoneySpentValid($moneySpent.val(), $moneySpentValidationMessage))
            isModelValid = false;

        if (!isModelValid)
            return false;

        var title = $title.val().trim();
        var descrip = $description.val().trim();
        var moneySpent = new Number($moneySpent.val());

        // TODO: tags - must be array

        reportManager.appendRecord(title, moneySpent, descrip, $tags.val().split(','), $selectedDate);

        cleanUpDialog();

        $dialog.modal('hide');
    });
};