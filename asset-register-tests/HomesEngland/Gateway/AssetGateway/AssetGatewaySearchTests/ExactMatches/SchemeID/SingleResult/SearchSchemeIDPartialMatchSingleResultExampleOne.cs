using asset_register_api.HomesEngland.Domain;
using asset_register_tests.HomesEngland.Gateway.InMemoryGateway.InMemoryGateway;

namespace asset_register_tests.HomesEngland.Gateway.AssetGateway.AssetGatewaySearchTests.ExactMatches.SchemeID
{
    public class SearchSchemeIDPartialMatchSingleResultExampleOne:InMemoryAssetGatewaySearchTest
    {
        protected override string SearchQuery => "567";

        protected override Asset[] AssetsInGateway => new[]
        {
            new Asset()
            {
                Address = "Pig", 
                SchemeID = "55567",
                AccountingYear = "1254"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeID = "67",
                AccountingYear = "1234"
            } 
        };
        
        protected override Asset[] ExpectedGatewaySearchResults => new[]
        {
            new Asset()
            {
                Address = "Pig", 
                SchemeID = "55567",
                AccountingYear = "1254"
            } 
        };
    }
}