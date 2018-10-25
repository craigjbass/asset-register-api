using asset_register_api.HomesEngland.Domain;

namespace asset_register_tests.HomesEngland.Controller.SearchAssets.Examples
{
    public class SearchAssetsControllerTestExampleOne:SearchAssetsControllerTest
    {
        protected override Asset[] SearchResults => new Asset[]
        {
            new Asset()
            {
                Address = "Cow Yard",
                AccountingYear = "1998",
                SchemeID = "666"
            }, 
        };
     
    }
}