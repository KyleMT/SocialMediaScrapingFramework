using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using Massey.ServiceModel;
using ServiceStack.OrmLite;
using System.Net;
using ServiceStack.Data;
using Skybrud.Social.Instagram;
using Skybrud.Social.Instagram.OAuth;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Options;
using Skybrud.Social.Instagram.Responses;
using Skybrud.Social.Instagram.Options.Tags;

namespace Massey.Twitter.ServiceInterface
{
    public partial class InstagramService : Service
    {

        public object Any(Search request)
        {
            ///

            var results = new List<Comment>();

            Skybrud.Social.Instagram.InstagramService service = Skybrud.Social.Instagram.InstagramService.CreateFromOAuthClient(new InstagramOAuthClient
            {
                AccessToken = "281166601.ae390ad.f16a68e5d161400a88f124dd07690b36"
            });

            // Temporary list for storing the retrieved media
            List<InstagramMedia> temp = new List<InstagramMedia>();

            // Declare the initial options
            InstagramTagRecentMediaOptions options = new InstagramTagRecentMediaOptions
            {
                Count = 10
            };

            // Make the call to the API for the first page
            InstagramRecentMediaResponse response = service.Tags.GetRecentMedia(request.Keyword, 200);
            InstagramSearchTagsResponse response2 = service.Tags.Search(request.Keyword);

            // Add the media to the list
            temp.AddRange(response.Body.Data);

            // No reason to make another request if the first request didn't return any media
            if (temp.Count != 0)
            {

                // Update the options
                options.MaxTagId = response.Body.Pagination.NextMaxId;

                // Make another call to the Instagram API
                response = service.Tags.GetRecentMedia("allblacks", 200, options.MaxTagId);

                // Add the media to the list
                temp.AddRange(response.Body.Data);

            }


            foreach (InstagramMedia media in temp)
            {
                results.Add(new Comment { Description = media.CaptionText, Provider = "Instagram" });

            }

            foreach (InstagramTag tag in response2.Body.Data)
            {
                results.Add(new Comment { Description = tag.Name, Provider = "Instagram" });

            }


            return results;
        }
    }
}
