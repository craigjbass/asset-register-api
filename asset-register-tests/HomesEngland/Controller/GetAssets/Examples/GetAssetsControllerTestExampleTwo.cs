using System;
using asset_register_api.HomesEngland.Domain;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.Controller.GetAssets.Examples
{
    [TestFixture]
    public class GetAssetsControllerTestExampleTwo:GetAssetsControllerTest
    {
        protected override Asset[] Assets => new[]{
            GetAsset("1, Dog Road, Horse Town", "412","1066"), 
            GetAsset("2, Cat Road, Dog Town", "412213","1166"),
            GetAsset("3,4,5 Snail Road, Cow Town", "23424","1266"), 
            GetAsset("6, Duck Road, Duck Town", "234234","1366")
        };
        protected override int[] AssetIds  => new[]{1,2};
    }
}