using UnityEngine;


namespace FPS_Game 
{
    public sealed class Slow : Bonus
    {
        [Header("Slow Settings")]
        [Range(0f,1f)]
        public float slowScale = 0.5f;

        public override BonusType BonusType => BonusType.SpeedChange;

        public override void Execute()
        {
            base.Execute();
        }

        protected override void Interaction(Player player)
        {
            bonusValue = slowScale;
            base.Interaction(player);
        }
    }
}

