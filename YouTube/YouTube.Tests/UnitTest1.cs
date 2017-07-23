using System;
using NUnit.Framework;
using ServiceStack;
using ServiceStack.Testing;
using Massey.YouTube.ServiceModel;
using Haxiot.Asset.ServiceInterface;

namespace Haxiot.Asset.Tests
{
    [TestFixture]
    public class UnitTests
    {
        private readonly ServiceStackHost appHost;

        public UnitTests()
        {
            appHost = new BasicAppHost(typeof(AssetService).Assembly)
            {
                ConfigureContainer = container =>
                {
                    //Add your IoC dependencies here
                }
            }
            .Init();
        }

        [OneTimeTearDown]
        public void TestFixtureTearDown()
        {
            appHost.Dispose();
        }

        [Test]
        public void Test_Method1()
        {
           
        }
    }
}
