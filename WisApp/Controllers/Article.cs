using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WisApp.Controllers
{
    public class Article
    {
        public Article()
        {

        }

        public int id { get; set; }
        public string Titre { get; set; }
        public string Date { get; set; }
        public string Heure { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Auteur { get; set; }
        public string Tags { get; set; }
        public string Source { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }

    
}
