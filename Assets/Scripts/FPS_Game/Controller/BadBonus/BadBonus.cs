namespace FPS_Game
{
    public class BadBonus : Bonus
    {
        public int Damage;

        public override void Awake()
        {
            base.Awake();
            //init bonus point, material height
        }

        public override void Update()
        {
            //fly
            //rotate
        }

        protected override void Interaction(Player player) { }
    }
}
