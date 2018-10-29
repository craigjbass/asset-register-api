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
    public class SearchAssetsAcceptanceTest
    {
        private AssetRegister _application;
        private IAssetGateway _gateway;
        private ISearchAssetsUseCase _searchAssetsUseCase;

        [SetUp]
        public void SetUp()
        {
            _application = new AssetRegister();
            
            _gateway = _application._AssetGateway();
            _searchAssetsUseCase = _application.GetSearchAssetsUseCase();
        }

        private async Task<int[]> AddAssets(Asset[] assets)
        {
            return await Task.WhenAll(
                assets.Select(async asset => await _gateway.AddAsset(asset)).ToList()
            );
        }

        [Test]
        public async Task SearchAssets()
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
                    AccountingYear = "1983"
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
           
            await AddAssets(assets);

            var searchResult = await _searchAssetsUseCase.Execute("Cat");

            Assert.AreEqual(searchResult[0]["Address"], "Cat House");
            Assert.AreEqual(searchResult[0]["SchemeID"], "6345");
            Assert.AreEqual(searchResult[0]["AccountingYear"], "2229");

            searchResult = await _searchAssetsUseCase.Execute("234");

            Assert.AreEqual(searchResult[0]["Address"], "Bee Hive");
            Assert.AreEqual(searchResult[0]["SchemeID"], "234");
            Assert.AreEqual(searchResult[0]["AccountingYear"], "2018");

            searchResult = await _searchAssetsUseCase.Execute("1983");
            Assert.AreEqual(2, searchResult.Length);
        }
    }
}