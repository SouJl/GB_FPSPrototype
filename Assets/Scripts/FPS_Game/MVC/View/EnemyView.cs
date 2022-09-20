using System;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class EnemyView : BaseView, IDamageable
    {
        [Header("Movement settings")]
        [SerializeField] private float _speed;

        [Header("Health settings: Enemy")]
        [SerializeField] private float _maxHealth = 100f;

        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public float Speed { get => _speed; set => _speed = value; }
        
        public Action<float> TakeDamage;

        public void Damage(float value)
        {
            TakeDamage?.Invoke(value);
        }

        protected override void Awake()
        {
            base.Awake();
        }



    }
}

