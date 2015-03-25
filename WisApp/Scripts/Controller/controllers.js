var wisControllers = angular.module('wisControllers', []);



wisControllers.controller('indexCtrl',
	function ($scope,$http) {


	   $http.get("/api/Home/Articles")
            .success(function (data) {
                $scope.Message = "TRUE";
                $scope.Articles = data;
            });



	});


wisControllers.controller('partagerCtrl', ['$scope',
	function ($scope, $http){


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

wisControllers.controller('articleCtrl', ['$scope',
	function ($scope){
		var articlePartager = {
		titre : 'Titre de l\'article',
		corps : "L’enquête sur les assassinats de Charlie Hebdo et les attaques qui ont suivi à Montrouge (Hauts-de-Seine), à la porte de Vincennes et peut-être même à Fontenay-aux-Roses (Hauts-de-Seine), promet d’être longue. L’ampleur de la tâche est gigantesque : trois services de police sont mobilisés – la police judiciaire parisienne, la sous-direction antiterroriste et la direction générale de la sécurité intérieure (DGSI). La section antiterroriste du parquet de Paris dirige l’ensemble. Les auteurs sont morts mais les enquêteurs cherchent à comprendre comment ces actes ont été préparés et à identifier leurs éventuels complices. On ne sait toujours pas si les frères Kouachi et Amedy Coulibaly ont échangé des mails, s’ils se sont appelés ou s’ils se sont donné rendez-vous avant leur funeste entreprise. Ni qui ils avaient informé dans leur entourage. Mais des éléments nouveaux sont apparus ce week-end, notamment une vidéo dans laquelle le preneur d’otages de Vincennes revendique ses actes. Une partie du montage ayant été réalisée après les attaques, la question d’éventuels complices, toujours vivants, se pose. La vidéo du preneur d’otage et ses complices Dimanche matin, alors que des millions de Français s’apprêtent à manifester pour crier leur refus du terrorisme et rendre hommage à ceux qui ont osé le défier, une vidéo de sept minutes, référencée « soldat_du_califat », tourne sur les sites Dailymotion et Youtube. Aussitôt alertée, le ministère de l’intérieur cesse sa diffusion. Le Monde a pu visionner ces images avant qu’elles disparaissent de la toile. En lettres capitales sur un fond noir, la vidéo commence par dresser le bilan des attaques : « Amedy Coulibaly (…) auteur des attaques bénies de Montrouge où il a exécuté une policière le 8 janvier. Le lendemain, il mène une attaque porte de Vincennes où il prend en otage 17 personnes dans une épicerie juive et exécute 5 juifs ». Elle montre également des images de la façade de l’Hyper Cacher de la porte de Vincennes. Ces éléments prouvent qu’une personne est intervenue sur le montage après la mort d’Amedy Coulibaly. On voit ensuite le preneur d’otages faire quelques pompes, puis poser en quatre endroits différents pour répondre à des questions dont le texte s’affiche sur une diapositive noire. La mise en scène est très soignée, le ton calme. Le film a une ambition didactique et prosélyte. En savoir plus sur http://www.lemonde.fr/societe/article/2015/01/12/dans-une-video-coulibaly-detaille-son-projet-meurtrier_4554313_3224.html#E5ZDRrsJrf4ymov8.99",
		auteur : 'auteur',
		tags : ' tech, sport, eco, droit...',
		date : '12/01/2015',
		source : 'http://www.lemonde.fr/'

		};
		$scope.article = articlePartager;
 }]);

wisControllers.controller('categorieCtrl', ['$scope', '$http', function($scope, $http) {
    $http.get('/api/Categorie/Categorie').success(function (data) {
        $scope.categories = data;
    });
    
    $http.get('/api/Categorie/OtherCategorie').success(function (data) {
        $scope.autres = data;
    });
    
    $scope.orderProp = 'Titre';

}]);

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