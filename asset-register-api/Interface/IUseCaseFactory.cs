namespace asset_register_api.Interface
{
    public interface IUseCaseFactory
    {
        T GetUseCase<T>();
        void AddUseCase<T>(T scout);
    }
}