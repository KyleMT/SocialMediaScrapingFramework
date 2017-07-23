using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using Massey.Flickr.ServiceModel;
using ServiceStack.OrmLite;
using ServiceStack.Data;

namespace Haxiot.Assist.ServiceInterface
{
    public partial class AssistService : Service
    {
        public IDbConnectionFactory DbFactory
        {
            get
            {
                return ServiceStackHost.Instance.Container.Resolve<IDbConnectionFactory>();
            }
        }

  
   }
}
 