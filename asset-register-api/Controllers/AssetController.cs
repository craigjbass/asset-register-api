using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using asset_register_api.Interface.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace asset_register_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IGetAssetUseCase _assetUseCase;
        public AssetController(IGetAssetUseCase useCase)
        {
            _assetUseCase = useCase;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        { 
            Dictionary<string,string> result = await _assetUseCase.Execute(id);
            return ConvertToJson(result);   
        }

        private static string ConvertToJson(Dictionary<string, string> result)
        {
            char quoteMark = Convert.ToChar(34);
            string expectedResult = "{";
            foreach (string key in result.Keys)
            {
                expectedResult += quoteMark + key + quoteMark + ":" + quoteMark + result[key] + quoteMark;
            }
            expectedResult += "}";
            return expectedResult;
        }
    }
}
