using System.Threading.Tasks;
using asset_register_api.HomesEngland.Domain;

namespace asset_register_api.Interface.UseCase
{
    public interface IGetAssetUseCase
    {
        Task<Asset> Execute(int id);
    }
}