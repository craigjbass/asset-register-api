using System.Collections.Generic;
using System.Threading.Tasks;
using asset_register_api.HomesEngland.Domain;
using asset_register_api.HomesEngland.Exception;
using asset_register_api.Interface;

namespace hear_api.HomesEngland.Gateway
{
    public class InMemoryAssetGateway:IAssetGateway
    {
        readonly List<Asset> _assets = new List<Asset>();
        public async Task<Asset> GetAsset(int id)
        {
            if (id > _assets.Count - 1 || id < 0 )
            {
                throw new NoAssetException();
            }
            return _assets[id];
        }
        
        public async Task<int> AddAsset(Asset asset)
        {
            _assets.Add(asset);
            return _assets.Count-1;
        }
    }
}