using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asset_register_api.Controllers;
using asset_register_api.HomesEngland.Domain;
using asset_register_api.Boundary.UseCase;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace asset_register_tests.HomesEngland.Controller.SearchAssets.NoAssets
{
    using AssetDictionary = Dictionary<string, string>;
    using AssetsDictionary = Dictionary<string, Dictionary<string, string>[]>;

    public class SearchAssetsControllerNoAssetsTest
    {
        private Mock<ISearchAssetsUseCase> _mock;
        private SearchController _controller;
        protected Asset[] SearchResults => new Asset[0];
        private string SearchQuery => "Search";

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<ISearchAssetsUseCase>();
            _mock.Setup(useCase => useCase.Execute(SearchQuery)).ReturnsAsync(() => SearchResults.ToList().Select(_=>_.ToDictionary()).ToArray());
            _controller = new SearchController(_mock.Object);
        }

        [Test]
        public async Task ReturnsJsonWithEmptyAssetsArray()
        {
            ActionResult<AssetsDictionary> controllerResult = await  _controller.Get(SearchQuery);
            Assert.AreEqual(
                controllerResult.Value,
                new AssetsDictionary {
                    {"Assets", new AssetDictionary[0]}
                }
            );
        }


    }
}
