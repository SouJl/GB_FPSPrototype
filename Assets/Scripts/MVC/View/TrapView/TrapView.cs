using System;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class TrapView : InteractView
    {
        [Header("Trap Settings")]
        [SerializeField] private float _damage;

        public float Damage { get => _damage; set => _damage = value; }

        protected override void Awake()
        {
            base.Awake();
        }
    }
}
