using System;
using UnityEngine;

namespace FPS_Game 
{
    public class AidKit : PickUpItem
    {
        [Header("AidKit Settings")]
        public float HealAmount = 30f;

        public event Action<float> Heal = delegate(float value) { };

        public override void Execute()
        {
            base.Execute();
        }

        protected override void Interaction(Player player)
        {
            Heal?.Invoke(HealAmount);
            IsActive = false;
            gameObject.SetActive(IsActive);
        }
    }
}

