/*
 * @param {jQuery element for which the multiselect for} element
 * @param {text for the dropdown placeholder} placeholderText
 * @param {url for remote source of items} url
 * @param {used when returning selected items to convert them to the js object} elementToObjectConverter
 * @returns {multiselect instance} 
 */
var report = report || {};

report.ui = report.ui || {};

report.ui.Multiselect = function(element, placeholderText, url, elementToObjectConverter) {
    function _customResult(data) {
        if (data.loading) return data.text;

        return '<option value="' + data.id + '">' + data.text + '</option>';
    };

    element.select2({
        placeholder: placeholderText,
        minimumInputLength: 1,
        templateResult: _customResult,
        templateSelection: function (data) { return data.text; },
        escapeMarkup: function (markup) { return markup; },
        tags: true,
        multiple: true,
        ajax: {
            url: url,
            dataType: 'json',
            delay: 250,
            cache: false,
            data: function (e) { return { tagTerm: e.term }; },
            processResults: function (data) {
                var recordTags = [];
                for (var i = 0; i < data.length; i++) {
                    recordTags.push({
                        text: data[i].Name,
                        id: data[i].Id
                    });
                }

                return {
                    results: recordTags
                };
            }
        }
    });

    return {
        getSelected: function () {
            var selectionPlaceholder = element.data().select2.$selection;
            var selection = selectionPlaceholder.find('.select2-selection__rendered .select2-selection__choice');
            
            return elementToObjectConverter.convert(selection);
        },
        hasSelected: function () {
            return this.getSelected().length !== 0;
        },
        clearSelected: function () {
            // workaround on how to reset select2
            element.val("").trigger('change');
        }
    }
};