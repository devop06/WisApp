using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WisApp.Models;



namespace WisApp.Models
{
    public class User
    {
        public string login { get; set; }
        public string password { get; set; }
        public string nom { get; set; }
        public Date date { get; set; }

        public List<int> idArticlesFavoris;
       
        public User()
        {
            this.idArticlesFavoris = new List<int>();
            this.idArticlesFavoris.Add(1); // article 1 en favoris
        }

        public User(string login, string password, string nom, Date date)
        {
            this.login = login;
            this.password = password;
            this.nom = nom;
            this.date = date;
           
            
        }

        public bool Equals(User user)
        {
            if (this.login == user.login && this.password == user.password
                /*&& this.nom == user.nom && this.date == user.date*/)
                return true;
            else
                return false;
        }

        public void ajouterArticleFavoris(int idArticles)
        {
            this.idArticlesFavoris.Add(idArticles);
        }
    }
}