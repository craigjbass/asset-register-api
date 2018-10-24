using asset_register_api.HomesEngland.Domain;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.UseCase.SearchAssets.NoSearchResults
{
    public class GivenNoSearchResults: SearchAssetsTest
    {
        protected override string SearchQuery => "Dogs";
        protected override Asset[] GatewaySearchResults  => new Asset[]{};

        [Test]
        public void ItReturnsAnEmptyDictionaryArray()
        {
            Assert.IsNotNull(SearchResults);
            Assert.True(SearchResults.Length == 0);
        }
    }
}