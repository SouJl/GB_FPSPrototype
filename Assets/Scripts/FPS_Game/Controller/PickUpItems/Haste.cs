using UnityEngine;

namespace FPS_Game 
{
    public class Haste : PickUpBonus
    {
        [Header("Haste Settings")]
        public float SpeedUpScaler = 2f;
        public float activeTime = 5f;

        public override void Update()
        {
            base.Update();
        }

        protected override void Interaction(Player player)
        {
            player.SpeedChange(SpeedUpScaler, activeTime);
            IsActive = false;
            gameObject.SetActive(IsActive);
        }
    }
}

