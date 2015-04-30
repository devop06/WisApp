using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WisApp.Hubs
{
    public class ArticleHub : Hub
    {
        public void refresh_server()
        {
            Clients.All.refresh();
        }
    }
}