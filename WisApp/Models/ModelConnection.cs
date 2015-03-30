using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisApp.Models
{
    public class ModelConnection
    {
        public static User user1 = new User("mohammed", "zouggari");
        public static User user2 = new User("julien", "bergaut");
        public static List<User> users = new List<User>();

        public ModelConnection()
        {
            users.Add(user1);
            users.Add(user2);
        }
    }
}