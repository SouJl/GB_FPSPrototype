using System;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class AidKitView : PickUpItemView
    {
        [Header("AidKit Settings")]
        [SerializeField] private float _healAmount = 30f;

        public float HealAmount { get => _healAmount; set => _healAmount = value; }

        protected override void Interaction(Collider other)
        {
            base.Interaction(other);
        }
    }
}
