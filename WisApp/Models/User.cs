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

        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public bool Equals(User user)
        {
            if (this.login == user.login && this.password == user.password)
                return true;
            else
                return false;
        }
    }
}