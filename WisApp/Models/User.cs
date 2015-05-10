using ExCategorie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisApp.Models
{
    public class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string nom { get; set; }
        public List<int> listeIdArticleFavo {get;set;}
        public List<Categorie> categories { get; set; }

        public User()
        {
            this.listeIdArticleFavo = new List<int>();
        }

        public User(int id, string login, string password, string nom)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.nom = nom;
            this.listeIdArticleFavo = new List<int>();
        }

        public bool Equals(User user)
        {
            if (this.login == user.login && this.password == user.password
                /*&& this.nom == user.nom && this.date == user.date*/)
                return true;
            else
                return false;
        }

        public void ajouterArticleFavoris(int id)
        {
            this.listeIdArticleFavo.Add(id);
        }

        public void enleverArticleFavoris(int id)
        {
            this.listeIdArticleFavo.Remove(id);
        }
    }
}