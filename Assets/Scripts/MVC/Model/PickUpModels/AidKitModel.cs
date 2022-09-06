using System;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class AidKitModel:AbstractPickUpItemModel
    {
        private float _healAmount;

        public float HealAmount { get => _healAmount; set => _healAmount = value; }

        public event Action<float> Heal = delegate (float value) { };

        public AidKitModel(AidKitView view) : base(view)
        {
            HealAmount = view.HealAmount;
        }

        public override void Interaction(Collider collider)
        {
            if (collider.CompareTag("Player"))
            {
                Debug.Log($"Interact with {this}");
                Heal?.Invoke(HealAmount);
                IsActive = false;
            }
        }
    }
}
