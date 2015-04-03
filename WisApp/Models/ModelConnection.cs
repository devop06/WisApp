using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisApp.Models
{
    public static class ModelConnection
    {
        public static User user1 = new User("mohammed@wis", "zouggari", "Zouggari", new Date(04, 02, 1989));
        public static User user2 = new User("julien@wis", "bergaut", "Bergaut", new Date(06, 04, 1994));
        public static User user3 = new User("tony@wis", "villanova", "villanova", new Date(18, 02, 1993));
        public static List<User> users = new List<User> (new User[] {user1, user2, user3});
    }
}