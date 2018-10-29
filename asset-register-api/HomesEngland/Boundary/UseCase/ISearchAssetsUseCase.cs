using System.Collections.Generic;
using System.Threading.Tasks;

namespace asset_register_api.Boundary.UseCase
{
    public interface ISearchAssetsUseCase
    {
        Task<Dictionary<string, string>[]> Execute(string query);
    }
}