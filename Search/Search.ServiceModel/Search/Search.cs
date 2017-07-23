
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;

namespace Massey.ServiceModel
{
    [Route("/search/{keyword}", "GET")]
    public class Search : IReturn<List<Comment>>
    {
        public string Keyword { get; set; }
    }


    public class Comment
    {
        public string Description { get; set; }

        public string User { get; set; }

        public DateTime Date { get; set; }

        public string Provider { get; set; }

    }
}
