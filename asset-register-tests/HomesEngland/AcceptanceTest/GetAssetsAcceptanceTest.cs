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
    public class GetAssetsAcceptanceTest
    {

        [Test]
        public async Task GetExistingAsset()
        {
            InMemoryAssetGateway gateway = new InMemoryAssetGateway();
            string[] addresses = new[]
            {
                "1, The Town, Towny Mc Town Town", 
                "2, The City, Earth", 
                "3, 33, The Street, Moon", 
                "2, The Dog"
            };
            int[] ids = new int[4];
            for (int i = 0; i < addresses.Length; i++)
            {  Asset asset = new Asset()
                {
                    Address= addresses[i]
                };

                // Add Asset
                ids[i] = await gateway.AddAsset(asset);
            }
            
            IGetAssetsUseCase getAssetsUseCase = new GetAssets(gateway);
            Dictionary<string, string>[] returnedValues =  getAssetsUseCase.Execute(ids).Result;

            for (int i = 0; i < returnedValues.Length; i++)
            {
                var assetAsDictionary = returnedValues[i]; 
                Assert.True(addresses[i] == assetAsDictionary["Address"]);
            }
        }
    }
    
}