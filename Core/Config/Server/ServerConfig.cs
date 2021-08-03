using System;
using Core.Logger;
using Core.Services;

namespace Core.Config.Server
{
    [Serializable]
    public class ServerConfig : IServerConfig
    {
        public void Write(string name = "default")
        {
        }

        public void Read(string name = "default")
        {
            Locator.I.Get<IGameLogger>()?.Log($"Reading server config: {name}");
        }
    }
}