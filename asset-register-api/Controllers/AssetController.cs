using System.Collections.Generic;
using System.Threading.Tasks;
using asset_register_api.HomesEngland.Exception;
using asset_register_api.Boundary.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace asset_register_api.Controllers
{
    using Asset = Dictionary<string,string>;

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
        [Produces("application/json")]
        public async Task<ActionResult<Asset>> Get(int id)
        {
            try
            {
                return await _assetUseCase.Execute(id);
            }
            catch (NoAssetException)
            {
                return new Asset();
            }
        }
    }
}
