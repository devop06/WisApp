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
      //  private User u;
        
        
        /**
         * Ajouter un article aux favoris pour un utilisateur
         * (voir classe Users)
         **/
       
        public void ajouterArticleFavo(int idArticle)
        {
          /*  HomeController h = new HomeController();
           // trouve l'article selectionné dans la liste des articles présent dans la base
            Article ArticleFavo = h.Articles().Find(x => x.id == idArticle);
            
            u.ajouterArticleFavoris(ArticleFavo); // ajoute un article favoris pour un utilisateur */
        }
        [HttpGet]
        public int estFavoris(int idArticle)
        {
           /* if(u.listeArticleFavo.Exists(x => x.id == idArticle))
            {
                return true;
            }
            else
            {
                return false;
            */
            return 2221;
        }

    }
}
