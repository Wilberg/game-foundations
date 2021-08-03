using System;
using Core.Logger;
using Core.Services;

namespace Core.Config.Client
{
    [Serializable]
    public class ClientConfig : IClientConfig
    {
        public float sensitivity = 1.0f;
        
        public void Write(string name)
        {
        }
        
        public void Read(string name)
        {
            Locator.I.Get<IGameLogger>()?.Log($"Reading client config: {name}");
        }
    }
}