using System.Collections.Generic;
using System.Threading.Tasks;
using asset_register_api.HomesEngland.Domain;
using asset_register_api.HomesEngland.UseCase;
using asset_register_api.Interface.UseCase;
using hear_api.HomesEngland.Gateway;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.AcceptanceTest
{
    [TestFixture]
    public class SearchAssetsAcceptanceTest
    {
        [Test]
        public async Task SearchAssets()
        {
             InMemoryAssetGateway gateway = new InMemoryAssetGateway();

             Asset[] assets ={
                new Asset()
                {
                    Address = "1, The Pavement, Town",
                    SchemeID = "22",
                    AccountingYear = "1999"

                },
                new Asset()
                {
                    Address = "2, The Dog, City",
                    SchemeID = "45",
                    AccountingYear = "1983"

                },
                new Asset()
                {
                    Address = "Pavement",
                    SchemeID = "11",
                    AccountingYear = "1983"

                },
                new Asset()
                {
                    Address = "Dog House",
                    SchemeID = "13",
                    AccountingYear = "1927"

                },
                new Asset()
                {
                    Address = "Cat House",
                    SchemeID = "6345",
                    AccountingYear = "2229"

                },
                new Asset()
                {
                    Address = "Bee Hive",
                    SchemeID = "234",
                    AccountingYear = "2018"
                }
            };
        
         List<int> _ids = new List<int>();

      
            _ids = new List<int>();
            for (int i = 0; i < assets.Length; i++)
            {
                _ids.Add(await gateway.AddAsset(assets[i]));
            }
        
        
            ISearchAssetsUseCase searchAssetsUseCase = new SearchAssetsUseCase(gateway);
            Dictionary<string, string>[] searchResult = await searchAssetsUseCase.Execute("Cat");
           
            Assert.AreEqual(searchResult[0]["Address"],"Cat House");
            Assert.AreEqual(searchResult[0]["SchemeID"],"2229");
            Assert.AreEqual(searchResult[0]["AccountingYear"],"2229");
            
            searchResult = await searchAssetsUseCase.Execute("234");
           
            Assert.AreEqual(searchResult[0]["Address"],"Bee Hive");
            Assert.AreEqual(searchResult[0]["SchemeID"],"234");
            Assert.AreEqual(searchResult[0]["AccountingYear"],"2018");
            
            searchResult = await searchAssetsUseCase.Execute("1983");
            Assert.True(searchResult.Length == 2);
        }
    }
}