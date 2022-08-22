namespace FPS_Game
{
    public class GoodBonus : Bonus
    {
        public int BonusPoints;

        private DisplayBonuses _displayBonuses;

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

        protected override void Interaction()
        {
            DisplayBonuses.Instance.DisplayGamePoints(BonusPoints);
            this.gameObject.SetActive(false);           
        }
    }
}
