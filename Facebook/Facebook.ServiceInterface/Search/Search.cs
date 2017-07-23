using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using Massey.ServiceModel;
using ServiceStack.OrmLite;
using System.Net;
using ServiceStack.Data;

namespace Massey.Facebook.ServiceInterface
{
    public partial class FacebookService : Service
    {

        public object Any(Search request)
        {
            //using (var db = DbFactory.Open())
            //{
            //    CheckTableExistsAndInitialize<Activity>(db);

            //    var response = db.LoadSelect<Activity>()
            //            .Where(x => x.AccountID == request.AccountID)
            //            .OrderByDescending(x => x.DateCreated).Take(50);

            //    return response.ToList<Activity>();
            //}
            var results = new List<Comment>();
            results.Add(new Comment { Description = "Pong", Provider = "Facebook" });
            return results;
        }
    }
}
