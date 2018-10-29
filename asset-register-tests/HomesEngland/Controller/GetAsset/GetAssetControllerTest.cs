using System.Collections.Generic;
using System.Threading.Tasks;
using asset_register_api.Controllers;
using asset_register_api.HomesEngland.Domain;
using asset_register_api.Boundary.UseCase;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.Controller.GetAsset
{
    using AssetDictionary = Dictionary<string, string>;

    [TestFixture]
    public abstract class GetAssetControllerTest
    {
        protected abstract int AssetId { get; }
        protected abstract string AssetAddress { get; }
        protected abstract string AssetSchemeID { get; }
        protected abstract string AssetAccountingYear { get; }
        private Mock<IGetAssetUseCase> _mock;
        private AssetController _controller;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IGetAssetUseCase>();
            _mock.Setup(useCase => useCase.Execute(AssetId)).ReturnsAsync(() => (new Asset()
            {
                Address = AssetAddress,
                AccountingYear = AssetAccountingYear,
                SchemeID = AssetSchemeID
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
            ActionResult<AssetDictionary> returnedData = await _controller.Get(AssetId);
            AssetDictionary assetAsJson = returnedData.Value;

            if(assetAsJson["Address"]!=null)
            {
                Assert.True(AssetAddress == assetAsJson["Address"]);
            }
            if(assetAsJson["SchemeID"]!=null)
            {
                Assert.True(AssetSchemeID == assetAsJson["SchemeID"]);
            }
            if(assetAsJson["AccountingYear"]!=null)
            {
                Assert.True(AssetAccountingYear == assetAsJson["AccountingYear"]);
            }
        }

    }
}
