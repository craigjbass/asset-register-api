using asset_register_api.HomesEngland.Domain;
using asset_register_tests.HomesEngland.Gateway.InMemoryGateway.InMemoryGateway;

namespace asset_register_tests.HomesEngland.Gateway.AssetGateway.AssetGatewaySearchTests.ExactMatches.Address
{
    public class SearchAddressPartialMatchSingleResultExampleTwo:InMemoryAssetGatewaySearchTest
    {
        protected override string SearchQuery => "Do";

        protected override Asset[] AssetsInGateway => new[]
        {
            new Asset()
            {
                Address = "Dog", 
                SchemeID = "999",
                AccountingYear = "1988"
            },
            new Asset()
            {
                Address = "Moomin", 
                SchemeID = "1004",
                AccountingYear = "1998"
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