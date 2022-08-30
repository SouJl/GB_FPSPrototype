using System;
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

        public event EventHandler<Bonus> AddBonus;

        public override void Update()
        {
            base.Update();
        }

        protected override void Interaction(Player player)
        {
            AddBonus?.Invoke(this, this);
            IsActive = false;
            gameObject.SetActive(IsActive);
        }   
    }
}
