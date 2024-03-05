$(document).ready(function () {
    $('#PatientsId').change(function () {
        $('#patientHolder').empty();
        $.ajax({
            url: '/Patients/GetPatientPartial?id=' + $('#PatientsId').val(),         
            method: 'get',            
            dataType: 'html',          
            success: function (data) {   
                $('#patientHolder').append(data); 
            }
        });
    });
});