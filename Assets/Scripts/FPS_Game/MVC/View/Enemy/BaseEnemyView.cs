using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class BaseEnemyView: BaseView, IDamageable
    {
        [Header("Base settings: BaseEnemy")]
        [SerializeField] private FieldOfView _fieldOfView;
        [SerializeField] private GameObject _deadSystem;
        [SerializeField] private float _maxHealth = 100f;
        [SerializeField] private float _defeatPoints = 100f;

        [Header("Movement settings: BaseEnemy")]
        [SerializeField] private float _speed;
        [SerializeField] private UnityEngine.AI.NavMeshAgent _agent;


        [Header("Animation Settings: BaseEnemy")]
        [SerializeField] private Animator _bodyAnimator;
        [SerializeField] private Animator _legsAnimator;

        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
        public float Speed { get => _speed; set => _speed = value; }
        public UnityEngine.AI.NavMeshAgent Agent { get => _agent; set => _agent = value; }
        public FieldOfView FieldOfView { get => _fieldOfView; set => _fieldOfView = value; }
        public Animator LegsAnimator { get => _legsAnimator; set => _legsAnimator = value; }
        public Animator BodyAnimator { get => _bodyAnimator; set => _bodyAnimator = value; }
        public GameObject DeadSystem { get => _deadSystem; set => _deadSystem = value; }
        public float DefeatPoints { get => _defeatPoints; set => _defeatPoints = value; }

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
