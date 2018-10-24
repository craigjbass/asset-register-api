using NUnit.Framework;

namespace asset_register_tests.HomesEngland.UseCase.GetAsset.WithAsset.Examples
{
    [TestFixture]
    public class GivenAssetExampleOne : GivenAsset
    {
        protected sealed override int AssetId => 3;
        protected sealed override string AssetAddress => "Atticus";
        protected override string AssetSchemeID => "42";
        protected override string AssetAccountingYear => "1982";
    }
}