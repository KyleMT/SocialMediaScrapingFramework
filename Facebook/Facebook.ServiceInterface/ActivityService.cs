using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Haxiot.Activites.ServiceInterface
{
    public partial class ActivityService : Service
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