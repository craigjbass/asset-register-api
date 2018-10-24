using asset_register_api.HomesEngland.Domain;

namespace asset_register_tests.HomesEngland.UseCase.SearchAssets.SearchResults.Examples
{
    public class GivenSearchResultsExampleOne:GivenSearchResults
    {
        protected override string SearchQuery => "Dogs";
        protected override Asset[] GatewaySearchResults  => new[]
        {
            new Asset
            {
                Address = "Dogs House",
                AccountingYear = "1999",
                SchemeID = "1334"
            },
            new Asset
            {
                Address = "Dogs are ok",
                AccountingYear = "1982",
                SchemeID = "1337"
            }, 
        };

    }
}