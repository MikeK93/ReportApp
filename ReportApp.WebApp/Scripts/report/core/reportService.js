var report = report || {};

report.core = report.core || {};

report.core.ReportService = function (isListEmpty) {
    var reportSection = $("#report-section");
    var emptyListMessage = $("#empty-report");
    var list = $("#records");
    var sum = $("#report-sum span");

    var showHideList = function (isEmpty) {
        if (isEmpty) {
            emptyListMessage.show();
            reportSection.hide();
        } else {
            reportSection.show();
            emptyListMessage.hide();
        }
    };

    var renderRecord = function (data) {
        var newRecord = $("#record-template").children().first().clone(false);

        newRecord.find(".record-title span").text(data['Title']);
        newRecord.find(".money-spent span").text(data['MoneySpent']);
        newRecord.find(".description span").text(data['Description']);

        data["Tags"].forEach(function (t) {
            // TODO: add id to the tag element
            var tag = $("<a class='tag' onclick='javascript: void (0);'></a>");
            tag.text('#' + t.Name);
            newRecord.find(".tags").append(tag);
        });
        newRecord.hide();
        list.append(newRecord);
        newRecord.slideDown();
    };

    showHideList(isListEmpty);

    return {
        appendRecord: function (title, moneySpent, description, tags, selectedDate) {
            $.ajax({
                url: "report/api/append-record",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({
                    title: title,
                    moneySpent: moneySpent,
                    description: description,
                    tags: tags,
                    date: new Date(selectedDate)
                }),

                success: function (data) {
                    var isFirstItemAdded = $('#empty-report:visible').length;
                    if (isFirstItemAdded) {
                        list.empty();
                        renderRecord(data);
                        sum.text(data['MoneySpent']);

                        reportSection.show();
                        emptyListMessage.hide();
                    } else {
                        renderRecord(data);
                        sum.text(+moneySpent + +sum.text());
                    }
                },
                error: function (e) {
                    alert('Error when creating new record: ' + e.responseText);
                }
            });
        },
        updateReportForDate: function (date) {
            var d = new Date(date);
            $.ajax({
                url: "",
                data: { day: d.getDate(), month: d.getMonth() + 1, year: d.getFullYear() },
                success: function (data) {
                    var isEmpty = data.Records.length === 0;
                    showHideList(isEmpty);
                    if (!isEmpty) {
                        list.empty();

                        data.Records.forEach(function (record) { renderRecord(record); });
                        sum.text(data.Sum);
                    }
                    else {
                        emptyListMessage.find(".date-selected").text(date);
                    }
                },
                error: function (error) { console.log(error); }
            });
        }
    }
};