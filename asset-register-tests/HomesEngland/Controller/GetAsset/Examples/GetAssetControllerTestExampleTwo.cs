namespace asset_register_tests.HomesEngland.Controller.GetAsset.Examples
{
    public class GetAssetControllerTestExampleTwo:GetAssetControllerTest
    {
        protected override int AssetId => 12345;
        protected override string AssetAddress => "1 High Street, The Moon";
        protected override string AssetSchemeID => "921734759";
        protected override string AssetAccountingYear => "1999";
    }
}