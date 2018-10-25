using asset_register_api.HomesEngland.Domain;
using asset_register_tests.HomesEngland.Gateway.InMemoryGateway.InMemoryGateway;

namespace asset_register_tests.HomesEngland.Gateway.AssetGateway.AssetGatewaySearchTests.ExactMatches.SchemeID.MultipleResults
{
    public class SearchSchemeIDExactMatchMultipleResultsExampleTwo:InMemoryAssetGatewaySearchTest
    {
        protected override string SearchQuery => "57606864";

        protected override Asset[] AssetsInGateway => new[]
        {
            
            new Asset()
            {
                Address = "Pig", 
                SchemeID = "57606864",
                AccountingYear = "1254"
            },
            new Asset()
            {
                Address = "House", 
                SchemeID = "57606864",
                AccountingYear = "23445"
            },
            new Asset()
            {
                Address = "Hut", 
                SchemeID = "571606864",
                AccountingYear = "23445"
            },
            new Asset()
            {
                Address = "Cow", 
                SchemeID = "57606864",
                AccountingYear = "12123554"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeID = "57606864",
                AccountingYear = "1234"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeID = "571606864",
                AccountingYear = "1234"
            } 
            
        };
        
        protected override Asset[] ExpectedGatewaySearchResults => new[]
        {
            new Asset()
            {
                Address = "Pig", 
                SchemeID = "57606864",
                AccountingYear = "1254"
            },
            new Asset()
            {
                Address = "House", 
                SchemeID = "57606864",
                AccountingYear = "23445"
            },
            new Asset()
            {
                Address = "Cow", 
                SchemeID = "57606864",
                AccountingYear = "12123554"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeID = "57606864",
                AccountingYear = "1234"
            } 
        };
    }
}