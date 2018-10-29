using System.Collections.Generic;
using System.Threading.Tasks;
using asset_register_api.HomesEngland.Domain;
using asset_register_api.HomesEngland.Exception;
using asset_register_api.Boundary;
using asset_register_api.Boundary.UseCase;

namespace asset_register_api.HomesEngland.UseCase
{
    public class GetAsset :IGetAssetUseCase
    {
        private IAssetGateway Gateway { get; }
        public GetAsset(IAssetGateway gateway)
        {
            Gateway = gateway;
        }
        public async Task<Dictionary<string,string>> Execute(int id)
        {
            Asset asset = await Gateway.GetAsset(id);
            if (asset == null)
            {
                throw new NoAssetException();
            }
            return asset.ToDictionary();
        }
    }
}