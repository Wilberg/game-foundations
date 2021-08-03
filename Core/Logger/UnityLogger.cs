using UnityEngine;

namespace Core.Logger
{
    public class UnityLogger : IGameLogger
    {
        public void Log(string entry)
        {
            Debug.Log(entry);
        }

        public void Clear()
        {
            Debug.ClearDeveloperConsole();
        }
    }
}