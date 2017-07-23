using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace Massey.Services
{
    public static class YouTubeService
    {
        public static JsonServiceClient Client
        {
            get
            {

                return new JsonServiceClient(ConfigurationManager.AppSettings["Service.YouTube.URL"]);
            }
        }
    }
}
