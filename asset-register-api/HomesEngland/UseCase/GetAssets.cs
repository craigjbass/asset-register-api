using System;
using System.Threading.Tasks;
using asset_register_api.HomesEngland.Domain;
using asset_register_api.HomesEngland.Exception;
using asset_register_api.Interface;

namespace asset_register_api.HomesEngland.UseCase
{
    public class GetAssets
    {
        private IAssetGateway Gateway { get; }
        public GetAssets(IAssetGateway gateway)
        {
            Gateway = gateway;
        }

        public async Task<Asset[]> Execute(int[] id)
        {
            return await Gateway.GetAssets(id) ?? throw new NoAssetsException();
        }
    }
}