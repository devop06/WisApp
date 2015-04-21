using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WisApp.Models;

namespace ExCategorie.Controllers
{
    public class Categorie
    {
        public Categorie()
        {

        }

        public string Name { get; set; }
        public List<Article> Articles { get; set; }
    }
}
