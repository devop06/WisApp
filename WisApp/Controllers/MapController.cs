using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WisApp.Models
{
    public class MapController : ApiController
    {


        [HttpGet]
        public Map initMap()
        {
            var map = new Map();
            var center = new Center();

            center.latitude = 46.6698231;
            center.longitude = 2.9012201;
            map.center = center;
            map.zoom = 6;

            return map;
        }
    }
}
