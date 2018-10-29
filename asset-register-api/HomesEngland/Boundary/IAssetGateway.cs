using System.Threading.Tasks;
using asset_register_api.HomesEngland.Domain;

namespace asset_register_api.Boundary
{
    public interface IAssetGateway
    {
        Task<Asset> GetAsset(int id);
        Task<int> AddAsset(Asset asset);
        Task<Asset[]> GetAssets(int[] ids);
        Task<Asset[]> SearchAssets(string searchQuery);
    }
}