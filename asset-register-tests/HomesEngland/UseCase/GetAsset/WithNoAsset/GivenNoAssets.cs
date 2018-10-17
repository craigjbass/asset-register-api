using asset_register_api.HomesEngland.Exception;
using asset_register_api.Interface;
using Moq;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.UseCase.GetAsset.WithNoAsset
{
    [TestFixture]
    public class GivenNoAssets : GetAssetTest
    {
        private  Mock<IAssetGateway> mock;
        protected override IAssetGateway Gateway => mock.Object;
        private int id => 42;
        public GivenNoAssets()
        {
            mock = new Mock<IAssetGateway>();
            mock.Setup(gateway => gateway.GetAsset(id)).Returns(() => null);
        }

        [Test]
        public void ItThrowsNoAssetsException()
        {
            Assert.Throws<NoAssetsException>(() => UseCase.Execute(id));
        }
    }
}