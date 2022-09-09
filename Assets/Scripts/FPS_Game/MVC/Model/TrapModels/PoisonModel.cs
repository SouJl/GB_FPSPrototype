namespace FPS_Game.MVC
{
    public class PoisonModel:TrapModel
    {
        private float _tickTime;
        
        public float TickTime { get => _tickTime; set => _tickTime = value; }
        
        public PoisonModel(PoisonView view) : base(view)
        {
            TickTime = view.TickTime;
        }


    }
}
