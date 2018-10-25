using asset_register_api.HomesEngland.Domain;
using asset_register_tests.HomesEngland.Gateway.InMemoryGateway.InMemoryGateway;

namespace asset_register_tests.HomesEngland.Gateway.AssetGateway.AssetGatewaySearchTests.ExactMatches.AccountingYear
{
    public class SearchAccountingYearPartialMatchSingleResultExampleOne:InMemoryAssetGatewaySearchTest
    {
        protected override string SearchQuery => "982";

        protected override Asset[] AssetsInGateway => new[]
        {
            new Asset()
            {
                Address = "Cat", 
                SchemeID = "666",
                AccountingYear = "1982"
            },
            new Asset()
            {
                Address = "Dog", 
                SchemeID = "555",
                AccountingYear = "1556"
            } 
        };
        
        protected override Asset[] ExpectedGatewaySearchResults => new[]
        {
            new Asset()
            {
                Address = "Cat", 
                SchemeID = "666",
                AccountingYear = "1982"
            } 
        };
    }
}