jQuery.noConflict();

var app = angular.module('myApp', []);
app.controller('userListController', function ($scope, $http) {
    $scope.openStudentGrades = function (id) {
        window.open("StudentPage.html?id=" + id, "_self");
    }

    $http.get('api/projectAPI/checkIfCurrIsSecretary').then(function (response) {
        if (response.data != null) {
            $scope.isSecretary = response.data;
        }
    })

    $http.get('api/projectAPI/getAllStudents').then(function (response) {
        if (response.data != null) {
            $scope.students = response.data;
        }
    })

    $scope.logout_click = function () {
        $http.get('api/projectAPI/logout').then(function (response) {
            if (response.data == true) {
                window.open("login.html", "_self");
            }
        })
    }

    $scope.back_click = function () {
        window.open("login.html", "_self");
    }
})
