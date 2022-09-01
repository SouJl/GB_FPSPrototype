using UnityEngine;

namespace FPS_Game 
{
    public sealed class Haste : Bonus
    {
        [Header("Haste Settings")]
        public float speedUpScaler = 2f;

        public override BonusType BonusType => BonusType.SpeedChange;

        public override void Execute()
        {
            base.Execute();
        }

        protected override void Interaction(Player player)
        {
            bonusValue = speedUpScaler;
            base.Interaction(player);
        }
    }
}

