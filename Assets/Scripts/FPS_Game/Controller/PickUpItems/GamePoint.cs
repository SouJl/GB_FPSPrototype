namespace FPS_Game
{
    public class GamePoint : PickUpBonus
    {
        public int BonusPoints;

        public override void Update()
        {
            base.Update();
        }

        protected override void Interaction(Player player)
        {
            DisplayBonuses.Instance.DisplayGamePoints(BonusPoints);
            IsActive = false;
            gameObject.SetActive(IsActive);
        }
    }
}
