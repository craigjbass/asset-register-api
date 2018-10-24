using asset_register_api.HomesEngland.Domain;
using asset_register_tests.HomesEngland.Gateway.InMemoryGateway.InMemoryGateway;

namespace asset_register_tests.HomesEngland.Gateway.AssetGateway.AssetGatewaySearchTests.ExactMatches
{
    public class SearchAddressExactMatchSingleResultExampleTwo:InMemoryAssetGatewaySearchTest
    {
        protected override string SearchQuery => "Dog";

        protected override Asset[] AssetsInGateway => new[]
        {
            new Asset()
            {
                Address = "Dog", 
                SchemeID = "999",
                AccountingYear = "1988"
            } 
        };
        
        protected override Asset[] ExpectedGatewaySearchResults => new[]
        {
            new Asset()
            {
                Address = "Dog", 
                SchemeID = "999",
                AccountingYear = "1988"
            } 
        };
    }
}