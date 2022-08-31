using System;

namespace FPS_Game
{
    public interface IPoint
    {
        float Points { get; set; }

        event Action<float> AddPoint;
    }
}
