var wisControllers = angular.module('wisControllers', []);

wisControllers.controller('indexCtrl',
	function ($scope, $http) {


	    $http.get("/api/Home/Articles")
             .success(function (data) {
                 $scope.Message = "TRUE";
                 $scope.Articles = data;
             });
	});


wisControllers.controller('partagerCtrl', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {

    var id = $routeParams.id;
    var routeApi = "/api/Home/getArticle/" + id;

    $http.get(routeApi)
          .success(function (data) {
              $scope.article = data;

          });
	}]);

wisControllers.controller('articleCtrl', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {

    var id = $routeParams.id;
    var routeApi = "/api/Home/getArticle/" + id;
    
    $http.get(routeApi)
          .success(function (data) {
              $scope.article = data;
              
          });
	}]);

wisControllers.controller('categorieCtrl', ['$scope', '$http', function ($scope, $http) {
    $http.get('/api/Categorie/Categorie').success(function (data) {
        $scope.categories = data;
    });

    $http.get('/api/Categorie/OtherCategorie').success(function (data) {
        $scope.autres = data;
    });

    $scope.orderProp = 'Titre';

}]);


wisControllers.controller('mapCtrl', function ($scope, uiGmapGoogleMapApi, $http) {
    if (navigator.geolocation) {

        navigator.geolocation.getCurrentPosition(function (position) {

            $scope.map = { center: { latitude: position.coords.latitude, longitude: position.coords.longitude }, zoom: 18 };
            $scope.$apply();
        }, function () { });
    } else {
        $http.get("/api/Home/initMap")
        .success(function (data) {
            $scope.map = data;
            $scope.$apply();
        })
        .error(function (data) {

        });
    }
});

wisControllers.controller('connectionCtrl', function($scope, $http){
    $scope.checkUser = function () {
        console.log($scope.user);
        $http.post("/api/Connection/checkUser", $scope.user)
            .success(function (data) {
                if (data == true) {
                    alert('Authentification réussie');
                }
                else {
                    alert('Identifiants invalides');
                }
                
            })
            .error(function(){
                alert('Authentification impossible');
            });
    }
});