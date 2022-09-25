using System;
using UnityEngine;
using UnityEngine.AI;

namespace FPS_Game.MVC
{
    public class EnemyView : BaseView, IDamageable
    {
        [Header("POV settings")]
        [SerializeField] private Transform _pointofView;
        [SerializeField] private float _distance = 100f;

        [Header("Movement settings")]
        [SerializeField] private float _speed;
        [SerializeField] private NavMeshAgent _agent;

        [Header("Health settings: Enemy")]
        [SerializeField] private float _maxHealth = 100f;

        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public float Speed { get => _speed; set => _speed = value; }
        public Transform PointofView { get => _pointofView; set => _pointofView = value; }
        public NavMeshAgent Agent { get => _agent; set => _agent = value; }
        public float Distance { get => _distance; set => _distance = value; }

        public Action<float> TakeDamage;

        public void Damage(float value)
        {
            TakeDamage?.Invoke(value);
        }

        protected override void Awake()
        {
            base.Awake();
        }

        private void OnDrawGizmos()
        {
            Debug.DrawLine(PointofView.position, PointofView.position + PointofView.forward * Distance, Color.red);
        }

    }
}

