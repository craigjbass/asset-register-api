using NUnit.Framework;

namespace asset_register_tests.HomesEngland.UseCase.GetAsset.WithAsset.Examples
{
    [TestFixture]
    public class GivenAssetExampleTwo : GivenAsset
    {
        protected sealed override int AssetId => 42;
        protected sealed override string AssetName => "Scout";
    }
}