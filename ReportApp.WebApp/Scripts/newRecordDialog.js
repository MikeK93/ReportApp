function NewRecordDialog(dialogSelector, tagsMultiselect, reportManager) {
    var validator = new Validator();
    var $dialog = $(dialogSelector);

    var $title = $dialog.find("#title");
    var $moneySpent = $dialog.find("#money-spent");
    var $description = $dialog.find("#description");
    var $selectedDate = $dialog.find(".active a").data('date');

    var $titleValidationMessage = $dialog.find(".validation-tips #title-validation-message");
    var $descriptionValidationMessage = $dialog.find(".validation-tips #description-validation-message");
    var $moneySpentValidationMessage = $dialog.find(".validation-tips #money-spent-validation-message");
    var $tagsValidationMessage = $dialog.find(".validation-tips #tags-validation-message");

    function cleanUpDialog() {
        $title.val("");
        $moneySpent.val("");
        $description.val("");
        tagsMultiselect.clearSelected();

        $titleValidationMessage.hide();
        $descriptionValidationMessage.hide();
        $moneySpentValidationMessage.hide();
        $tagsValidationMessage.hide();
    };

    $dialog.find('.btn-dismiss').on('click', function (e) {
        cleanUpDialog();
        $dialog.modal('hide');
    });

    $dialog.find('.btn-save').on('click', function (e) {

        var isModelValid = true;

        var title = $title.val().trim();
        
        var description = $description.val().trim();

        if (!validator.isTitleValid(title, $titleValidationMessage) ||
            !validator.isMoneySpentValid($moneySpent.val(), $moneySpentValidationMessage) ||
            !validator.isDescriptionValid(description, $descriptionValidationMessage) ||
            !validator.isTagsSelected(tagsMultiselect.hasSelected(), $tagsValidationMessage))
            isModelValid = false;

        if (!isModelValid)
            return false;

        var moneySpent = new Number($moneySpent.val());

        reportManager.appendRecord(title, moneySpent, description, tagsMultiselect.getSelected(), $selectedDate);

        cleanUpDialog();
        $dialog.modal('hide');
    });
};