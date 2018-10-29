using System.Threading.Tasks;
using asset_register_api.Boundary;
using asset_register_tests.HomesEngland.Gateway.AssetGateway;
using hear_api.HomesEngland.Gateway;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.Gateway.InMemoryGateway.InMemoryGateway
{
    [TestFixture]
    public abstract class InMemoryAssetGatewaySearchTest:AssetGatewaySearchTest
    {
        protected override IAssetGateway AssetGateway { get; set; }
        [SetUp]
        public override async Task SetUp()
        {
            AssetGateway = new InMemoryAssetGateway();
            await base.SetUp();
        }
    }
}