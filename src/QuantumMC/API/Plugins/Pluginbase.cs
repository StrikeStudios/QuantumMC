using System.Threading.Tasks;
using QuantumMC.API.Plugins.Services;

namespace QuantumMC.API.Plugins
{
    /// <summary>
    /// Base class for all QuantumMC plugins. Inherit from this and decorate
    /// with <see cref="PluginAttribute"/> to be discovered by the plugin loader.
    ///
    /// <example>
    /// <code>
    /// [Plugin(Name = "My Plugin", Version = "1.0.0", Authors = "Dev")]
    /// public class MyPlugin : PluginBase
    /// {
    ///     [Inject] public ILogger Logger { get; set; }
    ///
    ///     public override async Task OnLoad(IServer server)
    ///     {
    ///         Logger.Log($"{Info.Name} loaded!");
    ///     }
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public abstract class PluginBase
    {
        /// <summary>
        /// Metadata resolved from the <see cref="PluginAttribute"/> on this class.
        /// Available as soon as the loader creates the instance.
        /// </summary>
        public PluginInfo Info { get; set; } = default!;

        /// <summary>
        /// Called once when the plugin is first loaded into the server.
        /// Perform one-time setup here (register commands, subscribe to events, etc.).
        /// </summary>
        public virtual Task OnLoad(IServer server) => Task.CompletedTask;

        /// <summary>
        /// Called when the server is fully started and ready to accept players.
        /// </summary>
        public virtual Task OnServerStart(IServer server) => Task.CompletedTask;

        /// <summary>
        /// Called before the server shuts down gracefully.
        /// Flush data, cancel tasks, unsubscribe events here.
        /// </summary>
        public virtual Task OnUnload(IServer server) => Task.CompletedTask;

        /// <summary>
        /// Called when the plugin is reloaded at runtime (e.g. via /reload).
        /// Default implementation calls OnUnload then OnLoad.
        /// </summary>
        public virtual async Task OnReload(IServer server)
        {
            await OnUnload(server);
            await OnLoad(server);
        }
    }
}
