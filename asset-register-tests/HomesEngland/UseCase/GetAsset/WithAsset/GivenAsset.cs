using System.Collections.Generic;
using System.Threading.Tasks;
using asset_register_api.Boundary;
using Moq;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.UseCase.GetAsset.WithAsset
{
    public abstract class GivenAsset : GetAssetTest
    {
        private Mock<IAssetGateway> Mock { get;}
        protected override IAssetGateway Gateway => Mock.Object;
        
        protected abstract int AssetId { get;  }
        protected abstract string AssetAddress { get; }
        protected abstract string AssetSchemeID { get; }
        protected abstract string AssetAccountingYear { get; }

        protected GivenAsset()
        {
            Mock = CreateMockToReturnAssetWithName(AssetId, AssetAddress, AssetSchemeID,AssetAccountingYear);
        }
        
        [SetUp]
        async Task Setup()
        {
            await UseCase.Execute(AssetId);
        }

        [Test]
        public void ItRunsGetAssetIsRunWithId()
        {
            Mock.Verify(mock => mock.GetAsset(AssetId), Times.Once());
        }

        [Test]
        public async Task ItReturnsFoundAsset()
        {
            Dictionary<string,string> returnedAsset = await UseCase.Execute(AssetId);
            Assert.True(returnedAsset["Address"] == AssetAddress);
            Assert.True(returnedAsset["SchemeID"] == AssetSchemeID);
            Assert.True(returnedAsset["AccountingYear"] ==AssetAccountingYear);
        } 
    }
}