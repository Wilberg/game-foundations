using Core.Config.Client;
using Core.Config.Server;
using Core.Logger;
using Core.Services;
using UnityEngine;

namespace Core
{
    public static class Game
    {
        private static IGameLogger _logger;
        private static IClientConfig _clientConfig;
        private static IServerConfig _serverConfig;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Start()
        {
            #if UNITY_EDITOR
                RegisterDebugServices();
            #else
                RegisterServices();
            #endif
            
            ReadConfigs();
        }

        private static void RegisterDebugServices()
        {
            _logger = new UnityLogger();
            _clientConfig = new ClientConfig();
            _serverConfig = new ServerConfig();
            
            Locator.I.Register<IGameLogger>(_logger);
            Locator.I.Register<IClientConfig>(_clientConfig);
            Locator.I.Register<IServerConfig>(_serverConfig);
            
            _logger.Log("Services registered!");
        }

        private static void RegisterServices()
        {
            _logger = new UnityLogger();
            _clientConfig = new ClientConfig();
            _serverConfig = new ServerConfig();
            
            Locator.I.Register<IGameLogger>(_logger);
            Locator.I.Register<IClientConfig>(_clientConfig);
            Locator.I.Register<IServerConfig>(_serverConfig);
            
            _logger.Log("Services registered!");
        }
        
        private static void ReadConfigs()
        {
            _clientConfig.Read();
            _logger.Log("Successfully read client config!");
            
            _serverConfig.Read();
            _logger.Log("Successfully read server config!");
        }
    }
}