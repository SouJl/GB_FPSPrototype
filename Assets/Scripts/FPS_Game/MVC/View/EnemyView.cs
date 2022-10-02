using System;
using UnityEngine;
using UnityEngine.AI;

namespace FPS_Game.MVC
{
    public class EnemyView : BaseView, IDamageable
    {
        [Header("POV settings")]
        [SerializeField] private FieldOfView _fieldOfView;

        [Header("Base settings")]
        [SerializeField] private float _speed;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private float _explosionDelay = 3f;

        [Header("Animation Settings")]
        [SerializeField] private Animator _bodyAnimator;
        [SerializeField] private Animator _legsAnimator;

        [Header("Health settings: Enemy")]
        [SerializeField] private float _maxHealth = 100f;

        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public float Speed { get => _speed; set => _speed = value; }
        public NavMeshAgent Agent { get => _agent; set => _agent = value; }
        public FieldOfView FieldOfView { get => _fieldOfView; set => _fieldOfView = value; }
        public Animator LegsAnimator { get => _legsAnimator; set => _legsAnimator = value; }
        public Animator BodyAnimator { get => _bodyAnimator; set => _bodyAnimator = value; }
        public float ExplosionDelay { get => _explosionDelay; set => _explosionDelay = value; }

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

