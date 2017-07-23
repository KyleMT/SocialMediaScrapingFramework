using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace Massey.Services
{
    public static class InstagramService
    {
        public static JsonServiceClient Client
        {
            get
            {

                return new JsonServiceClient(ConfigurationManager.AppSettings["Service.Instagram.URL"]);
            }
        }
    }
}
