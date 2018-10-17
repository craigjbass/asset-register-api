using asset_register_api.Interface;
using asset_register_api.HomesEngland.Domain;
using Moq;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.UseCase.GetAsset
{
    [TestFixture]
    public abstract class GetAssetTest
    {
        protected asset_register_api.HomesEngland.UseCase.GetAsset UseCase { get; private set; }
        protected abstract IAssetGateway Gateway { get; }
            
        [SetUp]
        public void SetUp()
        {
            UseCase = new asset_register_api.HomesEngland.UseCase.GetAsset(Gateway);
        }
        
        protected Mock<IAssetGateway> CreateMockToReturnAssetWithName(int id, string assetName)
        {
            Mock<IAssetGateway>  mock = new Mock<IAssetGateway>();
            mock.Setup(gateway => gateway.GetAsset(id)).Returns(() => new Asset()
            {
                Name = assetName
            });
            return mock;
        }
    }
}