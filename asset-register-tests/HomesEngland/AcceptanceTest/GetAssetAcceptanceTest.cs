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
                Name = "Scout The Dog"
            };
            // Add Asset
            InMemoryAssetGateway gateway = new InMemoryAssetGateway();
            int id = await gateway.AddAsset(asset);
            
            // Get Asset
            IGetAssetUseCase getAssetUseCase = new GetAsset(gateway);
            Dictionary<string, string> returnedDictionary = getAssetUseCase.Execute(id).Result;
            Assert.True(asset.Name == returnedDictionary["Name"]);
        }
    }
}