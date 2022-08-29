using UnityEngine;

namespace FPS_Game 
{
    public sealed class Haste : Bonus
    {
        [Header("Haste Settings")]
        public float speedUpScaler = 2f;

        public override BonusType BonusType => BonusType.SpeedChange;

        public override void Update()
        {
            base.Update();
        }

        protected override void Interaction(Player player)
        {
            bonusValue = speedUpScaler;
            player.AddBonus(this);
            IsActive = false;
            gameObject.SetActive(IsActive);
        }
    }
}

