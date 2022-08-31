using System;

namespace FPS_Game
{
    public class NoItemExeception:Exception
    {
        public string SourceName;
        public NoItemExeception(string message, string sourceName) : base(message) 
        {
            SourceName = sourceName;
        }
    }
}
