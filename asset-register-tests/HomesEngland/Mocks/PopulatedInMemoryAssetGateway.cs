using System;
using System.Threading.Tasks;
using asset_register_api.HomesEngland.Domain;
using asset_register_api.Interface;

namespace asset_register_tests.HomesEngland.Mocks
{
    public class PopulatedInMemoryAssetGateway:IAssetGateway
    {
        private Asset[] assets = new[]
        {
            new Asset()
            {
                Name = "Dog"
            },
            new Asset()
            {
                Name = "Cat"
            }
        };
        
        public async Task<Asset> GetAsset(int id)
        {
            Console.WriteLine("PopulatedInMemoryAssetGateway.GetAsset ");
            return assets[0];
        }

        public async Task<int> AddAsset(Asset asset)
        {
            return 0;
        }

        public async Task<Asset[]> GetAssets(int[] ids)
        {
            
            return assets;
        }
    }
}