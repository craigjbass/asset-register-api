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
    public class GetAssetAcceptanceTest
    {

        [Test]
        public async Task GetExistingAsset()
        {
            Asset asset = new Asset()
            {
                Address = "1, The Pavement, Town",
                SchemeID = "22",
                AccountingYear = "1999"

            };
            // Add Asset
            InMemoryAssetGateway gateway = new InMemoryAssetGateway();
            int id = await gateway.AddAsset(asset);
            
            // Get Asset
            IGetAssetUseCase getAssetUseCase = new GetAsset(gateway);
            Dictionary<string, string> returnedDictionary = getAssetUseCase.Execute(id).Result;
            Assert.True(asset.Address == returnedDictionary["Address"]);
            Assert.True(asset.AccountingYear == returnedDictionary["AccountingYear"]);
            Assert.True(asset.SchemeID == returnedDictionary["SchemeID"]);
        }
    }
}