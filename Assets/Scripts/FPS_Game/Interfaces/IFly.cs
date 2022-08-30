namespace FPS_Game
{
    public interface IFly
    {
        float MinFlyHeight { get;}
        float MaxFlyHeight { get; set; }
        void Fly();
    }
}
