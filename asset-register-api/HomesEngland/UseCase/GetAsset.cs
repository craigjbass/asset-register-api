using asset_register_api.HomesEngland.Domain;
using asset_register_api.HomesEngland.Exception;
using asset_register_api.Interface;
using asset_register_api.Interface.UseCase;

namespace asset_register_api.HomesEngland.UseCase
{
    public class GetAsset :IGetAssetUseCase
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