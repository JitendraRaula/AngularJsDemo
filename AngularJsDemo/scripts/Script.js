/// <reference path="angular.min.js" />

var myApp = angular.module("myModule", ["ngRoute"])
    .config(function ($routeProvider) {
        $routeProvider
            .when("/home",
            {
                templateUrl: "Templates/home.html",
                controller: "homeController"
            })
            .when("/courses",
            {
                templateUrl: "Templates/courses.html",
                controller: "coursesController"
            })
            .when("/students",
            {
                templateUrl: "Templates/students.html",
                controller: "studentsController"
            })
        //$locationProvider.html5Mode(true);
    })
    .controller("homeController",function($scope) {
        $scope.message = "Home Page";
    })
.controller("coursesController",function($scope) {
        $scope.courses = ["C#", "ASP.NET", "VB.NET", "SQL Server"];
})
.controller("studentsController",function($scope,$http) {
    $http.get("StudentService.asmx/GetAllStudents")
    .then(function(response) {
            $scope.students = response.data;
        });
    })

   