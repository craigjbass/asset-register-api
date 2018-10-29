using System.Linq;
using System.Threading.Tasks;
using asset_register_api.Controllers;
using asset_register_api.HomesEngland.Domain;
using asset_register_api.Boundary.UseCase;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.Controller.GetAssets
{
    [TestFixture]
    public abstract class GetAssetsControllerTest
    {
        protected abstract Asset[] Assets { get; }
        protected abstract int[] AssetIds { get; }

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
            JObject json = JObject.Parse(returnedData.Value);
            foreach (var assetAsJson in json.GetValue("Assets"))
            {
                if(assetAsJson["Address"]!=null)
                {
                    Assert.True(Assets.Any(_=>_.Address == assetAsJson["Address"].ToString()));
                }
                if(assetAsJson["SchemeID"]!=null)
                {
                    Assert.True(Assets.Any(_=>_.SchemeID == assetAsJson["SchemeID"].ToString()));
                }
                if(assetAsJson["AccountingYear"]!=null)
                {
                    Assert.True(Assets.Any(_=>_.AccountingYear == assetAsJson["AccountingYear"].ToString()));
                }
            }
        }

        protected Asset GetAsset(string address, string schemeID, string accountingYear)
        {
            return new Asset()
            {
                Address = address,
                SchemeID = schemeID,
                AccountingYear = accountingYear
            };
        }
    }
}
