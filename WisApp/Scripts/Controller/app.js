/*var app = angular.module('Wis', []);
app.controller('WisController', WisController);*/



var wisApp = angular.module('wisApp', [
  'ngRoute',
  'wisControllers', 
  'uiGmapgoogle-maps'
]);

wisApp.config(['$routeProvider',
  function($routeProvider) {
    $routeProvider.
	  when('/', {
        templateUrl: 'view/index.html',
        controller: 'indexCtrl'
      }).
      when('/connection', {
        templateUrl: 'view/connection.html',
        controller: 'connectionCtrl'
      }).
	  when('/article', {
        templateUrl: 'view/article.html',
        controller: 'articleCtrl'
      }).
	  when('/partager', {
        templateUrl: 'view/partager.html',
        controller: 'partagerCtrl'
      }).
	  when('/map', {
        templateUrl: 'view/map.html',
        controller: 'mapCtrl'
      }).
	  when('/categorie', {
        templateUrl: 'view/categorie.html',
        controller: 'categorieCtrl'
      }).
	  /*when('/article', {
        templateUrl: 'view/article.html',
        controller: 'articleCtrl'
      }).*/
	  
	  
	  
      otherwise({
        redirectTo: '/'
      });
  }]);