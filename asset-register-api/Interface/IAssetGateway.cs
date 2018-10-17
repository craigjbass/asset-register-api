using hear_api.HomesEngland.Domain;

namespace hear_api.Interface
{
    public interface IAssetGateway
    {
        Asset GetAsset(int id);
    }
}