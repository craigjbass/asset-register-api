using hear_api.HomesEngland.Domain;
using hear_api.HomesEngland.Exception;
using hear_api.Interface;

namespace hear_api.HomesEngland.UseCase
{
    public class GetAsset 
    {
        private IAssetGateway Gateway { get; }
        public GetAsset(IAssetGateway gateway)
        {
            Gateway = gateway;
        }
        public Asset Execute(int id)
        {
            return Gateway.GetAsset(id) ?? throw new NoAssetsException();
        }
    }
}