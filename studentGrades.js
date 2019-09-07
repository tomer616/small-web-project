jQuery.noConflict();

var app = angular.module('myApp', []);
app.controller('studentGrades', function ($scope, $http) {

    $scope.currentEdited = {};
    $scope.currentEditedData = {};

    $http.get('api/projectAPI/checkIfCurrIsSecretary').then(function (response) {
        if (response.data != null) {
            $scope.isSecretary = response.data;
        }
    })

    $scope.getQSParamValue = function (name) {
        var url = window.location.href;
        name = name.replace(/[\[\]]/g, "\\$&");
        var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
            results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, " "));
    }

    $scope.getAllStudentsGrades = function () {
        $http.get('api/projectAPI/getAllStudentGrades').then(function (response) {
            if (response.data != null) {
                $scope.studentsgrades = response.data;
            }
        })
    }

    var studentID = $scope.getQSParamValue('id');
    if (studentID != null)
    {
        var $ = jQuery.noConflict();
        var uri = 'api/projectAPI/getAllStudentGrades';
        $.ajax({
            url: uri,
            dataType: 'json',
            data: { studentID: studentID },
            async: false,
            success: function (data) {
                $scope.studentsgrades = data;
            }
        });
    }
    
    $scope.logout_click = function () {
        $http.get('api/projectAPI/logout').then(function (response) {
            if (response.data == true) {
                localStorage.removeItem("currUser");
                window.open("login.html", "_self");
            }
        })
    }

    //This function being called when user click "edit" for a specific student grade
    $scope.editStudent = function (sg) {
        $scope.currentEdited = sg;
        $scope.currentEditedStudentID = sg.studentID;
        $scope.currentEditedCourseCode = sg.CourseID;
        $scope.currentEditedCourseName = sg.CourseName;
        $scope.currentEditedExameGrade = sg.ExameGrade;
        $scope.currentEditedLabGrade = sg.LabGrade;
        $scope.currentEditedHomeWorkGrade = sg.HomeWorkGrade;
    };

    //This function being called when user clicks on save changes after editing an existing grade
    $scope.saveChanges = function () {
        var $ = jQuery.noConflict();
        var uri = 'api/projectAPI/UpdateStudentGrade';
        $.ajax({
            url: uri,
            dataType: 'json',
            data: { studentID: $scope.currentEditedStudentID, CourseID: $scope.currentEditedCourseCode, CourseName: $scope.currentEditedCourseName, ExameGrade: $scope.currentEditedExameGrade, LabGrade: $scope.currentEditedLabGrade, HomeWorkGrade: $scope.currentEditedHomeWorkGrade },
            async: false,
            success: function (data) {
                if (data == true || data == "true") {
                    alert("Update Succeeded");
                    window.open(window.location, "_self");
                }
                else {
                    alert("Failed to add new course grade. Please try again");
                }
            }
        });
    }

    //This function being called when user clicks on save in the new grade
    $scope.saveStudent = function () 
    {
        var $ = jQuery.noConflict();
        var uri = 'api/projectAPI/UpdateStudentGrade';
        $.ajax({
            url: uri,
            dataType: 'json',
            data: { studentID: $scope.newCourseGrade_studendID, CourseID: $scope.newCourseGrade_courseCode, CourseName: $scope.newCourseGrade_courseName, ExameGrade: $scope.newCourseGrade_exameGrade, LabGrade: $scope.newCourseGrade_labGrade, HomeWorkGrade: $scope.newCourseGrade_homeWorkGrade },
            async: false,
            success: function (data) {
                if (data == true || data == "true") {
                    alert("Update Succeeded");
                    window.open(window.location, "_self");
                }
                else {
                    alert("Failed to add new course grade. Please try again");
                }
            }
        });
    };

    $scope.back_click = function () {
        window.open("UserList.html", "_self");
    }
})
