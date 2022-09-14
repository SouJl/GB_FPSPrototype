using System;

namespace FPS_Game
{
    public class PlayerNotFoundExeption : Exception
    {
        public PlayerNotFoundExeption(string message) : base(message) { }
    }
}
