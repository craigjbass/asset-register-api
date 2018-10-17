using NUnit.Framework;

namespace asset_register_tests.HomesEngland.Controller.GetAsset.Examples
{
    [TestFixture]
    public class GetAssetControllerTestExampleOne:GetAssetControllerTest
    {
        protected override int AssetId => 24;
        protected override string AssetName => "Cats";
    }
}