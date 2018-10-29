using System.Collections.Generic;
using System.Threading.Tasks;
using asset_register_api.HomesEngland.Domain;
using asset_register_api.HomesEngland.UseCase;
using asset_register_api.Boundary;
using asset_register_api.Boundary.UseCase;
using Moq;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.UseCase.SearchAssets
{
    [TestFixture]
    public abstract class SearchAssetsTest
    {
        Mock<IAssetGateway> _mock;
        private ISearchAssetsUseCase UseCase { get; set; }
        protected Dictionary<string, string>[] SearchResults { get; set; }
        
        protected abstract string SearchQuery { get; }
        protected abstract Asset[] GatewaySearchResults { get;}

        [SetUp]
        public async Task SetUp()
        {
            _mock = new Mock<IAssetGateway>();
            _mock.Setup(gateway => gateway.SearchAssets(SearchQuery)).ReturnsAsync(() => GatewaySearchResults);
            UseCase = new asset_register_api.HomesEngland.UseCase.SearchAssets(_mock.Object);
            SearchResults = await UseCase.Execute(SearchQuery);
        }

        [Test]
        public void ItCallsSearchOnGatewayWithSearchString()
        {
            _mock.Verify(mock => mock.SearchAssets(SearchQuery), Times.Once());
        }
    }
}