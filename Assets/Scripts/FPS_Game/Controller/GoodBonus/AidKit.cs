using UnityEngine;

namespace FPS_Game 
{
    public class AidKit : GoodBonus
    {
        [Header("AidKit Settings")]
        public float HealAmount = 30f;

        public override void Update()
        {
            base.Update();
        }

        protected override void Interaction(Player player)
        {
            player.Heal(HealAmount);
            IsActive = false;
            gameObject.SetActive(IsActive);
        }
    }
}

