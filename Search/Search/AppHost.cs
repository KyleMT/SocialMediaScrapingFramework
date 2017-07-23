using Funq;
using ServiceStack;
using Massey.ServiceInterface;
using Massey.ServiceModel;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Configuration;
using ServiceStack.Redis;
using ServiceStack.Messaging.Redis;
using ServiceStack.Aws.Sqs;
using Amazon;
using ServiceStack.Messaging;

namespace Massey
{
    //VS.NET Template Info: https://servicestack.net/vs-templates/EmptyAspNet
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("Search", typeof(SearchService).Assembly) { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            //Handle Exceptions occurring in Services:
            this.ServiceExceptionHandlers.Add((httpReq, request, exception) => {
                // Log your exceptions here
                //...
                // Call the default exception handler or prepare your own custom response
                return DtoUtils.CreateErrorResponse(request, exception);
            });

            // Handle Unhandled Exceptions occurring outside of Services
            // E.g. in Request binding or filters:
            //Handle Unhandled Exceptions occurring outside of Services
            //E.g. Exceptions during Request binding or in filters:
            this.UncaughtExceptionHandlers.Add((req, res, operationName, ex) => {
                res.Write("Error: {0}: {1}".Fmt(ex.GetType().Name, ex.Message));
                res.EndRequest(skipHeaders: true);
            });


            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());

            // Handle Multiple Providers here. One per service.
            var dbProvider = ConfigurationManager.AppSettings.Get("DatabaseProvider");
            if (dbProvider == "MySQL")
            {
                var connectionString = ConfigurationManager.ConnectionStrings["Database_MySQL"].ConnectionString;

                var dbFactory = new OrmLiteConnectionFactory(
                    connectionString,
                    ServiceStack.OrmLite.MySqlDialect.Provider);

                container.Register<IDbConnectionFactory>(c => dbFactory);
            }
            else if (dbProvider == "SqlServer")
            {
                var connectionString = ConfigurationManager.ConnectionStrings["Database_SQLServer"].ConnectionString;

                var dbFactory = new OrmLiteConnectionFactory(
                        connectionString,
                        ServiceStack.OrmLite.SqlServerDialect.Provider);

                container.Register<IDbConnectionFactory>(c => dbFactory);
            }



            var queueProvider = ConfigurationManager.AppSettings.Get("QueueProvider");
            if (queueProvider == "SQS")
            {

                var awsAccessKey = ConfigurationManager.AppSettings.Get("AwsAccessKey");
                var awsSecretKey = ConfigurationManager.AppSettings.Get("AwsSecretKey");
                var awsRegionEndpoint = ConfigurationManager.AppSettings.Get("AwsRegionEndpoint");
                var region = RegionEndpoint.GetBySystemName(awsRegionEndpoint);
                var queueUrl = ConfigurationManager.AppSettings.Get("QueueUrl");

                container.Register<IMessageService>(c => new SqsMqServer(
                    awsAccessKey,
                    awsSecretKey,
                    region)
                { DisableBuffering = true });

                var mqServer = container.Resolve<IMessageService>();
                
                mqServer.Start();

            }
            else if (queueProvider == "Redis")
            {
                var redisFactory = new PooledRedisClientManager("localhost:6379");
                container.Register<IRedisClientsManager>(redisFactory);
                var mqHost = new RedisMqServer(redisFactory, retryCount: 2);
                mqHost.Start();
                
            }


        }
    }
}