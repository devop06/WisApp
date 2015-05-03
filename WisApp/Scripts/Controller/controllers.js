var wisControllers = angular.module('wisControllers',[]);
var hubs;

wisControllers.factory('HubService', [function () {
    if (hubs != null)
        return hubs;

    //#region ArticleHub
    var proxyArticleHub = {
        client: {
            onArticleChanged: {}
        },
        server: {
            notifyArticle: function (article) {
                $.connection.articleHub.server.notifyArticle(article);
            }
        }
    };
    $.connection.articleHub.client.onArticleChanged = function (article) {
        for (var key in proxyArticleHub.client.onArticleChanged) {
            var func = proxyArticleHub.client.onArticleChanged[key];
            func(article);
        }
    };


    //Génération de nos proxys en automatique. A finir un jour
    //var proxyList = {};

    //for (var h in $.connection)
    //{
    //    if (h.indexOf("Hub") != -1)
    //    {
    //        var proxy = {
    //            client: {},
    //            server:{}
    //        };

    //        for(var m in h.client)
    //        {
    //            proxy.client[m] = m;
    //        }
    //    }
    //}
    //#endregion

    //#region MapHub
    var proxyMapHub = {
        client: {
        },
        server: {

        }
    }
    //$.connection.mapHub.client.XXX = function () { };
    //#endregion

    $.connection.hub.start();

    return {
        article: proxyArticleHub,
        map: proxyMapHub
    };
}]);

wisControllers.controller('indexCtrl', ['$scope', '$http', '$log', 'HubService', '$route', function ($scope, $http, $log, HubService, $route) {


	    $http.get("/api/Articles/GetArticle/")
             .success(function (data) {
                 $scope.Articles = data;
                
             });

    // Reference the proxy for the hub.  
	    HubService.article.client.onArticleChanged["IndexCtrl"] = function (article) {
	        //alert(article.Titre);
	        //if (document.location.href == "http://localhost:52454/Content/index.html#/" || document.location.href == "http://localhost:52454/content/#/") {
	        //window.location.reload();
	        //}
	        $scope.Articles.push(article);
	        $route.reload();
	    };

}]);

wisControllers.controller('creerCtrl', ['$scope', '$http', 'GeolocationService', '$location', 'HubService',
    function ($scope, $http, geolocation, $location, HubService) {

        $http.get('/api/Categorie/Categorie').success(function (data) {
            $scope.categories = data;
        });

        $scope.article = {};
        $scope.placeholder = {};
        $scope.tabTags = [];

        $scope.article.Tags = "";

        $scope.placeholder.Titre = "[Quel titre pour votre article ?]";
        $scope.placeholder.Content = "[Ici tapez le corps de votre article]";
        $scope.placeholder.Tags = "ex : Tag1,Tag2,Tag3";

        $scope.position = null;
        $scope.message = "Nous desirons connaitre votre position ...";

        geolocation().then(function (position) {
            $scope.article.Latitude = position.coords.latitude;
            $scope.article.Longitude = position.coords.longitude;
            $scope.message = "Position recuperer !";
        }, function (reason) {
            $scope.message = "Votre position ne peut être determin\u00E9e."
        });



        $scope.submit = function () {

            //HubService.invoke('refresh_server');
            // Article :
            /*  id => C#
                date => C#
                heure => C#
                image => ...
                auteur => 
            */
            var titre = $scope.article.Titre;
            var content = $scope.article.Content;
            var description = content.substr(0, 50) + " ...";
            var tags = $scope.article.Tags;
            var auteur = "W.I.S";
            var image = "W.I.S";
            var visibilite = $scope.article.Visibilite;

            var latitude = $scope.article.Latitude;
            var longitude = $scope.article.Longitude;

            $scope.article = {
                "Titre": titre,
                "Content": content,
                "Description": description,
                "Tags": tags,
                "Auteur": auteur,
                "Image": image,
                "Latitude": latitude,
                "Longitude": longitude,
                "Visibilite": visibilite
            };

            $http.post("/api/Articles/PostArticle",
                JSON.stringify($scope.article),
                {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                })
          .success(function (data) {
              $scope.article = data;
              //alert('Refresh');
              HubService.article.server.notifyArticle(data);
              alert("Votre article \u00E0 bien \u00E9t\u00E9 ajout\u00E9");
              $location.path('/article/' + $scope.article.id);
          })
          .error(function () {
              alert('Impossible de publier sans se connecter !');
              $location.path('/connection');
          });
        }

        $scope.addTag = function (tag) {
            $scope.tabTags = $scope.article.Tags.length > 0 ? $scope.article.Tags.split(',') : [];

            //Recherche dans le tableau
            var exist = false;
            var id = 0;
            for (var i = 0; i < $scope.tabTags.length; i++) {
                if ($scope.tabTags[i] == tag.Name) {
                    exist = true;
                    id = i;
                }
            }

            if (exist === false) {
                //Si existe pas alors ...
                // $scope.article.tabTags 
                $scope.tabTags.push(tag.Name);
            } else {
                //...sinon enlever du tableau
                $scope.tabTags.splice(id, 1);
            }

            $scope.article.Tags = $scope.tabTags.join(",");
        }
    }
]);
    

