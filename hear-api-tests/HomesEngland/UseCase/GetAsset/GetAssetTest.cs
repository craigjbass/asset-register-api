using hear_api.HomesEngland.Domain;
using hear_api.HomesEngland.UseCase;
using hear_api.Interface;
using Moq;
using NUnit.Framework;

namespace hear_api_tests.HomesEngland.UseCase
{
    [TestFixture]
    public abstract class GetAssetTest
    {
        protected GetAsset UseCase { get; private set; }
        protected abstract IAssetGateway Gateway { get; }
            
        [SetUp]
        public void SetUp()
        {
            UseCase = new GetAsset(Gateway);
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