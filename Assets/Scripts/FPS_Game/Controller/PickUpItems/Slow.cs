using UnityEngine;


namespace FPS_Game 
{
    public class Slow : PickUpBonus
    {
        [Range(0f,1f)]
        public float slowScale = 0.5f;
        public float activeTime = 5f;

        public override void Update()
        {
            base.Update();
        }

        protected override void Interaction(Player player)
        {
            player.SpeedChange(slowScale, activeTime);
            IsActive = false;
            gameObject.SetActive(IsActive);
        }
    }
}

