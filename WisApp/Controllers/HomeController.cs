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
        private List<Article> resultat = null;
        [HttpGet]
        public List<Article> Articles()
        {

            resultat = new List<Article>();
            resultat.Add(new Article() { id= 1, Titre = "Jean-Luc Lahaye jugé pour corruption de mineure de moins de 15 ans", Heure="14:29", Description = "Description gros", Auteur = "moi-même" });
            resultat.Add(new Article() { id= 2, Titre = "Le PS certain de conserver «une vingtaine» de départements", Heure = "14:24", Description = "Description", Auteur = "un autre" });
            resultat.Add(new Article() { id= 3, Titre = "Les Bleus sont arrivés à Clairefontaine", Heure = "14:23", Description = "Description", Auteur = "un autre" });
            resultat.Add(new Article() { id= 4, Titre = "Royaume-Uni : le petit Ashya King est guéri, selon sa famille", Heure = "14:12", Description = "Description", Auteur = "un autre" });
            resultat.Add(new Article() { id= 5, Titre = "Suisse: la haute horlogerie décline les métiers d'art à Baselworld", Heure = "14:09", Description = "Description", Auteur = "un autre" });
            resultat.Add(new Article() { id= 6, Titre = "Radio France : le PDG Gallet présente ses excuses au personnel", Heure = "14:09", Description = "Description", Auteur = "un autre" });
            
            return resultat;
        }

        
        public Article getArticle(int id)
        {
            foreach (Article a in this.resultat)
            {
                if (a.id == id)
                {
                    return a;
                }
                else
                    return null;
            }

            return null;
        }


    }
}
