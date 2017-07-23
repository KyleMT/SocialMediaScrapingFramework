using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using Massey.Instagram.ServiceModel;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Haxiot.Connect.ServiceInterface
{
    public partial class ConnectService : Service
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