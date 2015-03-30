var wisControllers = angular.module('wisControllers', []);



wisControllers.controller('indexCtrl',
	function ($scope, $http) {


	    $http.get("/api/Home/Articles")
             .success(function (data) {
                 $scope.Message = "TRUE";
                 $scope.Articles = data;
             });
	});


wisControllers.controller('partagerCtrl', ['$scope',
	function ($scope, $http) {


	    $http.get("/api/Home/getArticle/id")
          .success(function (data) {
              $scope.article = data;
          });

	    /** var articlePartager = {
			titre : $scope,
			corps : data.corps,'Drones miniatures, drones pour simuler des combats aériens, pour suivre les sportifs ou spécialisés dans les autoportraits… Lédition 2015 du Consumer Electronics Show a illustré la montée en puissance de ce marché pour le grand public.',
			auteur : 'Relaxnews',
			tags : 'drones, CES2015, smartphone',
			date : '12/01/2015',
			source : 'http://www.futura-sciences.com/magazines/high-tech/infos/actu'

		}; */
	    // $scope.article = articlePartager;
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

/*
wisControllers.controller('mapCtrl', ['$scope',
    function ($scope, uiGmapGoogleMapApi){
        if(navigator.geolocation){

            navigator.geolocation.getCurrentPosition(function (position) {

                $scope.map = { center: { latitude: position.coords.latitude, longitude: position.coords.longitude }, zoom: 18 };
                $scope.$apply();
            }, function () {});
        }else{
            $scope.map = { center: {latitude: 46.6698231, longitude: 2.9012201}, zoom: 6};
            $scope.$apply();
        }
    }]);
    */

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