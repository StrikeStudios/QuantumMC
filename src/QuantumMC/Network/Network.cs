using System.Net;
using BedrockProtocol;
using RaknetCS.Network;
using Serilog;

namespace QuantumMC.Network
{
    public class Network
    {
        private readonly RaknetListener _listener;
        private readonly SessionManager _sessionManager;
        private readonly int _port;
        private readonly int _maxPlayers;

        public SessionManager SessionManager => _sessionManager;

        public Network(int port, int maxPlayers)
        {
            _port = port;
            _maxPlayers = maxPlayers;
            _sessionManager = new SessionManager();

            var endpoint = new IPEndPoint(IPAddress.Any, _port);
            _listener = new RaknetListener(endpoint);

            UpdateMotd();

            _listener.SessionConnected += OnSessionConnected;
        }

        public void Start()
        {
            _listener.BeginListener();
        }

        public void Stop()
        {
            _listener.StopListener();
        }

        private void OnSessionConnected(RaknetSession rakSession)
        {
            Log.Information("New RakNet session from {EndPoint}", rakSession.PeerEndPoint);

            var playerSession = new PlayerSession(rakSession, _sessionManager);
            _sessionManager.AddSession(rakSession.PeerEndPoint, playerSession);

            UpdateMotd();
        }

        public void UpdateMotd()
        {
            _listener.Motd = $"MCPE;QuantumMC Server;{Protocol.CurrentProtocol};{Protocol.MinecraftVersion};{_sessionManager.OnlineCount};{_maxPlayers};{DateTimeOffset.Now.ToUnixTimeMilliseconds()};QuantumMC;Survival;1;{_port};{_port + 1};";
        }
    }
}
