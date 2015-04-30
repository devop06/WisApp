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
    public class UsersController : ApiController
    {
        private WisContext db = new WisContext();

        // GET: api/Users
        public IQueryable<User> GetUser()
        {
            return db.User;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid || user == null)
            {
                return BadRequest(ModelState);
            }

            User u = new User
            {
                login = user.login,
                password = user.password,
                nom = user.nom
            };

            db.User.Add(u);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.id }, u);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.User.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.User.Count(e => e.id == id) > 0;
        }

        public bool ConnectUser(User user)
        {
            foreach(User u in db.User)
                if (user.login == u.login && user.password == u.password)
                {
                    return true;
                }

            return false;
        }
    }
}