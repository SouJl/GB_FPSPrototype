using System;
using UnityEngine;

namespace FPS_Game 
{
    public class AidKit : PickUpItem
    {
        [Header("AidKit Settings")]
        public float HealAmount = 30f;

        public event EventHandler<float> Heal;

        public override void Update()
        {
            base.Update();
        }

        protected override void Interaction(Player player)
        {
            Heal?.Invoke(this, HealAmount);
            IsActive = false;
            gameObject.SetActive(IsActive);
        }
    }
}

