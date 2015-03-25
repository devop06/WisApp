var app = angular.module("WisApp", []);

app.controller("MainController", function ($scope, $http) {
    $scope.Message = "Hello World";

    $http.get("/api/Home/Articles")
        .success(function (data) {
        $scope.Articles = data;
        });
        /*.error(function(Data));*/

});