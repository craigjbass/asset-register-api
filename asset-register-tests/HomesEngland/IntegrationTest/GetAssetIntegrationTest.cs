using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using asset_register_tests.HomesEngland.IntegrationTest.StartUp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.IntegrationTest
{
    [TestFixture]
    public class GetAssetIntegrationTes {
        private HttpClient Client { get; set; }
        private TestServer Server { get; set; }

        [SetUp]
        public void SetUp()
        {
            IWebHostBuilder builder = new WebHostBuilder()
                .UseContentRoot(GetRootPath())
                .UseStartup<IntegrationTestStartup>();

            Server = new TestServer(builder);
            Client = Server.CreateClient();
            Client.BaseAddress = new Uri("http://localhost:5000");
        }

        private static string GetRootPath() {
            return Path.GetFullPath (Path.Combine (AppContext.BaseDirectory, @"../../../../asset-register-api/"));
        }
        [TearDown]
        public void TearDown()
        {
            Client.Dispose();
            Server.Dispose();
        }
        
      
   
        [Test]
        public async Task GetAsset()
        {
            using (var response = await Client.GetAsync("/asset/2")) {
                Console.WriteLine("Should 202 but... "+response);
            }
        }
    }
}