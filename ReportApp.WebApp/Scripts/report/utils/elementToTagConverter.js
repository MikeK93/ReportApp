var report = report || {};

report.utils = report.utils || {};

report.utils.ElementToTagConverter = function () {
    return {
        convert: function (selection) {
            var result = [];

            selection.each(function (index, value) {
                var item = $(value).data('data');
                var id = (item.id === item.text) ? 0 : item.id;
                result.push({
                    id: id,
                    name: item.text
                });
            });

            return result;
        }
    }
};