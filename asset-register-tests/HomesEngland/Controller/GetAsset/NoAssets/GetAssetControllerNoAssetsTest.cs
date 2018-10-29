using System.Threading.Tasks;
using asset_register_api.Controllers;
using asset_register_api.HomesEngland.Exception;
using asset_register_api.Boundary.UseCase;
using Moq;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.Controller.GetAsset.NoAssets
{
    [TestFixture]
    public abstract class GetAssetControllerNoAssetsTest
    {
        protected abstract int AssetId { get; }
        private Mock<IGetAssetUseCase> _mock;
        private AssetController _controller;
        
        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IGetAssetUseCase>();
            _mock.Setup(useCase => useCase.Execute(AssetId)).ReturnsAsync(() =>throw new NoAssetException());
            
            _controller = new AssetController(_mock.Object);
        }
        
        [Test]
        public async Task ReturnsEmptyJson()
        {
            var result = await _controller.Get(AssetId);
            Assert.AreEqual(result,"{}");
        }
    }
}