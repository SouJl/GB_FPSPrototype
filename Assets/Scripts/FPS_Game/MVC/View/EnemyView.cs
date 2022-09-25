using System;
using UnityEngine;
using UnityEngine.AI;

namespace FPS_Game.MVC
{
    public class EnemyView : BaseView, IDamageable
    {
        [Header("POV settings")]
        [SerializeField] private FieldOfView _fieldOfView;

        [Header("Movement settings")]
        [SerializeField] private float _speed;
        [SerializeField] private NavMeshAgent _agent;

        [Header("Health settings: Enemy")]
        [SerializeField] private float _maxHealth = 100f;

        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public float Speed { get => _speed; set => _speed = value; }
        public NavMeshAgent Agent { get => _agent; set => _agent = value; }
        public FieldOfView FieldOfView { get => _fieldOfView; set => _fieldOfView = value; }

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

        }

        private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
        {
            angleInDegrees += eulerY;

            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }

    }
}

