namespace FPS_Game
{
    public interface IPickUp
    {
        float RotateSpeed { get; set; }
        float FlyHeight { get; set; }

        void MoveBehavior();
    }
}
