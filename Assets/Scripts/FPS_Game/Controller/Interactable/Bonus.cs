using UnityEngine;

namespace FPS_Game
{
    public abstract class Bonus: PickUpItem
    {
        [Header("Bonus Settings")]
        public float bonusValue;
        public Sprite icon;
        public float activeTime = 5f;
        public abstract BonusType BonusType { get; }
 

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
