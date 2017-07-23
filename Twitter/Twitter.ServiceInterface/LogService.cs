using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using Massey.Twitter.ServiceModel;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Haxiot.Logging.ServiceInterface
{
    public partial class LogService : Service
    {
        public IDbConnectionFactory DbFactory
        {
            get
            {
                return ServiceStackHost.Instance.Container.Resolve<IDbConnectionFactory>();
            }
        }

        private static void CheckTableExistsAndInitialize<T>(System.Data.IDbConnection db)
        {
            if (db.CreateTableIfNotExists<T>())
            {
               
            }
        }
    }
}