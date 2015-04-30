using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using WisApp.Controllers;
using WisApp.Models;

namespace WisApp.Hubs
{
    public class ArticleHub : Hub
    {
        public void NotifyArticle(Article newArticle)
        {
            Clients.Others.onArticleChanged(newArticle);
        }
    }
}