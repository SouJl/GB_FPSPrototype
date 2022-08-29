namespace FPS_Game
{
    public class Trap : Interactable
    {
        public int Damage;

        public override void Awake()
        {
            base.Awake();
        }

        protected override void Interaction(Player player) { }
    }
}
