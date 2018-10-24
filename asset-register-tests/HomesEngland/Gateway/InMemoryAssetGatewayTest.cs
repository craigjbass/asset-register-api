using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asset_register_api.HomesEngland.Domain;
using asset_register_api.HomesEngland.Exception;
using asset_register_api.Interface;
using hear_api.HomesEngland.Gateway;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.Gateway
{
    [TestFixture]
    public class InMemoryAssetGatewayTest
    {
        private IAssetGateway _assetGateway;
        [SetUp]
        public void SetUp()
        {
            _assetGateway = new InMemoryAssetGateway();
        }

        [Test]
        public void InMemoryGatewayHasAddAssetMethod()
        {
            Assert.DoesNotThrowAsync(async ()=>await _assetGateway.AddAsset(new Asset()));
        }
        
        [Test]
        public void GetAssetWithThrowNoAssetExceptionIfIdIsInvalid()
        {
            Assert.ThrowsAsync<NoAssetException>(async () => await _assetGateway.GetAsset(-1));
            Assert.ThrowsAsync<NoAssetException>(async () => await _assetGateway.GetAsset(0));
            Assert.ThrowsAsync<NoAssetException>(async () => await _assetGateway.GetAsset(21));
        }
        
        [Test]
        public async Task AddAssetReturnsAssetId()
        {
            int assetId = await _assetGateway.AddAsset(new Asset());
            Assert.True(assetId == 0);
        }
        
        [Test]
        public async Task AddAssetReturnsAssetFromId()
        {
            string guid = new Guid().ToString();
            Asset assetToAdd = new Asset()
            {
                Name = guid
            };
            int assetId = await _assetGateway.AddAsset(assetToAdd);
            Asset returnedAsset = await _assetGateway.GetAsset(assetId);
            Assert.True((string) returnedAsset.Name == guid);
        }


        [Test]
        public async Task GetItemsFindsCorrectAssetsFromIDs()
        {
            Dictionary<int,Asset> addedAssets = new Dictionary<int, Asset>();
            for (int i = 0; i < 10; i++)
            {
                string guid = new Guid().ToString();
                Asset assetToAdd = new Asset()
                {
                    Name = guid
                };
                int assetId = await _assetGateway.AddAsset(assetToAdd);
                addedAssets.Add(assetId,assetToAdd);
            }

            Asset[] returnedAssets = await _assetGateway.GetAssets(addedAssets.Keys.ToArray());

            for (int i = 0; i < returnedAssets.Length; i++)
            {
                Assert.True(addedAssets.Values.Any(_=> _.Name == returnedAssets[i].Name));
            }
        }
       
        
        [Test]
        public async Task AddAssetReturnsSequentialIDs()
        {
            for (int i = 0; i < 10; i++)
            {
                int assetId = await _assetGateway.AddAsset(new Asset());
                Assert.True(assetId == i);
            }
        }    
        
        [Test]
        public async Task AddAssetReturnsCorrectAssetsSequentially()
        {
            Dictionary<int,string> names = new Dictionary<int, string>();
            for (int i = 0; i < 10; i++)
            {
                string name = new Guid().ToString();
                names.Add(i,name);
                await _assetGateway.AddAsset(new Asset(){Name= name});
            }
            
            for (int i = 0; i < 10; i++)
            {
                Asset asset = await _assetGateway.GetAsset(i);
                Assert.True(asset.Name == names[i]);
            }
        }
    }
}