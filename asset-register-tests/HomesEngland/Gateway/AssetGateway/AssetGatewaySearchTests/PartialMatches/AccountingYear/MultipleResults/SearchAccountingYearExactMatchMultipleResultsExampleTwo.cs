using asset_register_api.HomesEngland.Domain;
using asset_register_tests.HomesEngland.Gateway.InMemoryGateway.InMemoryGateway;

namespace asset_register_tests.HomesEngland.Gateway.AssetGateway.AssetGatewaySearchTests.ExactMatches.AccountingYear
{
    public class SearchAccountingYearExactMatchMultipleResultsExampleTwo:InMemoryAssetGatewaySearchTest
    {
        protected override string SearchQuery => "1066";

        protected override Asset[] AssetsInGateway => new[]
        {
            new Asset()
            {
                Address = "Sheep", 
                SchemeID = "12354",
                AccountingYear = "11235066"
            },
            new Asset()
            {
                Address = "Lion", 
                SchemeID = "134",
                AccountingYear = "11214"
            },
            new Asset()
            {
                Address = "House", 
                SchemeID = "3",
                AccountingYear = "1066"
            },
            new Asset()
            {
                Address = "Cat", 
                SchemeID = "666",
                AccountingYear = "1066"
            },
            new Asset()
            {
                Address = "Dog", 
                SchemeID = "555",
                AccountingYear = "1066"
            },
            new Asset()
            {
                Address = "Pig", 
                SchemeID = "1234",
                AccountingYear = "1066"
            }
        };
        
        protected override Asset[] ExpectedGatewaySearchResults => new[]
        {
            new Asset()
            {
                Address = "Cat", 
                SchemeID = "666",
                AccountingYear = "1066"
            },
            new Asset()
            {
                Address = "Dog", 
                SchemeID = "555",
                AccountingYear = "1066"
            },
            new Asset()
            {
                Address = "Pig", 
                SchemeID = "1234",
                AccountingYear = "1066"
            }
        };
    }
}