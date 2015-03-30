using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisApp.Models
{
    public static class ModelConnection
    {
        public static User user1 = new User("mohammed@wis", "zouggari");
        public static User user2 = new User("julien@wis", "bergaut");
        public static List<User> users = new List<User> (new User[] {user1, user2});
    }
}