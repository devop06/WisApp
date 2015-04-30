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
            Models.Ressources.initialiseData();
            return Models.Ressources.listArticle;
        }

        
        public Article getArticle(int id)
        {
          
            Article a = Articles().Find(x => x.id == id);

            return a;
        }

        public int getNombreArticle()
        {
            return Articles().Count();
        }

        public List<Article> getArticlesPagination(int id)
        {
            Models.Ressources.initialiseData();
            return Models.Ressources.listArticle.GetRange(id, 2); ;
        }
    }
}