using asset_register_api.HomesEngland.Domain;
using asset_register_tests.HomesEngland.Gateway.InMemoryGateway.InMemoryGateway;

namespace asset_register_tests.HomesEngland.Gateway.AssetGateway.AssetGatewaySearchTests.ExactMatches.Address
{
    public class SearchAddressPartialMatchMultipleResultsExampleTwo:InMemoryAssetGatewaySearchTest
    {
        protected override string SearchQuery => "Clang";

        protected override Asset[] AssetsInGateway => new[]
        {
            new Asset()
            {
                Address = "Cow", 
                SchemeID = "22",
                AccountingYear = "1982"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeID = "12355",
                AccountingYear = "665"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeID = "67",
                AccountingYear = "0"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeID = "12345",
                AccountingYear = "61165"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeID = "2345",
                AccountingYear = "1234"
            } 
        };
        
        protected override Asset[] ExpectedGatewaySearchResults => new[]
        {
            new Asset()
            {
                Address = "Clanger", 
                SchemeID = "12355",
                AccountingYear = "665"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeID = "67",
                AccountingYear = "0"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeID = "12345",
                AccountingYear = "61165"
            },
            new Asset()
            {
                Address = "Clanger", 
                SchemeID = "2345",
                AccountingYear = "1234"
            }  
        };
    }
}