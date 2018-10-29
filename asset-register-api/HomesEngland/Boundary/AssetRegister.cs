using System;
using System.Collections.Generic;
using asset_register_api.HomesEngland.UseCase;
using asset_register_api.Boundary;
using asset_register_api.Boundary.UseCase;
using hear_api.HomesEngland.Gateway;

namespace hear_api.Boundary
{
    using IDependencyReceiver = Action<Type, Func<Object>>; 
    
    public class AssetRegister
    {
        private readonly Dictionary<Type, Func<object>> _dependencies;

        private volatile IAssetGateway _assetGateway;

        public AssetRegister()
        {
            _dependencies = new Dictionary<Type,Func<object>>();
            
            _dependencies.Add(typeof(IAssetGateway), () => _assetGateway);
            
            _dependencies.Add(typeof(IGetAssetUseCase), GetGetAssetUseCase);
            _dependencies.Add(typeof(IGetAssetsUseCase), GetGetAssetsUseCase);
            _dependencies.Add(typeof(ISearchAssetsUseCase), GetSearchAssetsUseCase);
            
            _assetGateway = new InMemoryAssetGateway();
        }

        public IGetAssetUseCase GetGetAssetUseCase() => new GetAsset(_assetGateway);
        public IGetAssetsUseCase GetGetAssetsUseCase() => new GetAssets(_assetGateway);
        public ISearchAssetsUseCase GetSearchAssetsUseCase() => new SearchAssets(_assetGateway);

        [Obsolete("Use a use case directly instead.")]
        public IAssetGateway _AssetGateway() => _assetGateway;

        public void RegisterDependencies(IDependencyReceiver dependencyReceiver)
        {
            foreach(var dependency in _dependencies)
            {
                dependencyReceiver(dependency.Key, dependency.Value);
            }
        }
    }
}