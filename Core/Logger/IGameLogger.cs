namespace Core.Logger
{
    public interface IGameLogger : IService
    {
        public void Log(string entry);
        public void Clear();
    }
}