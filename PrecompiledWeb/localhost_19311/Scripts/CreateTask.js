window.onload = () => {
    var queryString = window.location.search;
    var urlParams = new URLSearchParams(queryString);

    if (urlParams.has('taskId')) {
        $('#chkIsDoneDiv').css('display', 'flex');
        $('#btnDeleteTask').css('display', 'block');
    }
}

function showModal() {
    var modalElement = $('#afterClickModal');
    var modal = new bootstrap.Modal(modalElement);
    modal.show();
}

function goToDefault() {
    var operationStatus = $('#hfOperationStatus').val();

    if (operationStatus === 'success') {
        window.location.href = '/Default.aspx';
    }
}

//Fields Validation
$(document).ready(function () {
    var btnCreateTask = $("#" + btnCreateTaskClientID);

    function validateFields() {
        var taskTitle = $("#" + txtTaskTitleClientID).val();
        var taskDescription = $("#" + txtTaskDescriptionClientID).val();
        var selectPriority = $("#" + selectTaskPriorityClientID).val();
        var isValid = true;

        if (taskTitle.trim() === "") {
            $('#validateTitle').show();
            isValid = false;
        } else {
            $('#validateTitle').hide();
        }

        if (taskDescription.trim() === "") {
            $('#validateDescription').show();
            isValid = false;
        } else {
            $('#validateDescription').hide();
        }

        console.log("selectPriority " + selectPriority);
        if (selectPriority === null) {
            $('#validateSelect').show();
            isValid = false;
        } else {
            $('#validateSelect').hide();
        }

        return isValid;
    }

    btnCreateTask.click(function (e) {
        if (validateFields()) {
            $("#" + hfValidationPassedClientID).val("true");
            __doPostBack(btnCreateTaskClientID, ''); 
        } else {
            e.preventDefault();
        }
    });

    $("#" + txtTaskTitleClientID).on('input', function () {
        if ($(this).val().trim() !== "") {
            $('#validateTitle').hide();
        }
    });

    $("#" + txtTaskDescriptionClientID).on('input', function () {
        if ($(this).val().trim() !== "") {
            $('#validateDescription').hide();
        }
    });

    $("#" + selectTaskPriorityClientID).on('change', function () {
        if ($(this).val() !== "null") {
            $('#validateSelect').hide();
        }
    });
});