using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WisApp.DAL;
using WisApp.Models;

namespace WisApp.Controllers
{
    public class ArticlesController : ApiController
    {
        private Wis2Context db = new Wis2Context();

        // GET: api/Articles/Articles/
        public IQueryable<Article> GetArticle()
        {
            return db.Article;
        }

        // GET: api/Articles/GetArticle/4
        [ResponseType(typeof(Article))]
        public IHttpActionResult GetArticle(int id)
        {
            Article article = db.Article.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            return Ok(article);
        }

        
        //Ajouter un Article
        // POST: api/Articles
        [ResponseType(typeof(Article))]
        public IHttpActionResult PostArticle(Article data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Article article = new Article
            {
                id = data.id,
                Titre = data.Titre,
                Content = data.Content,
                Tags = data.Tags,
                Auteur = data.Auteur,
                Date = DateTime.Today.ToString("dd/MM/yyyy"),
                Heure = DateTime.Now.ToString("HH:mm:ss tt"),
                Image = data.Image,
                Description = data.Description,
                Source = data.Source,
                Latitude = data.Latitude,
                Longitude = data.Longitude,
                Visibilite = data.Visibilite
            };
            db.Article.Add(article);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = article.id }, article);
        }

        // DELETE: api/Articles/5
        [ResponseType(typeof(Article))]
        public IHttpActionResult DeleteArticle(int id)
        {
            Article article = db.Article.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            db.Article.Remove(article);
            db.SaveChanges();

            return Ok(article);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public int getNombreArticle()
        {
            return db.Article.Count();
        }

        private bool ArticleExists(int id)
        {
            return db.Article.Count(e => e.id == id) > 0;
        }
    }
}