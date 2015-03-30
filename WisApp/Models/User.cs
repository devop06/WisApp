using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisApp.Models
{
    public class User
    {
        public string user { get; set; }
        public string password { get; set; }

        public User(string user, string password)
        {
            this.user = user;
            this.password = password;
        }
    }
}