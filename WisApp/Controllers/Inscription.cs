using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WisApp.Models;

namespace WisApp.Controllers
{
    public class Inscription : ApiController
    {
        [HttpPost]

        public string checkInscription(string login, string password, string name, string date)
        {
            string[] s = date.Split("/".ToCharArray());
            Date d = new Date(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]));
            User user = new User(login, password, name, d);
            string result;
            if (ModelConnection.users.Find(x => x.Equals(user)) == null)
            {
                ModelConnection.users.Add(user);
                result = "Inscription réussie";
            }
            else if (ModelConnection.users.Find(x => x.Equals(user)) != null)
                result = "Vous êtes déjà inscrit";
            else
            {
                result = "Echec de l'inscription";
            }

            return result;
        }
    }
}