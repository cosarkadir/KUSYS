$(document).ready(function () {
    uiEvents.load();
});

//Sayfa event'leri
var uiEvents = (function () {
    //Sayfa loading event'i
    var load = function () {
        loadGridData();
    }

    return {
        load: load
    }
})();

//Grid'i register eder.
var loadGridData = function () {
    $.ajax({
        'url': 'Course/GetAll',
        'type': 'GET',
        'success': function (data) {
            if (data != null && data.isSuccessfull && data.result != null && data.result.length > 0) {
                var rows = '';
                for (var i = 0; i < data.result.length; i++) {
                    rows +=
                    '<tr>' +
                        '<td>' + data.result[i].id + '</td>' +
                        '<td>' + data.result[i].courseName + '</td>' +
                    '</tr>';
                }
                $('#tbl_courses > tbody').empty();
                $('#tbl_courses > tbody').append(rows);
            }
            else {
                noDataRow();
            }
        },
        'error': function (request, error) {
            alert("Request: " + JSON.stringify(request));
        }
    });
}

var noDataRow = function () {
    var rows = '<tr><td colspan="3" style="text-align: center;">No data</td></tr>';
    $('#tbl_courses > tbody').empty();
    $('#tbl_courses > tbody').append(rows);
}