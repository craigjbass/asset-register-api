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
        public ActionResult<string> Get(int id)
        { 
            _assetUseCase.Execute(id);
            return $"GetAsset use case executed with id: {id}";
        }
    }
}
