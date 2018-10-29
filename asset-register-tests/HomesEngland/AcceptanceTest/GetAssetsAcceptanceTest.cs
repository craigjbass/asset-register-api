using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asset_register_api.HomesEngland.Domain;
using asset_register_api.Boundary;
using asset_register_api.Boundary.UseCase;
using hear_api.Boundary;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.AcceptanceTest
{
    [TestFixture]
    public class GetAssetsAcceptanceTest
    {
        private AssetRegister _application;
        private IAssetGateway _gateway;
        private IGetAssetsUseCase _getAssetsUseCase;

        [SetUp]
        public void SetUp()
        {
            _application = new AssetRegister();
            _gateway = _application._AssetGateway();
            _getAssetsUseCase = _application.GetGetAssetsUseCase();
        }

        private async Task<int[]> AddAssets(Asset[] assets)
        {
            return await Task.WhenAll(
                assets.Select(async asset => await _gateway.AddAsset(asset)).ToList()
            );
        }

        private static List<(Dictionary<string, string>, Asset)> ZipActualWithExpected(
            Dictionary<string, string>[] actualAssets,
            Asset[] assets)
        {
            return actualAssets.Zip(
                assets,
                (actualAsset, expectedAsset) => (actualAsset, expectedAsset)
            ).ToList();
        }

        private void AssertResponseMatchesAsset((Dictionary<string, string>, Asset) testCase)
        {
            (var actual, var expected) = testCase;

            Assert.AreEqual(expected.Address, actual["Address"]);
            Assert.AreEqual(expected.AccountingYear, actual["AccountingYear"]);
            Assert.AreEqual(expected.SchemeID, actual["SchemeID"]);
        }

        [Test]
        public async Task GetExistingAsset()
        {
            Asset[] assets =
            {
                new Asset
                {
                    Address = "1, The Pavement, Town",
                    SchemeID = "22",
                    AccountingYear = "1999"
                },
                new Asset
                {
                    Address = "2, The Dog, City",
                    SchemeID = "45",
                    AccountingYear = "1983"
                },
                new Asset
                {
                    Address = "Pavement",
                    SchemeID = "11",
                    AccountingYear = "1634"
                },
                new Asset
                {
                    Address = "Dog House",
                    SchemeID = "13",
                    AccountingYear = "1927"
                },
                new Asset
                {
                    Address = "Cat House",
                    SchemeID = "6345",
                    AccountingYear = "2229"
                },
                new Asset
                {
                    Address = "Bee Hive",
                    SchemeID = "234",
                    AccountingYear = "2018"
                }
            };

            int[] ids = await AddAssets(assets);

            var actualAssets = _getAssetsUseCase.Execute(ids).Result;

            ZipActualWithExpected(actualAssets, assets)
                .ForEach(AssertResponseMatchesAsset);
        }
    }
}