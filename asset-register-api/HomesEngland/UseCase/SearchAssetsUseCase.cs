using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asset_register_api.HomesEngland.Domain;
using asset_register_api.Interface;
using asset_register_api.Interface.UseCase;

namespace asset_register_api.HomesEngland.UseCase
{
    public class SearchAssetsUseCase:ISearchAssetsUseCase
    { 
        private IAssetGateway Gateway { get;}

        public SearchAssetsUseCase(IAssetGateway gateway)
        {
            Gateway = gateway;
        }

        public async Task<Dictionary<string, string>[]> Execute(string query)
        {
            Asset[] results = await Gateway.SearchAssets(query);
            return results.Select(t => t.ToDictionary()).ToArray();
        }
    }
}