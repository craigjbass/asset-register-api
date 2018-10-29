using System.Threading.Tasks;
using asset_register_api.HomesEngland.Domain;
using asset_register_api.Boundary;

namespace asset_register_tests.HomesEngland.Mocks
{
    public class PopulatedInMemoryAssetGateway:IAssetGateway
    {
        private Asset[] assets = new[]
        {
            new Asset()
            {
                Address = "Dog Town",
                SchemeID = "77",
                AccountingYear = "1666"
            },
            new Asset()
            {
                Address = "32 Cat Street",
                SchemeID = "2345",
                AccountingYear = "1235"
            }
        };
        
        public async Task<Asset> GetAsset(int id)
        {
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

        public async Task<Asset[]> SearchAssets(string searchQuery)
        {
            return new Asset[]{assets[1]};
        }
    }
}