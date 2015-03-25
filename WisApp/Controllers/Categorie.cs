using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExCategorie.Controllers
{
    public class Categorie
    {
        public Categorie()
        {

        }

        public string Name { get; set; }
        public List<Article> Article { get; set; }
    }
}
