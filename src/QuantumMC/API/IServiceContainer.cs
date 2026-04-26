using System;

namespace QuantumMC.API
{
    /// <summary>
    /// Lightweight service container. The Core layer registers built-in
    /// services; plugins can also register their own services so other plugins
    /// can depend on them.
    /// </summary>
    public interface IServiceContainer
    {
        /// <summary>Register a singleton service.</summary>
        void Register<TService>(TService instance) where TService : class;

        /// <summary>Register a factory that is called once on first resolution.</summary>
        void RegisterSingleton<TService>(Func<TService> factory) where TService : class;

        /// <summary>Resolve a service by type. Throws if not registered.</summary>
        TService Resolve<TService>() where TService : class;

        /// <summary>Resolve a service by type. Returns null if not registered.</summary>
        TService? TryResolve<TService>() where TService : class;
    }
}
