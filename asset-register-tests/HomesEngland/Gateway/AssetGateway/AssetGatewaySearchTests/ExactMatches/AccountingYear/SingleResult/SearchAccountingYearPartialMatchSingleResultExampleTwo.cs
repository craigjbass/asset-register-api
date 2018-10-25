using asset_register_api.HomesEngland.Domain;
using asset_register_tests.HomesEngland.Gateway.InMemoryGateway.InMemoryGateway;

namespace asset_register_tests.HomesEngland.Gateway.AssetGateway.AssetGatewaySearchTests.ExactMatches.AccountingYear
{
    public class SearchAccountingYearPartialMatchSingleResultExampleTwo:InMemoryAssetGatewaySearchTest
    {
        protected override string SearchQuery => "106";

        protected override Asset[] AssetsInGateway => new[]
        {
            new Asset()
            {
                Address = "Duck", 
                SchemeID = "222",
                AccountingYear = "1066"
            },
            new Asset()
            {
                Address = "Cow", 
                SchemeID = "555",
                AccountingYear = "1556"
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
                Address = "Duck", 
                SchemeID = "222",
                AccountingYear = "1066"
            } 
        };
    }
}