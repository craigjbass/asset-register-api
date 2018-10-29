using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asset_register_api.HomesEngland.Domain;
using asset_register_api.HomesEngland.Exception;
using asset_register_api.Boundary;
#pragma warning disable 1998

namespace hear_api.HomesEngland.Gateway
{
    public class InMemoryAssetGateway:IAssetGateway
    {
        readonly List<Asset> _assets = new List<Asset>();
        public async Task<Asset> GetAsset(int id)
        {
            if (id<0 || id> (_assets.Count-1))
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

        public async Task<Asset[]> GetAssets(int[] ids)
        {
            List<Asset> returnList = new List<Asset>();
            for (int i = 0; i < ids.Length; i++)
            {
                await AddAsset(ids, returnList, i);
            }
            return returnList.ToArray();
        }

        public async Task<Asset[]> SearchAssets(string searchQuery)
        {
            return _assets.FindAll(
                asset => QueryFoundInProperties(searchQuery, asset)
            ).ToArray();
        }

        private bool QueryFoundInProperties(string searchQuery, Asset asset)
        {
            return GetPropertyValues(asset).Any(_ => _.ToString().Contains(searchQuery));
        }

        private List<object> GetPropertyValues(Asset asset)
        {
            return asset.GetType().GetProperties().Select(prop => prop.GetValue(asset)).ToList();
        }

        private async Task AddAsset(int[] ids, List<Asset> returnList, int i)
        {
            try
            {
                returnList.Add(await GetAsset(ids[i]));
            }
            catch (NoAssetException)
            {
                Console.WriteLine("Attempted to fetch asset that does not exist");
            }
        }
    }
}