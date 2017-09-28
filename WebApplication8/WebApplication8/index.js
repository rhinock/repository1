var app = angular.module("simpleApp", []);

app.controller("simpleController", function ($scope) {
    $scope.collection = [
        { name: "Mark", age: 22, city: "New York" },
        { name: "James", age: 35, city: "Atlanta" },
        { name: "John", age: 48, city: "Miami" },
        { name: "Jessica", age: 28, city: "Boston" },
        { name: "Chris", age: 52, city: "Stamford" }
    ];

    $scope.addEntry = function () {
        $scope.collection.push($scope.newData);
        $scope.newData = '';
    };

    $scope.remove = function (item) {
        var index = $scope.collection.indexOf(item);
        $scope.collection.splice(index, 1);
    }
});