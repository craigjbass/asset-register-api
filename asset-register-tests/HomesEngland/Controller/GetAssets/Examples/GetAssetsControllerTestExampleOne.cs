using System;
using asset_register_api.HomesEngland.Domain;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.Controller.GetAssets.Examples
{
    [TestFixture]
    public class GetAssetsControllerTestExampleOne:GetAssetsControllerTest
    {
        protected override Asset[] Assets => new[]{
            GetAsset("Scout The Dog"), 
            GetAsset("Don At Mad Tech") };
        protected override int[] AssetIds  => new[]{1,2};
        protected override string JsonResponse => "{\"Assets\":["
                                                  + GetJsonLine("Scout The Dog")+","
                                                  + GetJsonLine("Don At Mad Tech")
                                                  + "]}";
    }
}