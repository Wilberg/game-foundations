using System;
using System.Collections.Generic;

namespace Core.Services
{
    public class Locator
    {
        public static Locator I { get; } = new Locator();
        
        private readonly Dictionary<Type, IService> _services = new Dictionary<Type, IService>();

        public void Register<T>(IService service)
        {
            _services[typeof(T)] = service;
        }

        public T Get<T>() where T : IService
        {
            if (!_services.TryGetValue(typeof(T), out var service)) return default;
            return (T) service;
        }
    }
}