using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WisApp.Models;

namespace WisApp.Models
{
    public class ConnectionController : ApiController {
        [HttpPost]

        public bool checkUser(User user){
            if (ModelConnection.users.Find(x => x.Equals(user)) != null)
            {
                return true;
            }
            /*
            if (user.Equals(ModelConnection.user1) || user.Equals(ModelConnection.user2))
            {
                return true;
            }
            /*
            if(user.login == "julien@wis" && user.password == "bergaut"){
                return true;
            }
            */
            else
                return false;
        }
    }
}