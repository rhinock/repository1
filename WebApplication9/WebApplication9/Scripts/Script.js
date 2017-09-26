var app = angular.module("myModule", []).controller("myController", function ($scope, $http) {
    $http.get("EmployeeService.asmx/GetAllEmployees").then(function (response) {
        $scope.employees = response.data;
    });
});