wisControllers.controller('partagerCtrl', ['$scope', '$location', '$http', '$routeParams', 'HubService', function ($scope, $location, $http, $routeParams, HubService) {

    var id = $routeParams.id;
    var routeApi = "/api/Articles/GetArticle/" + id;

    $http.get(routeApi)
          .success(function (data) {
              $scope.article = data;

          });
    $scope.toto = function () {
        $http.post("/api/Articles/PostArticle",
                JSON.stringify($scope.article),
                {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                })
          .success(function (data) {
              $scope.article = data;
              HubService.article.server.notifyArticle(data);
          })
          .error(function () {
              alert('Impossible de publier sans se connecter !');
              $location.path('/connection');
          });
    }
    
}]);

   
wisControllers.controller('articleCtrl', ['$scope', '$location', '$http', '$routeParams', '$route', function ($scope, $location, $http, $routeParams, $route) {

    var id = $routeParams.id;
    var routeApi = "/api/Articles/GetArticle/" + id;
    var routeApi2 = "/api/Favoris/estFavoris/" + id;
    var routeApi3 = "/api/Favoris/ajouterArticleFavo/" + id;
    var routeApi4 = "/api/Favoris/enleverArticleFavo/" + id;

    $http.get(routeApi)
          .success(function (data) {
              $scope.article = data;
              // retourne bool en fonction de si l'image est spécifiée ou non
              $scope.isNotNull = function () {
                  if ($scope.article.Image === "")
                      return false;
                  else
                      return true;
              };
          });

    $http.get(routeApi2)
         .success(function (data) {
             if (data == true)
                 $scope.estFavoris = true;
             else
                 $scope.estFavoris = false;
         });

    $scope.ajoutfavo = function () {
        $http.post(routeApi3, id)
             .success(function (data, status, headers, config) {
                 $route.reload();
             })
        .error(function () {
            alert("Impossible vous n'\u00EAtes pas connect\u00E9 !")
            $location.path('/connection');

        });
        
    }

    $scope.retirerfavo = function () {
        $http.post(routeApi4, id)
             .success(function (data, status, headers, config) {
                 $route.reload();
             })
        .error(function () {
            alert("Impossible vous n'\u00EAtes pas connect\u00E9 !")
            $location.path('/connection');

        });
    }

   
}] 
);


wisControllers.controller('compteCtrl', ['$scope', '$location', '$http', function ($scope, $location, $http) {
    $scope.disconnect = function () {
        $http.get("/api/Users/DisconnectUser")
            .success(function () {
                alert("vous \u00EAtes bien d\u00E9connect\u00E9 !")
                $location.path('/connection');
            })
        .error(function () {
            alert("bug...");
        });
    }
    $http.get("/api/Users/GetUser")
            .success(function (data) {
                $scope.compte = data;
               
            })
            .error(function () {
                alert('Vous devez etre connect\u00E9...');
                $location.path('/connection');
            });
    $scope.myVar = false;
    $scope.toggle = function () {
        $scope.myVar = !$scope.myVar;
    };
    $scope.checkModifCompte = function () {    
       alert('modification');
           
    };
    

}]);


