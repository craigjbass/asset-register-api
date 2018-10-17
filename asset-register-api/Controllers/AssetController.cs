using Microsoft.AspNetCore.Mvc;

namespace hear_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return $"Get value {id}";
        }
    }
}
