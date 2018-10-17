using asset_register_api.Interface;
using Moq;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.UseCase.GetAsset.WithAsset
{
    public abstract class GivenAsset : GetAssetTest
    {
        private Mock<IAssetGateway> Mock { get;}
        protected override IAssetGateway Gateway => Mock.Object;
        
        protected abstract int AssetId { get;  }
        protected abstract string AssetName { get; }

        protected GivenAsset()
        {
            Mock = CreateMockToReturnAssetWithName(AssetId, AssetName);
        }
        
        [SetUp]
        void Setup()
        {
            UseCase.Execute(AssetId);
        }

        [Test]
        public void ItRunsGetAssetIsRunWithId()
        {
            Mock.Verify(mock => mock.GetAsset(AssetId), Times.Once());
        }

        [Test]
        public void ItReturnsFoundAsset()
        {
            Assert.True(UseCase.Execute(AssetId).Name ==AssetName);
        } 
    }
}