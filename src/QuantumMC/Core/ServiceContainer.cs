using System;
using System.Collections.Concurrent;
using QuantumMC.API;

namespace QuantumMC.Core
{
    public sealed class ServiceContainer : IServiceContainer
    {
        private readonly ConcurrentDictionary<Type, Lazy<object>> _services = new();

        public void Register<TService>(TService instance) where TService : class
        {
            ArgumentNullException.ThrowIfNull(instance);
            _services[typeof(TService)] = new Lazy<object>(() => instance);
        }

        public void RegisterSingleton<TService>(Func<TService> factory) where TService : class
        {
            ArgumentNullException.ThrowIfNull(factory);
            _services[typeof(TService)] = new Lazy<object>(() => factory()!);
        }

        public TService Resolve<TService>() where TService : class
        {
            if (!_services.TryGetValue(typeof(TService), out var lazy))
                throw new InvalidOperationException(
                    $"Service '{typeof(TService).FullName}' is not registered.");
            return (TService)lazy.Value;
        }

        public TService? TryResolve<TService>() where TService : class
        {
            if (!_services.TryGetValue(typeof(TService), out var lazy)) return null;
            return (TService)lazy.Value;
        }
    }
}
