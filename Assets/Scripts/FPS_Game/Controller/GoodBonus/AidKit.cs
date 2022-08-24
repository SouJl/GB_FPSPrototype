using UnityEngine;

namespace FPS_Game 
{
    public class AidKit : Bonus
    {
        [Header("AidKit Settings")]
        public float HealAmount = 30f;

        public override void Update()
        {
            
        }

        protected override void Interaction(Player player)
        {
            player.Heal(HealAmount);
            IsActive = false;
            gameObject.SetActive(IsActive);
        }
    }
}

