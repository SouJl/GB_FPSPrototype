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

        public event Action<Bonus> AddBonus = delegate(Bonus bonus) { };

        public override void Execute()
        {
            base.Execute();
        }

        protected override void Interaction(Player player)
        {
            AddBonus?.Invoke(this);
            IsActive = false;
            gameObject.SetActive(IsActive);
        }   
    }
}
