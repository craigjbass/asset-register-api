using asset_register_api.Boundary;
using NUnit.Framework;
namespace asset_register_tests.HomesEngland.UseCase.GetAssets
{
    [TestFixture]
    public abstract class GetAssetsTest
    {
        protected asset_register_api.HomesEngland.UseCase.GetAssets UseCase { get; set; }
        protected abstract IAssetGateway Gateway { get; }
            
        [SetUp]
        public void SetUp()
        {
            UseCase = new asset_register_api.HomesEngland.UseCase.GetAssets(Gateway);
        }
    }
}