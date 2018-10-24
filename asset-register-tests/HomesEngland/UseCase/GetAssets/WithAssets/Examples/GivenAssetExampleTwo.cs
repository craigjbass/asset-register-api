using asset_register_api.HomesEngland.Domain;

namespace asset_register_tests.HomesEngland.UseCase.GetAssets.WithAssets.Examples
{
    public class GivenAssetsExampleTwo:GivenAssets
    {
        protected override int[] AssetsIds => new[] {23, 553, 56, 234,234234,232,2,4,5,6,7};
        protected override Asset[] AssetsToReturn { get; }

        public GivenAssetsExampleTwo()
        {
            AssetsToReturn = CreateAssets(11);
        }
    }
}