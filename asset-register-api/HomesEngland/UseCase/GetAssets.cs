using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asset_register_api.HomesEngland.Domain;
using asset_register_api.HomesEngland.Exception;
using asset_register_api.Boundary;
using asset_register_api.Boundary.UseCase;

namespace asset_register_api.HomesEngland.UseCase
{
    public class GetAssets:IGetAssetsUseCase
    {
        private IAssetGateway Gateway { get; }
        public GetAssets(IAssetGateway gateway)
        {
            Gateway = gateway;
        }

        public async Task<Dictionary<string,string>[]> Execute(int[] id)
        {
            Asset[] assets = await Gateway.GetAssets(id);
            if (assets == null)
            {
                throw new NoAssetException();
            }
            return assets.Select(_ => _.ToDictionary()).ToArray();
        }
    }
}