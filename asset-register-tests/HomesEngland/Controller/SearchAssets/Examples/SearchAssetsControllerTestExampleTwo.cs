using asset_register_api.HomesEngland.Domain;

namespace asset_register_tests.HomesEngland.Controller.SearchAssets.Examples
{
    public class SearchAssetsControllerTestExampleTwo:SearchAssetsControllerTest
    {
        protected override Asset[] SearchResults => new Asset[]
        {
            new Asset()
            {
                Address = "Dog House",
                AccountingYear = "1235",
                SchemeID = "234"
            },
            new Asset()
            {
                Address = "Hall",
                AccountingYear = "1211135",
                SchemeID = "223434"
            },
            new Asset()
            {
                Address = "Cat",
                AccountingYear = "1234677777",
                SchemeID = "1235723424"
            },
        };
     
    }
}