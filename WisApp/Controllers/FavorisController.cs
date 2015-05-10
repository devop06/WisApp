using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WisApp.Models;
using WisApp.DAL;

namespace WisApp.Models
{
    public class FavorisController : ApiController
    {
        private Wis2Context db = new Wis2Context();
        static User u = new User();

        /**
         * Ajouter un article aux favoris pour un utilisateur
         * (voir classe Users)
         **/
        [Authorize]
        [HttpPost]
        public void ajouterArticleFavo(int id)
        {
            ArticlesController h = new ArticlesController();
           
            // trouve l'article selectionné dans la liste des articles présent dans la base
            Article ArticleFavo = db.Article.Find(id);
            u.ajouterArticleFavoris(ArticleFavo.id); // ajoute un article favoris pour un utilisateur */
        }

        [Authorize]
        [HttpPost]
        public void enleverArticleFavo(int id)
        {
            ArticlesController h = new ArticlesController();
            // trouve l'article selectionné dans la liste des articles présent dans la base
            Article ArticleFavo = db.Article.Find(id);
            u.enleverArticleFavoris(ArticleFavo.id); // ajoute un article favoris pour un utilisateur */
        }

        [HttpGet]
        public Boolean estFavoris(int id)
        {
            if (u.listeIdArticleFavo.Exists(x => x == id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}