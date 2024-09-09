window.onload = () => {

    var queryString = window.location.search;

    var urlParams = new URLSearchParams(queryString);

    if (urlParams.has('taskId')) {
        console.log('Query parameter "param" exists');

        document.getElementById("chkIsDoneDiv").style.display = "flex";
        document.getElementById("btnDeleteTask").style.display = "block";

        var paramValue = urlParams.get('taskId');
        console.log('Value of taskId:', paramValue);
    } else {
        document.getElementById("chkIsDoneDiv").style.display = "none";
        document.getElementById("btnDeleteTask").style.display = "none";

        console.log('Query parameter "taskId" does not exist');
    }
}

function showModal() {
    var modalElement = document.getElementById('afterClickModal');
    var modal = new bootstrap.Modal(modalElement);
    modal.show();
}

function goToDefault() {
    var operationStatus = document.getElementById('hfOperationStatus').value;

    if (operationStatus === 'success') {
        // Redirect or perform success action
        window.location.href = '/Default.aspx'; // Example
    }
}

//Fields Validation