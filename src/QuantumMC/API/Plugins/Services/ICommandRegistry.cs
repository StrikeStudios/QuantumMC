using System;
using System.Collections.Generic;

namespace QuantumMC.API.Plugins.Services
{
    public sealed class CommandContext
    {
        public string CommandName { get; init; } = string.Empty;
        public IReadOnlyList<string> Args { get; init; } = Array.Empty<string>();
        public string? SenderName { get; init; }   // null = console
        public bool IsConsoleSender => SenderName is null;
    }

    /// <summary>
    /// Lets plugins register custom slash commands.
    /// Inject via [Inject] and call Register in OnLoad.
    /// </summary>
    public interface ICommandRegistry
    {
        /// <summary>
        /// Register a command handler.
        /// </summary>
        /// <param name="name">Command name without the leading slash.</param>
        /// <param name="description">Short description shown in /help.</param>
        /// <param name="handler">Invoked when the command is executed.</param>
        void Register(string name, string description, Action<CommandContext> handler);

        /// <summary>Unregister a previously registered command.</summary>
        void Unregister(string name);
    }
}
