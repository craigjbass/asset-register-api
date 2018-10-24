using asset_register_api.HomesEngland.Domain;

namespace asset_register_tests.HomesEngland.UseCase.SearchAssets.SearchResults.Examples
{
    public class GivenSearchResultsExampleTwo:GivenSearchResults
    {
        protected override string SearchQuery => "Cats";
        protected override Asset[] GatewaySearchResults  => new[]
        {
            new Asset
            {
                Address = "Cow Hut",
                AccountingYear = "2001",
                SchemeID = "5467"
            },
            new Asset
            {
                Address = "Cow are ok also",
                AccountingYear = "1981",
                SchemeID = "888"
            }, 
            new Asset
            {
                Address = "2 The Street",
                AccountingYear = "2003",
                SchemeID = "13567"
            },
            new Asset
            {
                Address = "Canadian Geese are full of mean",
                AccountingYear = "001",
                SchemeID = "0"
            }
        };
    }
}