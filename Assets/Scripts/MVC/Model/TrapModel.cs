using System;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class TrapModel:AbstractInteractModel
    {
        private float _damage;

        public float Damage { get => _damage; set => _damage = value; }

        public event Action<float> OnDamage = delegate (float value) { };

        public TrapModel(TrapView view) : base(view)
        {
            Damage = view.Damage;
        }

        public override void Execute() { }

        public override void Interaction(Collider collider)
        {
            if (collider.CompareTag("Player"))
            {
                Debug.Log($"Interact with {this}");
                OnDamage?.Invoke(Damage);
                IsActive = false;
            }
        }
    }
}
