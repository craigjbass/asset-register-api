using System;
using asset_register_api.HomesEngland.Domain;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.Controller.GetAssets.Examples
{
    [TestFixture]
    public class GetAssetsControllerTestExampleTwo:GetAssetsControllerTest
    {
        protected override Asset[] Assets => new[]
        {
            GetAsset("Cats"),
            GetAsset("Cows"), 
            GetAsset("Hats"), 
            GetAsset("Ducks")
        };
        protected override int[] AssetIds  => new[]{99,123,4444,5123};
        protected override string JsonResponse => "{\"Assets\":["
                                                  + GetJsonLine("Cats")+","
                                                  + GetJsonLine("Cows")+","
                                                  + GetJsonLine("Hats")+","
                                                  + GetJsonLine("Ducks")
                                                  + "]}";
    }
    
}