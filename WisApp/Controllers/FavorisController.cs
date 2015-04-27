using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WisApp.Models;

namespace WisApp.Controllers
{
    public class FavorisController : ApiController
    {
        static User u = new User();

        /**
         * Ajouter un article aux favoris pour un utilisateur
         * (voir classe Users)
         **/
        [HttpPost]
        public void ajouterArticleFavo(int id)
        {
            HomeController h = new HomeController();
            // trouve l'article selectionné dans la liste des articles présent dans la base
            Article ArticleFavo = h.Articles().Find(x => x.id == id);
            u.ajouterArticleFavoris(ArticleFavo.id); // ajoute un article favoris pour un utilisateur */
        }

        [HttpPost]
        public void enleverArticleFavo(int id)
        {
            HomeController h = new HomeController();
            // trouve l'article selectionné dans la liste des articles présent dans la base
            Article ArticleFavo = h.Articles().Find(x => x.id == id);
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