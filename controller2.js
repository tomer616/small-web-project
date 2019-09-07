jQuery.noConflict();

var app = angular.module('myApp', []);
app.controller('controller1', function ($scope, $http) {

    $scope.currentEdited = {};
    $scope.currentEditedData = {};

    //$http.get('MOCK_DATA2.json').then(function (data) {
    //    $scope.StudentGrades = data.data;
    //});
    $http.get('api/projectAPI/getAllStudentsGrades').then(function (response) {
        if (response.data != null) {
            $scope.workspace = response.data;
        }
        else
            alert("עליך להתחבר למערכת")
    })


    $scope.editStudent = function (student) {
        $scope.currentEdited = student;
        $scope.currentEditedCourseCode = "";
        $scope.currentEditedCourseName = "";
        $scope.currentEditedExameGrade = "";
        $scope.currentEditedLabGrade = "";
        $scope.currentEditedHomeWorkGrade = "";
    };

    $scope.saveStudent = function () //////edit infometion
    {
        $scope.currentEdited.CourseCode = $scope.currentEditedCourseCode;
        $scope.currentEdited.CourseName = $scope.currentEditedCourseName;
        $scope.currentEdited.ExameGrade = $scope.currentEditedExameGrade;
        $scope.currentEdited.LabGrade = $scope.currentEditedLabGrade;
        $scope.currentEdited.HomeWorkGrade = $scope.currentEditedHomeWorkGrade;
    };

})
