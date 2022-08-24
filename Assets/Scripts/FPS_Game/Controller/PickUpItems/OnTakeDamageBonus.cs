namespace FPS_Game
{
    public class OnTakeDamageBonus : Bonus
    {
        public int Damage;

        public override void Awake()
        {
            base.Awake();
        }

        public override void Update() { }

        protected override void Interaction(Player player) { }
    }
}