wisControllers.controller('categorieCtrl', ['$scope', '$http', function ($scope, $http) {
    
    $http.get('/api/Categorie/Categorie').success(function (data) {
        $scope.categories = data;
    });

    $http.get('/api/Users/getCategorieUser/7').success(function (data) {
        console.log($scope.categoriesSelectionnees);
        var select = data;
        console.log(select);
        if (select != null) {
            $scope.categoriesSelectionnees = select;
        }
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

    // Ajouter les catégories séléctionnées à l'utilisateur
    $scope.validerCategorie = function () {
        $http.post('/api/Users/addCategories', $scope.categoriesSelectionnees)
            .success(function (data) {
                alert("Ajout r\u00E9ussi");
            })
            .error(function () {
                alert('Ajout non effectu\u00E9');
            });

    };

    $scope.isSelectionnee = function (categorie) {
        return $scope.categoriesSelectionnees.indexOf(categorie) != -1;
    };
}]);


wisControllers.controller('mapCtrl', function ($scope, uiGmapGoogleMapApi, $http) {
    var nombreMarker;
    var Articles;
    $http.get("/api/Articles/GetArticle/")
             .success(function (data) {
                 Articles = data;
             });

    var routeApi2 = "/api/Articles/getNombreArticle";

    $http.get(routeApi2)
          .success(function (data) {
              nombreMarker = data;
          });


    // création des markers
    var createMarker = function (i, idKey) {


        if (idKey == null) {
            idKey = "id";
        }
        var titre;
        //changer les valeurs de latitude et longitude
        if (Articles[i].id == i + 1) {
            var latitude1 = Articles[i].Latitude;
            var longitude = Articles[i].Longitude;
            titre = Articles[i].Titre;
        }
        var ret = {
            latitude: latitude1,
            longitude: longitude,
            title: titre
        };
        ret[idKey] = i;
        return ret;
    };

    var afficherMarkers = function () {
        var markers = [];
        for (var i = 0; i < nombreMarker; i++) {
            markers.push(createMarker(i))
        }
        $scope.Markers = markers;
    }

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
                         

            $scope.map = { center: { latitude: position.coords.latitude, longitude: position.coords.longitude }, zoom: 14 };
            $scope.options = {
                scrollwheel: true
            };
            afficherMarkers();
            $scope.$apply();

        }, function showError(error) {
            switch (error.code) {
                case error.PERMISSION_DENIED:
                    console.log("User denied the request for Geolocation.");
                    break;
                case error.POSITION_UNAVAILABLE:
                    console.log("Location information is unavailable.");
                    break;
                case error.TIMEOUT:
                    console.log("The request to get user location timed out.");
                    break;
                case error.UNKNOWN_ERROR:
                    console.log("An unknown error occurred.");
                    break;
            }
            $http.get("/api/Map/initMap")
            .success(function (data) {
            $scope.map = data;
            afficherMarkers();
           
        })
        .error(function (data) {

        });
        });


    } else {

        $http.get("/api/Map/initMap")
        .success(function (data) {
            $scope.map = data;
            afficherMarkers();
            $scope.$apply();
        })
        .error(function (data) {

        });
    }

    var events = {
        places_changed: function (searchBox) {
            var place = searchBox.getPlaces();
            if (!place || place == 'undefined' || place.length == 0) {
                console.log('no place data :(');
                return;
            }

            $scope.map = {
                "center": {
                    "latitude": place[0].geometry.location.lat(),
                    "longitude": place[0].geometry.location.lng()
                },
                "zoom": 18
            };
            $scope.marker = {
                id: 0,
                coords: {
                    latitude: place[0].geometry.location.lat(),
                    longitude: place[0].geometry.location.lng()
                }
            };
        }
    };
    $scope.searchbox = { template: 'searchbox.tpl.html', events: events };
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



wisControllers.controller('connectionCtrl', function ($scope, $http, $location) {
    $scope.checkUser = function () {
        //console.log($scope.user);
        $http.post("/api/Users/connectUser", $scope.user)
            .success(function (data) {
                if (data == true) {
                    alert("Authentification r\u00E9ussie, vous allez \u00EAtre redirig\u00E9...");
                    $location.path('/');
                }
                else {
                    alert('Identifiants invalides...');
                }
            })
            .error(function () {
                alert('Authentification impossible...');
            });
    }
});

wisControllers.controller('inscriptionCtrl', function ($scope, $http) {
    $scope.checkInscription = function () {
        var ourLocation = document.URL;
        console.log("Currently at " + ourLocation);
        console.log($scope.user);
        
        /*$http.post("/api/Articles/PostArticle",
                JSON.stringify($scope.article),
                {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                })
          .success(function (data) {
              $scope.article = data;
          })*/
        $http.post("/api/Users/PostUser", $scope.user)
            .success(function (data) {
                alert("Utilisateur " + data.nom + " inscrit en " + data.id + "eme position.");
            })
            .error(function () {
                alert('Inscription impossible pour le moment');
            });
    }
});
