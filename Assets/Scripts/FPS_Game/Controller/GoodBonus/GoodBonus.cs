namespace FPS_Game
{
    public class GoodBonus : Bonus
    {
        public int BonusPoints;

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

        protected override void Interaction(Player player)
        {
            DisplayBonuses.Instance.DisplayGamePoints(BonusPoints);
            gameObject.SetActive(false);           
        }
    }
}
