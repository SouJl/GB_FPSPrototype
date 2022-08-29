using UnityEngine;

namespace FPS_Game
{
    public class Bonus: PickUp
    {
        [Header("Bonus Settings")]
        public float bonusValue;
        public Sprite icon;
        public float activeTime = 5f;
        public BonusType bonusType;
        
        public override void Update()
        {
            base.Update();
        }

        protected override void Interaction(Player player)
        {
            player.AddBonus(this);
            IsActive = false;
            gameObject.SetActive(IsActive);
        }

    }
}
