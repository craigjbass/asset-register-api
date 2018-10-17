using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using asset_register_api.HomesEngland.Domain;
using asset_register_api.Interface;
using Moq;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.UseCase.GetAssets.WithAssets
{
    [TestFixture]
    public abstract class GivenAssets:GetAssetsTest
    {
        
        private readonly Mock<IAssetGateway> _mock;
        protected abstract int [] AssetsIds { get; }
        protected abstract Asset[] AssetsToReturn { get; }
        protected override IAssetGateway Gateway => _mock.Object;

        protected GivenAssets()
        {
            _mock = new Mock<IAssetGateway>();
            _mock.Setup(gateway => gateway.GetAssets(AssetsIds)).ReturnsAsync(() => AssetsToReturn);
        }
        protected Asset[] CreateAssets(int count)
        {
            List<Asset> returnAssets = new List<Asset>();
            for (int i = 0; i < count; i++)
            {
                Asset asset = new Asset()
                {
                    Name = Guid.NewGuid().ToString()
                };
                returnAssets.Add(asset);
            }
            return returnAssets.ToArray();
        }

        [Test]
        public async Task WillReturnGatewayAssets()
        {
            Asset[] returnedAssets = await UseCase.Execute(AssetsIds);
            for (int i = 0; i < AssetsToReturn.Length; i++)
            {
                Console.WriteLine("Checking "+AssetsToReturn[i].Name);
                foreach (var returnedAsset in returnedAssets)
                {
                    Console.WriteLine(returnedAsset.Name);
                }
                Assert.True(returnedAssets.Any(_ => _.Name == AssetsToReturn[i].Name));
            }
        }
        
        [Test]
        public async Task WillReturnCorrectCountOfAssets()
        {
            Asset[] returnedAssets = await UseCase.Execute(AssetsIds);
            Console.WriteLine("!!!" + returnedAssets.Length);
            foreach (var returnedAsset in returnedAssets)
            {
                Console.WriteLine("____");
                Console.WriteLine(returnedAsset.Name);
            }
            Assert.True(returnedAssets.Length == AssetsIds.Length);
           
        }
        
    }
}