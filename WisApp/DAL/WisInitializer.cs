using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WisApp.Models;
using WisApp.DAL;

namespace WisApp.DAL
{
    public class WisInitializer : System.Data.Entity.DropCreateDatabaseAlways<Wis2Context>
    {
        protected override void Seed(Wis2Context context)
        {
            var users = new List<User>
            {
            new User(1, "mohammed@wis", "zouggari", "Zouggari"),
            new User(2, "julien@wis", "bergaut", "Bergaut"),
            new User(3, "tony@wis", "villanova", "villanova"),
            new User(4, "faisal@wis", "choudhry", "choudhry"),
            new User(5, "hugo@wis", "lecolle", "lecolle"),
            new User(6, "antoine@wis", "jacob", "jacob"),
            new User(7, "jeremy@wis", "lopez", "lopez")
            };

            users.ForEach(s => context.User.Add(s));
            context.SaveChanges();



            var articles = new List<Article>
            {

            new Article() 
            {
                id = 1, Titre = "Jean-Luc Lahaye jugé pour corruption de mineure de moins de 15 ans",
                Date = "20/03/2015", 
                Heure = "14:15",
                Description = "Description gros",
                Content = "Ce lundi, le chanteur de variétés de 62 ans comparaît devant le tribunal correctionnel de Paris. Il est accusé d'avoir demandé à une jeune fille de s'adonner à des jeux sexuels par webcam interposée. L'ancienne gloire des années 1980 face à la justice. Ce lundi, Jean-Luc Lahaye sera jugé par le tribunal correctionnel de Paris pour corruption sur mineure de moins de 15 ans. Le chanteur de 62 ans est poursuivi pour «proposition sexuelle à une mineure de moins de 15 ans en utilisant un moyen de communication électronique» et «détention d'image pornographique représentant des mineurs». Selon un source proche du dossier, l'artiste aurait demandé à une jeune fille de s'adonner à des jeux sexuels par webcam interposée.",
                Auteur = "moi-même",
                Image = "http://i.f1g.fr/media/ext/805x453_crop/www.lefigaro.fr/medias/2015/03/23/PHO0958d824-d0a9-11e4-a8ee-2fd35b8a82ce-805x453.jpg",
                Latitude = 48.856614, Longitude = 2.352222,
                Categorie = "Faits divers" },
            new Article()
            {
                id = 2,
                Titre = "Le PS certain de conserver «une vingtaine» de départements",
                Date = "20/03/2015", 
                Heure = "19:54",
                Description = "Description",
                Content = "Au lendemain du premier tour des élections départementales 2015, les personnalités politiques ont réagi lundi aux bons scores de la droite. Compte tenu du nombre de triangulaires, environ 300, les questions du maintien et du front républicain au second tour ont ressurgi.",
                Auteur = "un autre",
                Image = "http://s3.lprs1.fr/images/2015/03/23/4630387_valloutg_545x460_autocrop.jpg",
                

                Latitude = 48.839695, 
                Longitude = 2.239912,
                Categorie = "Politique"
            },
            new Article()
            { 
                id = 3,                 
                Titre = "Les Bleus sont arrivés à Clairefontaine",
                Date = "21/03/2015", 
                Heure = "13:37", 
                Description = "Les bleus sont arrivés sans se presser...", 
                Content = "Les bleus sont arrivés sans se presser...", 
                Auteur = "un autre", 
                Image = "http://i1.eurosport.com/2015/03/29/1446228-30921410-1600-900.jpg", 
                

                Latitude = 48.612377, 
                Longitude = 1.908500,
                Categorie = "Sport"
            },

            
            new Article()
            {
                id = 4,
                Titre = "Royaume-Uni : le petit Ashya King est guéri, selon sa famille",
                Date = "21/03/2015", 
                Heure = "18:12",
                Description = "Description",
                Content = "Le petit garçon qui avait ému le Royaume-Uni serait guéri. La tumeur au cerveau du petit Britannique Ashya King, qui avait été sorti clandestinement par ses parents d'un hôpital anglais pour aller suivre un traitement de protonthérapie en République Tchèque, est «neutralisée», a affirmé lundi l'avocat de sa famille.",
                Auteur = "un autre",
                Image = "http://s3.lprs1.fr/images/2015/03/23/4629749_ashya-king_545x460_autocrop.jpg",
                

                Longitude = 51.5030439,
                Latitude = -0.1304626,
                Categorie = "Faits divers"
            },
            new Article()
            {
                id = 5,
                Titre = "Suisse: la haute horlogerie décline les métiers d'art à Baselworld",
                Date = "23/03/2015", 
                Heure = "09:09",
                Description = "Description",
                Content = "Broderie, porcelaine, petits automates... Les horlogers de prestige ont une fois encore décliné les métiers d’art dans les montres présentées à Baselworld, marquant ainsi leur ancrage dans le luxe intemporel, à mille lieux de la montre connectée...",
                Auteur = "un autre",
                Image = "http://md1.libe.com/photo/725598-une-montre-de-l-horloger-suisse-corum-rachete-par-le-groupe-chinois-citychamp-watch-jewellery-group-.jpg?modified_at=1427116504&width=750",
                

                Latitude = 47.563954, 
                Longitude = 7.600939,
                Categorie = "Art"
            },
            new Article()
            {
                id = 6,
                Titre = "Radio France : le PDG Gallet présente ses excuses au personnel",
                Date = "23/03/2015", 
                Heure = "14:09",
                Description = "Description",
                Auteur = "un autre",
                Content = "La quasi totalité des stations du groupe Radio France seront de nouveau muettes mardi. Les cinq syndicats qui ont appelé à une grève illimitée jeudi dernier (CFDT, CGT, SNFORT, SUD, Unsa), ont annoncé reconduire le mouvement pour un 6e jour ce mardi...",
                Image = "http://s3.lprs1.fr/images/2015/03/20/4620931_capture_545x460_autocrop.PNG",
                

                Latitude = 48.852712, 
                Longitude = 2.278184,
                Categorie = "Faits divers"
            }
            };
            articles.ForEach(s => context.Article.Add(s));
            context.SaveChanges();
        }
    }
}