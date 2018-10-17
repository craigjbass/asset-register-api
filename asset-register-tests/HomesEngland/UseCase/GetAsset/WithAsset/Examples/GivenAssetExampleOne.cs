using hear_api.Interface;
using Moq;
using NUnit.Framework;

namespace hear_api_tests.HomesEngland.UseCase
{
    [TestFixture]
    public class GivenAssetExampleOne : GivenAsset
    {
        protected override Mock<IAssetGateway> Mock { get; }
        
        public GivenAssetExampleOne()
        {
            AssetID = 3;
            AssetName = "Atticus";
            Mock = CreateMockToReturnAssetWithName(AssetID, AssetName);
        }
    }
}