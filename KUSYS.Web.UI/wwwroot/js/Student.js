$(document).ready(function () {
    uiEvents.load();
});

//Sayfa event'leri
var uiEvents = (function () {
    //Sayfa loading event'i
    var load = function () {
        loadGridData();
        getCourses();
        $('#btn-new-record').off('click').on('click', function () {
            getCourses();
        });

        $('#btn-create-student').off('click').on('click', function () {
            var param = JSON.stringify({ FirstName: $('#create-first-name').val(), LastName: $('#create-last-name').val(), CourseId: $('#dropdown-courses').val() });

            createRecord(param);
        });
    }

    return {
        load: load
    }
})();

var getCourses = function () {
    $.ajax({
        'url': 'Course/GetAll',
        'type': 'GET',
        'success': function (data) {
            if (data != null && data.isSuccessfull && data.result != null && data.result.length > 0) {
                var rows = '';
                for (var i = 0; i < data.result.length; i++) {
                    rows += '<option value="' + data.result[i].id + '">' + data.result[i].courseName + '</option>';
                }
                $('#dropdown-courses').empty();
                $('#dropdown-courses').append(rows);
            }
        },
        'error': function (request, error) {
            alert("Request: " + JSON.stringify(request));
        }
    });
}

//Grid'i register eder.
var loadGridData = function () {
    $.ajax({
        'url': 'Student/GetAll',
        'type': 'GET',
        'success': function (data) {
            if (data != null && data.isSuccessfull && data.result != null && data.result.length > 0) {
                var rows = '';
                for (var i = 0; i < data.result.length; i++) {
                    rows +=
                        '<tr>' +
                        '<td>' + data.result[i].firstName + '</td>' +
                        '<td>' + data.result[i].lastName + '</td>' +
                        '<td>' + data.result[i].birthDate + '</td>' +
                        '<td>' +
                        '<a style="cursor: pointer; margin-right: 5px;" title="Edit"><span class="glyphicon glyphicon-edit" data-toggle="modal" data-target="#editModal" aria-hidden="true"></span></a>' +
                        '<a style="cursor: pointer; margin-right: 5px;" title="Remove"><span class="glyphicon glyphicon-remove" data-toggle="modal" data-target="#removeWarning" id=' + data.result[i].id + ' aria-hidden="true"></span></a>' +
                        '</td>' +
                        '</tr>';
                }
                $('#tbl_students > tbody').empty();
                $('#tbl_students > tbody').append(rows);

                $('.glyphicon-remove').off('click').on('click', function () {
                    var id = $(this).attr('id');
                    deleteRecord(id);
                });
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
    var rows = '<tr><td colspan="4" style="text-align: center;">No data</td></tr>';
    $('#tbl_students > tbody').empty();
    $('#tbl_students > tbody').append(rows);
}

var deleteRecord = function (id) {
    $('#btn-remove-student').off('click').on('click', function () {
        $.ajax({
            'url': 'Student/Delete',
            'type': 'POST',
            'data': { 'id': parseInt(id) },
            'success': function (data) {
                if (data == null) {
                    alert('There was an error!');
                    return;
                }
                if (data.isSuccessfull) {
                    loadGridData();
                    $('#btn-close-remove-popup').trigger('click');
                    alert('Record deleted successfully.');
                    return;
                }
                else if (data.errors != null && data.errors.length > 0) {
                    alert(data.errors[0]);
                }
                else if (data.errors == null) {
                    alert('There was an error!');
                    return;
                }
            },
            'error': function (request, error) {
                alert("Request: " + JSON.stringify(request));
            }
        });
    });
}

var createRecord = function (param) {

    $.ajax({
        url: 'Student/Create',
        type: 'POST',
        contentType: "application/json;",
        data: param,
        dataType: "json",
        success: function (data) {
            if (data == null) {
                alert('There was an error!');
                return;
            }
            if (data.isSuccessfull) {
                loadGridData();
                $('#btn-close-create-popup').trigger('click');
                alert('Record saved successfully.');
                return;
            }
            else if (data.errors != null && data.errors.length > 0) {
                alert(data.errors[0]);
            }
            else if (data.errors == null) {
                alert('There was an error!');
                return;
            }
        },
        'error': function (request, error) {
            alert("Request: " + JSON.stringify(request));
        }
    });
}