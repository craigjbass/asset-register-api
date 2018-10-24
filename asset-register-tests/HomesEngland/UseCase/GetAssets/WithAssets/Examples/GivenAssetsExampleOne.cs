using asset_register_api.HomesEngland.Domain;

namespace asset_register_tests.HomesEngland.UseCase.GetAssets.WithAssets.Examples
{
    public class GivenAssetsExampleOne:GivenAssets
    {
        protected override int[] AssetsIds => new[] {1, 4123, 56, 34};
        protected override Asset[] AssetsToReturn { get; }

        public GivenAssetsExampleOne()
        {
            AssetsToReturn = CreateAssets(4);
        }
    }
}