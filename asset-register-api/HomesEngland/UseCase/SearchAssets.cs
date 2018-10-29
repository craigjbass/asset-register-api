using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asset_register_api.HomesEngland.Domain;
using asset_register_api.Boundary;
using asset_register_api.Boundary.UseCase;

namespace asset_register_api.HomesEngland.UseCase
{
    public class SearchAssets:ISearchAssetsUseCase
    { 
        private IAssetGateway Gateway { get;}

        public SearchAssets(IAssetGateway gateway)
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