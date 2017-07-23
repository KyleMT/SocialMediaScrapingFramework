using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using Massey.ServiceModel;
using ServiceStack.OrmLite;
using System.Net;
using ServiceStack.Data;
using Skybrud.Social.Twitter;
using Skybrud.Social.Twitter.OAuth;
using Skybrud.Social.Twitter.Responses;
using Skybrud.Social.Twitter.Objects;

namespace Massey.Twitter.ServiceInterface
{
    public partial class FacebookService : Service
    {

        public object Any(Search request)
        {
            TwitterOAuthClient client = new TwitterOAuthClient
            {
                ConsumerKey = "sz5EPgUcZQQAyAkp3LrlgHrMZ",
                ConsumerSecret = "wC2TIL67sIbELO6OYgaTg2RE3ctH1TTRkC0q0hpisWyztThBg1",
                Token = "189161034-KoBoQR97ZdailKAAdVLK63gaM2yUlnhN9tQuOSJ8",
                TokenSecret = "k7P8TsvpyqyMwOrPh7mOgSgILVvMFFglj1LhAvSa5KEoc"
            };

            var twitter = TwitterService.CreateFromOAuthClient(client);
            var results = new List<Comment>();

            TwitterSearchTweetsResponse response = twitter.Search.GetTweets("#" + request.Keyword);

            foreach (TwitterStatusMessage tweet in response.Body.Statuses)
            {
                results.Add(new Comment { Description = tweet.Text, Provider = "Twitter" });

            }
            
            
            return results;
        }
    }
}
