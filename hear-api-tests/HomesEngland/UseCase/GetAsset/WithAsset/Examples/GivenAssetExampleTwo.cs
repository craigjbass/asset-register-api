using hear_api.Interface;
using Moq;
using NUnit.Framework;

namespace hear_api_tests.HomesEngland.UseCase
{
    [TestFixture]
    public class GivenAssetExampleTwo : GivenAsset
    {
        protected override Mock<IAssetGateway> Mock { get; }
        
        public GivenAssetExampleTwo()
        {
            AssetID = 42;
            AssetName = "Robin";
            Mock = CreateMockToReturnAssetWithName(AssetID, AssetName);
        }
    }
}