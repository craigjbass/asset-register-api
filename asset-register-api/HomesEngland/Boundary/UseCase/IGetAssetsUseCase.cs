using System.Collections.Generic;
using System.Threading.Tasks;

namespace asset_register_api.Boundary.UseCase
{
    public interface IGetAssetsUseCase
    {
        Task<Dictionary<string, string>[]> Execute(int[] id);
    }
}