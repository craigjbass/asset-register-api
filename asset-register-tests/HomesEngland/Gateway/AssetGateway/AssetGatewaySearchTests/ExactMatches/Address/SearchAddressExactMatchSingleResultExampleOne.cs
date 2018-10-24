using asset_register_api.HomesEngland.Domain;
using asset_register_tests.HomesEngland.Gateway.InMemoryGateway.InMemoryGateway;

namespace asset_register_tests.HomesEngland.Gateway.AssetGateway.AssetGatewaySearchTests.ExactMatches
{
    public class SearchAddressExactMatchSingleResultExampleOne:InMemoryAssetGatewaySearchTest
    {
        protected override string SearchQuery => "Cow";

        protected override Asset[] AssetsInGateway => new[]
        {
            new Asset()
            {
                Address = "Cow", 
                SchemeID = "22",
                AccountingYear = "1982"
            } 
        };
        
        protected override Asset[] ExpectedGatewaySearchResults => new[]
        {
            new Asset()
            {
                Address = "Cow", 
                SchemeID = "22",
                AccountingYear = "1982"
            } 
        };
    }
}