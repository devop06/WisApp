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
        $scope.orderProp = categories.Name;
    });

    $http.get('/api/Categorie/OtherCategorie').success(function (data) {
        $scope.autres = data;
    });

    $scope.class = "grey";

    $scope.changeClass = function () {
        if ($scope.class === "grey")
            $scope.class = "green";
        else
            $scope.class = "grey";
    };
}]);


wisControllers.controller('mapCtrl', function ($scope, uiGmapGoogleMapApi, $http) {

    var routeApi = "/api/Home/getNombreArticle";

    $http.get(routeApi)
          .success(function (data) {
              $scope.nombreMarker = data;

          });


    if (navigator.geolocation) {

        navigator.geolocation.getCurrentPosition(function (position) {

            $scope.map = { center: { latitude: position.coords.latitude, longitude: position.coords.longitude }, zoom: 4, bounds: {} };
            $scope.options = {
                scrollwheel: true
            };


            // création des markers
            var createMarker = function (i, bounds, idKey) {
                var lat_min = bounds.southwest.latitude,
                  lat_range = bounds.northeast.latitude - lat_min,
                  lng_min = bounds.southwest.longitude,
                  lng_range = bounds.northeast.longitude - lng_min;

                if (idKey == null) {
                    idKey = "id";
                }
                //changer les valeurs de latitude et longitude
                var latitude = lat_min + (Math.random() * lat_range);
                var longitude = lng_min + (Math.random() * lng_range);
                var ret = {
                    latitude: latitude,
                    longitude: longitude,
                    title: 'm' + i
                };
                ret[idKey] = i;
                return ret;
            };

            $scope.randomMarkers = [];
            // Get the bounds from the map once it's loaded
            $scope.$watch(function () {
                return $scope.map.bounds;
            }, function (nv, ov) {
                // Only need to regenerate once
                if (!ov.southwest && nv.southwest) {
                    var markers = [];
                    for (var i = 0; i < $scope.nombreMarker; i++) {
                        markers.push(createMarker(i, $scope.map.bounds))
                    }
                    $scope.randomMarkers = markers;
                }
            }, true);
          
            $scope.$apply();
           
        }, function () { });

    }
});

wisControllers.controller('creerCtrl', ['$scope',
    function($scope) {
        $scope.titreArticle = "Quel titre pour votre article ?";
        $scope.contentArticle = "Ici tapez votre article";
        $scope.tagsArticle = "Ex : Tag1, Tag2, Tag3";

        $scope.submit = function () {
        if ($scope.titreArticle) {
         
         $scope.titreArticle = "";
         $scope.contentArticle = "";
         $scope.tagsArticle = "";
         
          }
        
         }
     }
]);

wisControllers.controller('connectionCtrl', function ($scope, $http) {
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
            .error(function () {
                alert('Authentification impossible');
            });
    }
});