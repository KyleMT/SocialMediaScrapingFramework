using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using Massey.ServiceModel;
using ServiceStack.OrmLite;
using System.Net;
using ServiceStack.Data;
using FlickrNet;

namespace Massey.Flickr.ServiceInterface
{
    public partial class FlickrService : Service
    {

        public object Any(Search request)
        {
            ///

            var results = new List<Comment>();
            
            FlickrNet.Flickr flickr = new FlickrNet.Flickr();
            flickr.ApiKey = "e3fc3cc5de2994589d1e8337a5d245e6";
            flickr.ApiSecret = "0678d10c68219c84";

            var options = new PhotoSearchOptions { Tags = request.Keyword, PerPage = 20, Page = 1 };
            PhotoCollection photos = flickr.PhotosSearch(options);

            foreach (Photo photo in photos)
            {
                results.Add(new Comment { Description = photo.Title, Provider = "Flickr" });
            }

            return results;
        }
    }
}
