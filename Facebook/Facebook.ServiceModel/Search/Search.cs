
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using Massey.ServiceModel;

namespace Massey.Facebook.ServiceModel
{
    [Route("/search/{keyword}", "GET")]
    public class Search : IReturn<List<Comment>>
    {
        public string Keyword { get; set; }
    }

}
