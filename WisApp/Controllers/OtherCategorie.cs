using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WisApp.Controllers;
using WisApp.Models;

namespace ExCategorie.Controllers
{
    public class OtherCategorie
    {
        public OtherCategorie()
        {

        }

        public string Name { get; set; }
        public List<Article> Articles { get; set; }
    }
}
