using System;
using System.Linq;
using System.Threading.Tasks;
using asset_register_api.Controllers;
using asset_register_api.HomesEngland.Domain;
using asset_register_api.Interface.UseCase;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.Controller.GetAssets
{
    [TestFixture]
    public abstract class GetAssetsControllerTest
    {
        protected abstract Asset[] Assets { get; }
        protected abstract int[] AssetIds { get; }
        protected abstract string JsonResponse { get; }

        private Mock<IGetAssetsUseCase> _mock;
        private AssetsController _controller;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IGetAssetsUseCase>();
            _mock.Setup(useCase => useCase.Execute(AssetIds)).ReturnsAsync(
                () => Assets.Select(_ => _.ToDictionary()).ToArray());

            _controller = new AssetsController(_mock.Object);
        }

        [Test]
        public async Task GetAssetControllerCallsUseCase()
        {
            await _controller.Get(AssetIds);
            _mock.Verify(mock => mock.Execute(AssetIds), Times.Once());
        }

        [Test]
        public async Task GetAssetControllerReturnsJson()
        {
            ActionResult<string> returnedData = await _controller.Get(AssetIds);
            Console.WriteLine(returnedData.Value + " " + JsonResponse);
            Assert.True(returnedData.Value == JsonResponse);
        }
        
        protected string GetJsonLine(string name)
        {
            return "{" + Convert.ToChar(34) + "Name" + Convert.ToChar(34) + ":" +
                   Convert.ToChar(34) + name + Convert.ToChar(34) + "}";
        }

        protected Asset GetAsset(string name)
        {
            return new Asset()
            {
                Name = name
            };
        }
    }
}
