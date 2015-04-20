using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisApp.Models
{
    public class User
    {
        public string login { get; set; }
        public string password { get; set; }
        public string nom { get; set; }

        public User()
        {

        }

        public User(string login, string password, string nom)
        {
            this.login = login;
            this.password = password;
            this.nom = nom;
        }

        public bool Equals(User user)
        {
            if (this.login == user.login && this.password == user.password
                /*&& this.nom == user.nom && this.date == user.date*/)
                return true;
            else
                return false;
        }
    }
}