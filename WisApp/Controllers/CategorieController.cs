using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WisApp.Controllers;
using WisApp.DAL;
using WisApp.Models;

namespace ExCategorie.Controllers
{
    public class CategorieController : ApiController
    {
        private Wis2Context db = new Wis2Context();

        [HttpGet]
        public List<Categorie> Categorie()
        {
            List<Categorie> resultat = new List<Categorie>();
            List<Article> article;
            var uneCategorie = new Categorie();
            uneCategorie.Name = "Politique";
            resultat.Add(uneCategorie);
            uneCategorie = new Categorie();
            uneCategorie.Name = "Sport";
            resultat.Add(uneCategorie);
            uneCategorie = new Categorie();
            uneCategorie.Name = "Science";
            resultat.Add(uneCategorie);
            uneCategorie = new Categorie();
            uneCategorie.Name = "Technologie";
            resultat.Add(uneCategorie);
            uneCategorie = new Categorie();
            uneCategorie.Name = "Art";
            uneCategorie = new Categorie();
            uneCategorie.Name = "Faits divers";
            resultat.Add(uneCategorie);

            List<Article> articles = new List<Article>();
            Article art = new Article();
            art.Titre = "Tennis";
            art.Categorie = "Sport";
            articles.Add(art);
            art = new Article();
            art.Titre = "Football";
            art.Categorie = "Sport";
            articles.Add(art);
            art = new Article();
            art.Titre = "Parti de gauche";
            art.Categorie = "Politique";
            articles.Add(art);

            ArticlesController h = new ArticlesController();
            IQueryable<Article> arts = h.GetArticle();
            articles = arts.ToList<Article>();

            for (int i = 0; i < resultat.Count(); i++) //pour le nb de categories
            {
                article = new List<Article>();
                for (int j = 0; j < articles.Count(); j++)// pour le nb d'articles
                {
                    if (resultat[i].Name == articles[j].Categorie)
                    {
                        if (article.Count() < 3) { 
                            article.Add(articles[j]);
                        }
                    }
                }
                resultat[i].Articles = article;
                article = null;
            }

            return resultat;

            /*var unArticle = new Article();

            unArticle.Titre = "Parti de gauche";
            article.Add(unArticle);
            unArticle = new Article();
            unArticle.Titre = "Parti de droite";
            article.Add(unArticle);
            unArticle = new Article();
            unArticle.Titre = "Parti de centre";
            article.Add(unArticle);
            uneCategorie.Name = "Politique";
            uneCategorie.Articles = article;
            resultat.Add(uneCategorie);

            unArticle = new Article();
            unArticle.Titre = "Le football";
            article.Add(unArticle);
            unArticle = new Article();
            unArticle.Titre = "Le basket-ball";
            article.Add(unArticle);
            unArticle = new Article();
            unArticle.Titre = "Tennis";
            article.Add(unArticle);
            uneCategorie = new Categorie();
            uneCategorie.Name = "Sport";
            uneCategorie.Articles = article;
            resultat.Add(uneCategorie);

            unArticle = new Article();
            unArticle.Titre = "Corps humain";
            article.Add(unArticle);
            unArticle = new Article();
            unArticle.Titre = "Les organes vitaux";
            article.Add(unArticle);
            unArticle = new Article();
            unArticle.Titre = "La chirurgie";
            article.Add(unArticle);
            uneCategorie = new Categorie();
            uneCategorie.Name = "Science";
            uneCategorie.Articles = article;
            resultat.Add(uneCategorie);

            unArticle = new Article();
            unArticle.Titre = "Lunettes 3D";
            article.Add(unArticle);
            unArticle = new Article();
            unArticle.Titre = "Robot domestique";
            article.Add(unArticle);
            unArticle = new Article();
            unArticle.Titre = "Fusée";
            article.Add(unArticle);
            uneCategorie = new Categorie();
            uneCategorie.Name = "Technologie";
            uneCategorie.Articles = article;
            resultat.Add(uneCategorie);

            unArticle = new Article();
            unArticle.Titre = "Peinture";
            article.Add(unArticle);
            unArticle = new Article();
            unArticle.Titre = "Cinéma";
            article.Add(unArticle);
            unArticle = new Article();
            unArticle.Titre = "Musique";
            article.Add(unArticle);
            uneCategorie = new Categorie();
            uneCategorie.Name = "Art";
            uneCategorie.Articles = article;
            resultat.Add(uneCategorie);

            return resultat;

        }

        [HttpGet]
        public List<OtherCategorie> OtherCategorie()
        {
            List<OtherCategorie> resultat = new List<OtherCategorie>();
            List<Article> article = new List<Article>();

            var unArticle = new Article();
            var uneCategorie = new OtherCategorie();

            unArticle = new Article();
            unArticle.Titre = "Le Groenland";
            article.Add(unArticle);
            unArticle = new Article();
            unArticle.Titre = "L'Australie";
            article.Add(unArticle);
            unArticle = new Article();
            unArticle.Titre = "Les canaries";
            article.Add(unArticle);
            uneCategorie = new OtherCategorie();
            uneCategorie.Name = "Géographie";
            uneCategorie.Articles = article;
            resultat.Add(uneCategorie);

            unArticle = new Article();
            unArticle.Titre = "La première guerre mondiale";
            article.Add(unArticle);
            unArticle = new Article();
            unArticle.Titre = "La chute du mur de berlin";
            article.Add(unArticle);
            unArticle = new Article();
            unArticle.Titre = "Le roi soleil";
            article.Add(unArticle);
            uneCategorie = new OtherCategorie();
            uneCategorie.Name = "Histoire";
            uneCategorie.Articles = article;
            resultat.Add(uneCategorie);

            unArticle = new Article();
            unArticle.Titre = "Les lasagnes";
            article.Add(unArticle);
            unArticle = new Article();
            unArticle.Titre = "Les escargots";
            article.Add(unArticle);
            unArticle = new Article();
            unArticle.Titre = "Le big mac";
            article.Add(unArticle);
            uneCategorie = new OtherCategorie();
            uneCategorie.Name = "Cuisine";
            uneCategorie.Articles = article;
            resultat.Add(uneCategorie);

            unArticle = new Article();
            unArticle.Titre = "Baudelaire";
            article.Add(unArticle);
            unArticle = new Article();
            unArticle.Titre = "Zola";
            article.Add(unArticle);
            unArticle = new Article();
            unArticle.Titre = "Maupassant";
            article.Add(unArticle);
            uneCategorie = new OtherCategorie();
            uneCategorie.Name = "Littérature";
            uneCategorie.Articles = article;
            resultat.Add(uneCategorie);

            unArticle = new Article();
            unArticle.Titre = "La police et le pélican sauvage";
            article.Add(unArticle);
            unArticle = new Article();
            unArticle.Titre = "Le traitre";
            article.Add(unArticle);
            unArticle = new Article();
            unArticle.Titre = "L'arnaque";
            article.Add(unArticle);
            uneCategorie = new OtherCategorie();
            uneCategorie.Name = "Cinéma";
            uneCategorie.Articles = article;
            resultat.Add(uneCategorie);

            unArticle = new Article();
            unArticle.Titre = "Classique";
            article.Add(unArticle);
            unArticle = new Article();
            unArticle.Titre = "Jazz";
            article.Add(unArticle);
            unArticle = new Article();
            unArticle.Titre = "Rap";
            article.Add(unArticle);
            uneCategorie = new OtherCategorie();
            uneCategorie.Name = "Musique";
            uneCategorie.Articles = article;
            resultat.Add(uneCategorie);

            return resultat;*/

        }
    }
}
