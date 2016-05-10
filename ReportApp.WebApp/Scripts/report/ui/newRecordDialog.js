var report = report || {};

report.ui = report.ui || {};

report.ui.NewRecordDialog = function(dialogSelector, calendar, tagsMultiselect, reportManager) {
    var validator = new report.utils.Validator();
    var $dialog = $(dialogSelector);

    var $title = $dialog.find("#title");
    var $moneySpent = $dialog.find("#money-spent");
    var $description = $dialog.find("#description");

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

        if (!validator.isTitleValid(title, $titleValidationMessage))
            isModelValid = false;
        if (!validator.isMoneySpentValid($moneySpent.val(), $moneySpentValidationMessage))
            isModelValid = false;
        if(!validator.isDescriptionValid(description, $descriptionValidationMessage))
            isModelValid = false;
        if(!validator.isTagsSelected(tagsMultiselect.hasSelected(), $tagsValidationMessage))
            isModelValid = false;

        if (!isModelValid)
            return false;

        var moneySpent = new Number($moneySpent.val());

        reportManager.appendRecord(title, moneySpent, description, tagsMultiselect.getSelected(), calendar.getSelectedDate());

        cleanUpDialog();
        $dialog.modal('hide');
    });
};