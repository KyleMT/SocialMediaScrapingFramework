using ServiceStack;
using ServiceStack.Data;

namespace Massey.ServiceInterface
{
    public partial class SearchService : Service
    {
        public IDbConnectionFactory DbFactory => ServiceStackHost.Instance.Container.Resolve<IDbConnectionFactory>();
    }
}