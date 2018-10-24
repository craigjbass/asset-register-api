using System;
using System.Threading.Tasks;
using asset_register_api.Controllers;
using asset_register_api.HomesEngland.Domain;
using asset_register_api.Interface.UseCase;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.Controller.GetAsset
{
    [TestFixture]
    public abstract class GetAssetControllerTest
    {
        protected abstract int AssetId { get; }
        protected abstract string AssetName { get; }
        private string JsonResponse  =>  "{" + Convert.ToChar(34) + "Name" + Convert.ToChar(34) + ":" +Convert.ToChar(34)+ AssetName +Convert.ToChar(34)+"}";
        private Mock<IGetAssetUseCase> _mock;
        private AssetController _controller;
        
        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IGetAssetUseCase>();
            _mock.Setup(useCase => useCase.Execute(AssetId)).ReturnsAsync(() => (new Asset()
            {
                Name = AssetName
            }).ToDictionary());
            
            _controller = new AssetController(_mock.Object);
        }
        
        [Test]
        public async Task GetAssetControllerCallsUseCase()
        {
            await _controller.Get(AssetId);
            _mock.Verify(mock => mock.Execute(AssetId), Times.Once());  
        }

        [Test]
        public async Task GetAssetControllerReturnsJson()
        {
            ActionResult<string> returnedData = await _controller.Get(AssetId);
            Assert.True(returnedData.Value == JsonResponse);
        }
    }
}