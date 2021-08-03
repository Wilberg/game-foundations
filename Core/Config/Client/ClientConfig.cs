using Core.Logger;

namespace Core.Config.Client
{
    public class ClientConfig : IClientConfig
    {
        public void Write(string name)
        {
        }
        
        public void Read(string name)
        {
            Locator.I.Get<IGameLogger>()?.Log($"Reading client config: {name}");
        }
    }
}