using hear_api.Interface;
using Moq;
using NUnit.Framework;

namespace hear_api_tests.HomesEngland.UseCase
{
    public abstract class GivenAsset : GetAssetTest
    {
        protected abstract Mock<IAssetGateway> Mock { get; }
        protected override IAssetGateway Gateway => Mock.Object;
        
        protected int AssetID { get; set; }
        protected string AssetName { get; set; }
     
        [Test]
        public void ItRunsGetAssetIsRunWithId()
        {
            UseCase.Execute(AssetID);
        }

        [Test]
        public void ItReturnsFoundAsset()
        {
            Assert.True(UseCase.Execute(AssetID).Name ==AssetName);
        } 
    }
}