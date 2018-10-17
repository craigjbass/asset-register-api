using asset_register_api.HomesEngland.Domain;

namespace asset_register_api.Interface
{
    public interface IAssetGateway
    {
        Asset GetAsset(int id);
    }
}