using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WisApp.Models;

namespace WisApp.Controllers
{
    public class ConnectionController : ApiController {
        [HttpPost]

        public bool checkUser(User user){
            if (ModelConnection.users.Find(x => x.Equals(user)) != null)
            {
                return true;
            }
            else
                return false;
        }
    }
}