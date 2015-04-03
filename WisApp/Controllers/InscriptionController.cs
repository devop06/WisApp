﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WisApp.Models;

namespace WisApp.Controllers
{
    public class InscriptionController : ApiController
    {
        [HttpPost]

        public String checkInscription(User user)
        {
            String result;
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