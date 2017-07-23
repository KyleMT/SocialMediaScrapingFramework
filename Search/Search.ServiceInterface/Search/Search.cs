using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using Massey.ServiceModel;
using Massey.Services;
using ServiceStack.OrmLite;
using System.Net;
using ServiceStack.Data;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Massey.ServiceInterface
{
    public partial class SearchService: Service
    {

        public static List<Comment> DoWorkFacebook(string data)
        {
            var results = new List<Comment>();
            results.Add(new Comment { Description = "123" });
            return results;
        }

        public static List<Comment> DoWorkFlickr(string data)
        {
            var results = new List<Comment>();
            results.Add(new Comment { Description = "123" });
            return results;
        }


        public static List<Comment> DoWorkInstagram(string data)
        {
            var results = new List<Comment>();
            results.Add(new Comment { Description = "123" });
            return results;
        }


        public static List<Comment> DoWorkTwitter(string data)
        {
            var results = new List<Comment>();
            results.Add(new Comment { Description = "123" });
            return results;
        }


        public static List<Comment> DoWorkYouTube(string data)
        {
            var results = new List<Comment>();
            results.Add(new Comment { Description = "123" });
            return results;
        }

 


        public object Any(Search request)
        {

            var resultCollection = new ConcurrentBag<Comment>();

            Parallel.Invoke(
                () => resultCollection.AddRange(FacebookService.Client.Get(new Search { Keyword = request.Keyword })),
                () => resultCollection.AddRange(FlickrService.Client.Get(new Search { Keyword = request.Keyword })),
                () => resultCollection.AddRange(InstagramService.Client.Get(new Search { Keyword = request.Keyword })),
                () => resultCollection.AddRange(TwitterService.Client.Get(new Search { Keyword = request.Keyword })),
                () => resultCollection.AddRange(YouTubeService.Client.Get(new Search { Keyword = request.Keyword }))
            );

            return resultCollection.ToList();// response;
        }


    }
}
