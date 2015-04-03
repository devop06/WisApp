var wisControllers = angular.module('wisControllers', []);

wisControllers.controller('indexCtrl',
	function ($scope, $http) {


	    $http.get("/api/Home/Articles")
             .success(function (data) {
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

    $scope.categoriesSelectionnees = [];

    $scope.selectionnerCategorie = function (categorie) {
        //Recherche dans le tableau
        var exist = false;
        var id = 0;
        for (var i = 0; i < $scope.categoriesSelectionnees.length; i++) {
            if ($scope.categoriesSelectionnees[i] === categorie) {
                exist = true;
                id = i;
            }
        }

        if (exist === false) {
            //Si existe pas alors ...
            $scope.categoriesSelectionnees.push(categorie);
        } else {
            //...sinon enlever du tableau
            $scope.categoriesSelectionnees.splice(id,1);
        }
    };

    $scope.isSelectionnee = function (categorie) {
        return $scope.categoriesSelectionnees.indexOf(categorie) != -1;
    };
}]);


wisControllers.controller('mapCtrl', function ($scope, uiGmapGoogleMapApi, $http) {

    $http.get("/api/Home/Articles")
            .success(function (data) {
                $scope.Articles = data;
            });

    var routeApi2 = "/api/Home/getNombreArticle";

    $http.get(routeApi2)
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
                var titre;
                //changer les valeurs de latitude et longitude
                if ($scope.Articles[i].id == i+1) {
                    var latitude1 = $scope.Articles[i].Latitude;
                    var longitude = $scope.Articles[i].Longitude;
                    titre = $scope.Articles[i].Titre;
                }
                var ret = {
                    latitude: latitude1,
                    longitude: longitude,
                    title: titre
                };
                ret[idKey] = i;
                return ret;
            };

            $scope.Markers = [];
            // Get the bounds from the map once it's loaded
            $scope.$watch(function () {
                return $scope.map.bounds;
            }, function (nv, ov) {
                // Only need to regenerate once
                var markers = [];
                if (!ov.southwest && nv.southwest) {
                   
                    for (var i = 0; i < $scope.nombreMarker; i++) {
                        markers.push(createMarker(i, $scope.map.bounds))
                    }
                    $scope.Markers = markers;
                }
            }, true);
          
            $scope.$apply();
           
        }, function () { });

    }
});

// Service de Geolocalisation :
// retourne un objet Postion position
//      qui possede lui meme un objet coords
wisControllers.factory("GeolocationService", ['$q', '$window', '$rootScope', function ($q, $window, $rootScope) {
    return function () {
        var deferred = $q.defer();

        if (!$window.navigator) {
            $rootScope.$apply(function() {
                deferred.reject(new Error("Geolocation is not supported"));
            });
        } else {
            $window.navigator.geolocation.getCurrentPosition(function (position) {
                $rootScope.$apply(function() {
                    deferred.resolve(position);
                });
            }, function (error) {
                $rootScope.$apply(function() {
                    deferred.reject(error);
                });
            });
        }

        return deferred.promise;
    }
}]);

wisControllers.controller('creerCtrl', ['$scope', 'GeolocationService',
    function ($scope, geolocation) {

        $scope.article = {};

        $scope.titreArticle = "[Quel titre pour votre article ?]";
        $scope.contentArticle = "[Ici tapez le corps de votre article]";
        $scope.tagsArticle = "ex : Tag1,Tag2,Tag3";

        $scope.position = null;
        $scope.message = "Nous desirons connaitre votre position ...";

        geolocation().then(function (position) {
            $scope.latitudeArticle = position.coords.latitude;
            $scope.longitudeArticle = position.coords.longitude;
            $scope.message = "Position recuperer !";
        }, function (reason) {
            $scope.message = "Votre position ne peut être determinee."
        });

        $scope.submit = function () {

                // Article :
                /*  id => C#
                    date => C#
                    heure => C#
                    image => ...
                    auteur => 
                */
            var titre = $scope.titreArticle;
            var content = $scope.contentArticle;
            var description = content.substr(0,50) + " ...";
            var tags = $scope.tagsArticle;
            var source = "W.I.S";

            var latitude = $scope.latitudeArticle;
            var longitude = $scope.longitudeArticle;

                $scope.article = {
                    "titre": titre,
                    "content": content,
                    "description":description,
                    "tags": tags,
                    "source": source,
                    "latitude": latitude,
                    "longitude": longitude
                };
            }
         }
]);

wisControllers.controller('connectionCtrl', function ($scope, $http) {
    $scope.checkUser = function () {
        //console.log($scope.user);
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

wisControllers.controller('inscriptionCtrl', function ($scope, $http) {
    $scope.checkInscription = function () {
        console.log($scope.user);
        $http.post("/api/Inscription/checkInscription", $scope.user)
            .success(function (data) {
                alert(data);
            })
            .error(function () {
                alert('Inscription impossible pour le moment');
            });
    }
});
