var wisControllers = angular.module('wisControllers');

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
        for (var key in proxyArticleHub.client.onArticleChanged)
        {
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

