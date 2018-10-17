using System;
using System.Collections.Generic;
using asset_register_api.HomesEngland.Exception;
using asset_register_api.Interface;

namespace asset_register_api.Factory
{
    public class UseCaseFactory:IUseCaseFactory
    {
        public UseCaseFactory()
        {
            Console.WriteLine(":(");
        }
        readonly Dictionary<Type,object> _useCases = new Dictionary<Type, object>();
        
        public T GetUseCase <T> ()
        {
            if(!_useCases.ContainsKey(typeof(T)))
            {
                throw new NoUseCaseException();
            }

            return (T) _useCases[typeof(T)];
        }

        public void AddUseCase<T>(T useCase)
        {
            _useCases.Add(typeof(T), useCase );
        }
    }
}