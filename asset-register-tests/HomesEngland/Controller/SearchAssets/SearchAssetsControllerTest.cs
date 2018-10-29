using System.Linq;
using System.Threading.Tasks;
using asset_register_api.Controllers;
using asset_register_api.HomesEngland.Domain;
using asset_register_api.Boundary.UseCase;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.Controller.SearchAssets
{
    public abstract class SearchAssetsControllerTest
    {
        private Mock<ISearchAssetsUseCase> _mock;
        private SearchController _controller;
        protected abstract Asset[] SearchResults { get; }
        private string SearchQuery => "Search";
        
        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<ISearchAssetsUseCase>();
            _mock.Setup(useCase => useCase.Execute(SearchQuery)).ReturnsAsync(() => SearchResults.ToList().Select(_=>_.ToDictionary()).ToArray());
            _controller = new SearchController(_mock.Object);
        }
        
        [Test]
        public async Task SearchAssetControllerCallsUseCase()
        {
            await _controller.Get(SearchQuery);
            _mock.Verify(mock => mock.Execute(SearchQuery), Times.Once());
        }
        
        [Test]
        public async Task GetAssetControllerReturnsJson()
        {
            ActionResult<string> returnedData = await _controller.Get(SearchQuery);
            JObject json = JObject.Parse(returnedData.Value);
            foreach (var assetAsJson in json.GetValue("Assets"))
            {
                if(assetAsJson["Address"]!=null)
                {
                    Assert.True(SearchResults.Any(_=>_.Address == assetAsJson["Address"].ToString()));
                }
                if(assetAsJson["SchemeID"]!=null)
                {
                    Assert.True(SearchResults.Any(_=>_.SchemeID == assetAsJson["SchemeID"].ToString()));
                }
                if(assetAsJson["AccountingYear"]!=null)
                {
                    Assert.True(SearchResults.Any(_=>_.AccountingYear == assetAsJson["AccountingYear"].ToString()));
                }
            }
        }
    }
}