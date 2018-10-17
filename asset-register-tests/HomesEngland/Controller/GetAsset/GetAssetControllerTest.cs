using asset_register_api.Controllers;
using asset_register_api.HomesEngland.Domain;
using asset_register_api.Interface.UseCase;
using Moq;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.Controller.GetAsset
{
    [TestFixture]
    public abstract class GetAssetControllerTest
    {
        protected abstract int AssetId { get; }
        protected abstract string AssetName { get; }

        private Mock<IGetAssetUseCase> _mock;
        private AssetController _controller;
        
        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IGetAssetUseCase>();  
            _mock.Setup(useCase => useCase.Execute(AssetId)).ReturnsAsync(() => new Asset()
            {
                Name = AssetName
            });
            
            _controller = new AssetController(_mock.Object);
        }
        
        [Test]
        public void GetAssetControllerCallsUseCase()
        {
            _controller.Get(AssetId);
            _mock.Verify(mock => mock.Execute(AssetId), Times.Once());  
        }
    }
}