namespace Core.Config
{
    public interface IConfig : IService
    {
        public void Write(string name = "default");
        public void Read(string name = "default");
    }
}