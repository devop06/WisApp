using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WisApp.Models;

namespace WisApp.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpPost]
        public Article PartageAjout(Article data)
        {
            var HomeController = new HomeController();
            int id = HomeController.Articles().Count() + 1;
            Article article = new Article
            {
                id = id,
                Titre = data.Titre,
                Content = data.Content,
                Tags = data.Tags,
                Auteur = data.Auteur,
                Date = DateTime.Today.ToString("dd/MM/yyyy"),
                Heure = DateTime.Now.ToString("HH:mm:ss tt"),
                Image = data.Image,
                Description = data.Description, 
            Source = data.Source, Latitude=data.Latitude, Longitude=data.Longitude, Visibilite=data.Visibilite};
            //Article article = data;
            Models.Ressources.initialiseData();
            Models.Ressources.listArticle.Add(article);

            return article;
        }

    }
}