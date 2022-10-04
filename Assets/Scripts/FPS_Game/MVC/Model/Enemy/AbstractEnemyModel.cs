using System;
using UnityEngine;
using UnityEngine.AI;

namespace FPS_Game.MVC
{
    public abstract class AbstractEnemyModel : AbstractUnitModel
    {
        private string _name;
        private NavMeshAgent _agent;
        private Animator _bodyAnimator;
        private Animator _legsAnimator;
        private GameObject _deadSystem;
        private Vector3 _startPosition;
        private Quaternion _startRotation;
        private float _defeatPoints;

        public NavMeshAgent Agent { get => _agent; set => _agent = value; }
        public string Name { get => _name; set => _name = value; }
        public Animator BodyAnimator { get => _bodyAnimator; set => _bodyAnimator = value; }
        public Animator LegsAnimator { get => _legsAnimator; set => _legsAnimator = value; }
        public GameObject DeadSystem { get => _deadSystem; set => _deadSystem = value; }
        public Vector3 StartPosition { get => _startPosition; set => _startPosition = value; }
        public Quaternion StartTotation { get => _startRotation; set => _startRotation = value; }
        public float DefeatPoints { get => _defeatPoints; set => _defeatPoints = value; }
      
        public Action<float> DealDamage;
        
        public Action<float> AddPoints;

        private bool _isActive;

        public bool IsActive
        {
            get => _isActive;
            protected set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    if (!_isActive)
                    {
                        CurrentHealth = 0;
                        Agent.enabled = false;
                        BodyAnimator.ResetTrigger("ExpTrigger");
                        LegsAnimator.ResetTrigger("IsMove");
                        CoroutineProcesses.Instance.SpawnObject(DeadSystem, Transform.position);
                    }
                }
            }
        }


        public AbstractEnemyModel(BaseEnemyView view)
        {
            Transform = view.Transform;

            DeadSystem = view.DeadSystem;
            DefeatPoints = view.DefeatPoints;

            Agent = view.Agent;
            BodyAnimator = view.BodyAnimator;
            LegsAnimator = view.LegsAnimator;

            Name = view.name;
            MaxHealth = view.MaxHealth;
            CurrentHealth = MaxHealth;
            CurrentSpeed = view.Speed;

            Agent.speed = CurrentSpeed;

            StartPosition = Transform.position;
            StartTotation = Transform.rotation;

            view.TakeDamage += TakeDamage;
            IsActive = true;
        }

        public override void Move(Vector3 input)
        {
            if (!IsActive) return;

            HowToMove(input);
            HowToAttack();
        }

        protected abstract void HowToMove(Vector3 input);
        protected abstract void HowToAttack();

        protected virtual void TakeDamage(float value) { }
    }
}
