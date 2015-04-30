using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WisApp.Controllers;

namespace WisApp.Models
{
    public class Categorie
    {
        public Categorie()
        {

        }
        public int id { get; set; }
        public string Name { get; set; }
        public List<Article> Articles { get; set; }
    }
}
