using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using asset_register_api.Interface.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace asset_register_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IGetAssetsUseCase _assetsUseCase;
        public AssetsController(IGetAssetsUseCase useCase)
        {
            _assetsUseCase = useCase;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int[] ids)
        { 
            return GetExpectedResult( await _assetsUseCase.Execute(ids));
        }
        private string GetExpectedResult( Dictionary<string, string>[] results)
        {
            return GetAssetsJsonArray(results);
        }

        private static string GetAssetsJsonArray(Dictionary<string, string>[] results)
        {
            char quoteMark = Convert.ToChar(34);
            string expectedResult = "{" + quoteMark + "Assets" + quoteMark + ":[";
            foreach (var asset in results)
            {
                expectedResult = GetJsonAsset(expectedResult, asset, quoteMark);
            }
            expectedResult = RemoveLastComma(expectedResult) + "]}";
            return expectedResult;
        }

        private static string RemoveLastComma(string expectedResult)
        {
            return expectedResult.Remove(expectedResult.Length - 1);
        }

        private static string GetJsonAsset(string expectedResult, Dictionary<string, string> asset, char quoteMark)
        {
            expectedResult += "{";
            foreach (string key in asset.Keys)
            {
                expectedResult += quoteMark + key + quoteMark + ":" + quoteMark + asset[key] + quoteMark + ",";
            }

            expectedResult = RemoveLastComma(expectedResult) + "},";
            return expectedResult;
        }
    }
}