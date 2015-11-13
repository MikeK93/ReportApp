function Report() {
    var reportSection = $("#report-section");
    var list = $("#records");
    var sum = $("#report-sum span").text();

    return {
        appendRecord: function (title, moneySpent, description, tags, selectedDate) {
            $.ajax({
                url: 'AppendRecord',
                data: { title: title, moneySpent: moneySpent, description: description, tags: tags, date: new Date(selectedDate) },
                datatype: "html",
                success: function (data) {
                    list.append(data);
                    reportSection.text(sum + moneySpent);
                },
                error: function (e) {
                    alert('Error when creating new record. ' + e);
                }
            });
        },
        updateReportForDate: function (date) {
            var d = new Date(date);
            $.ajax({
                url: "",
                data: { day: d.getDate(), month: d.getMonth() + 1, year: d.getFullYear() },
                success: function (responce) {
                    reportSection.html(responce);
                },
                error: function (error) {
                    console.log(error);
                }
            });
        }
    }
};