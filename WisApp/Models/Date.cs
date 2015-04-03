using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisApp.Models
{
    public class Date
    {
        public int jour { get; set;}
        public int mois { get; set;}
        public int annee { get; set; }

        public Date(int jour, int mois, int annee)
        {
            this.jour = jour;
            this.mois = mois;
            this.annee = annee;
        }

        public bool Equals(Date d)
        {
            if (this.jour == d.jour && this.mois == d.mois && this.annee == d.annee)
                return true;
            else
                return false;
        }
    }
}