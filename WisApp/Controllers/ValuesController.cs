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
            Article article = new Article { id = id, Titre = data.Titre, Content=data.Content };
    
            Models.Ressources.initialiseData();
            Models.Ressources.listArticle.Add(article);

            return article;
        }

    }
}