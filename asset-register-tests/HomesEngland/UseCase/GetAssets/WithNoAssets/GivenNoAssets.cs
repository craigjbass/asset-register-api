using System.Threading.Tasks;
using asset_register_api.HomesEngland.Exception;
using asset_register_api.Boundary;
using Moq;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.UseCase.GetAssets.WithNoAssets
{
    [TestFixture]
    public class GivenNoAssets : GetAssetsTest
    {
        private readonly Mock<IAssetGateway> _mock;
        protected override IAssetGateway Gateway => _mock.Object;
        public GivenNoAssets()
        {
            _mock = new Mock<IAssetGateway>();
            _mock.Setup(gateway => gateway.GetAssets(new[] {1, 4123, 56, 34})).ReturnsAsync(() => null);
        }

        [Test]
        public async Task ItThrowsNoAssetException()
        {
            Assert.ThrowsAsync<NoAssetException>(async () => await UseCase.Execute(new[] {1, 4123, 56, 34}));
        }
    }
}