using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WisApp.Controllers
{
    public class HomeController : ApiController
    {   
        [HttpGet]
        public List<Article> Articles()
        {

            var resultat = new List<Article>();
            resultat.Add(new Article() { Titre = "Jean-Luc Lahaye jugé pour corruption de mineure de moins de 15 ans", Heure="14:29", Description = "Description gros", Auteur = "moi-même" });
            resultat.Add(new Article() { Titre = "Le PS certain de conserver «une vingtaine» de départements", Heure = "14:24", Description = "Description", Auteur = "un autre" });
            resultat.Add(new Article() { Titre = "Les Bleus sont arrivés à Clairefontaine", Heure = "14:23", Description = "Description", Auteur = "un autre" });
            resultat.Add(new Article() { Titre = "Royaume-Uni : le petit Ashya King est guéri, selon sa famille", Heure = "14:12", Description = "Description", Auteur = "un autre" });
            resultat.Add(new Article() { Titre = "Suisse: la haute horlogerie décline les métiers d'art à Baselworld", Heure = "14:09", Description = "Description", Auteur = "un autre" });
            resultat.Add(new Article() { Titre = "Radio France : le PDG Gallet présente ses excuses au personnel", Heure = "14:09", Description = "Description", Auteur = "un autre" });
            
            
            
            
            return resultat;
        }


        [HttpGet]
        public Map initMap()
        {

            var map = new Map();
            var center = new Center();
            center.latitude=46.6698231;
            center.longitude = 2.9012201;
            map.center=center;
            map.zoom=6;
            return map;
        }

    }
}
