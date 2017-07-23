using System;
using NUnit.Framework;
using ServiceStack;
using ServiceStack.Testing;
using Massey.Instagram.ServiceModel;
using Haxiot.Connect.ServiceInterface;

namespace Haxiot.Connect.Tests
{
    [TestFixture]
    public class UnitTests
    {
        private readonly ServiceStackHost appHost;

        public UnitTests()
        {
            appHost = new BasicAppHost(typeof(ConnectService).Assembly)
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
