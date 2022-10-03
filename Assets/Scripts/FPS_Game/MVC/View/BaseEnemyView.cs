using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class BaseEnemyView: BaseView, IDamageable
    {
        [Header("Base settings")]
        [SerializeField] private FieldOfView _fieldOfView;
        [SerializeField] private GameObject _deadSystem;

        [Header("Movement settings: BaseEnemy")]
        [SerializeField] private float _speed;
        [SerializeField] private UnityEngine.AI.NavMeshAgent _agent;


        [Header("Animation Settings: BaseEnemy")]
        [SerializeField] private Animator _bodyAnimator;
        [SerializeField] private Animator _legsAnimator;

        [Header("Health settings: BaseEnemy")]
        [SerializeField] private float _maxHealth = 100f;

        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public float Speed { get => _speed; set => _speed = value; }
        public UnityEngine.AI.NavMeshAgent Agent { get => _agent; set => _agent = value; }
        public FieldOfView FieldOfView { get => _fieldOfView; set => _fieldOfView = value; }
        public Animator LegsAnimator { get => _legsAnimator; set => _legsAnimator = value; }
        public Animator BodyAnimator { get => _bodyAnimator; set => _bodyAnimator = value; }
        public GameObject DeadSystem { get => _deadSystem; set => _deadSystem = value; }

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
