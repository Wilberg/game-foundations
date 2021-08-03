using System;
using System.Collections.Generic;

namespace Core.Logger
{
    public class ConsoleLogger : IGameLogger
    {
        private readonly List<string> _entries = new List<string>();

        public event Action<string> Logged;
        public event Action<List<string>> Changed;
        
        public void Log(string entry)
        {
            AddEntry($"{DateTime.Now:hh:mm:ss t z}: {entry}");
        }

        public void Clear()
        {
            _entries.Clear();
            Changed?.Invoke(_entries);
        }

        private void AddEntry(string entry)
        {
            _entries.Add(entry);
            Logged?.Invoke(entry);
            Changed?.Invoke(_entries);
        }
    }
}