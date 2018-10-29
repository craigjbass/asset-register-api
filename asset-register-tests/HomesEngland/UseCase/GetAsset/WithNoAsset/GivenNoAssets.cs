using System.Threading.Tasks;
using asset_register_api.HomesEngland.Exception;
using asset_register_api.Boundary;
using Moq;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.UseCase.GetAsset.WithNoAsset
{
    [TestFixture]
    public class GivenNoAssets : GetAssetTest
    {
        private readonly Mock<IAssetGateway> _mock;
        protected override IAssetGateway Gateway => _mock.Object;
        private int id => 42;
        public GivenNoAssets()
        {
            _mock = new Mock<IAssetGateway>();
            _mock.Setup(gateway => gateway.GetAsset(id)).ReturnsAsync(() => null);
        }

        [Test]
        public async Task ItThrowsNoAssetException()
        {
            Assert.ThrowsAsync<NoAssetException>(async () => await UseCase.Execute(id));
        }
    }
}