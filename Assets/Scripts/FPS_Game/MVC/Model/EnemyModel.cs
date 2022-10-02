using System;
using UnityEngine;
using UnityEngine.AI;

namespace FPS_Game.MVC
{
    enum MoveState
    {
        None,
        ToTarget,
        ToStart,
    }

    public class EnemyModel:AbstractUnitModel
    {
        /*Base settings*/
        private string _name;
        private NavMeshAgent _agent;
        private float _explosionDealy;

        /*POV*/
        private Transform _pointofView;
        private float _distance;
        private float _angle;
        private LayerMask _targetMask;
        private LayerMask _obstructionMask;


        public string Name { get => _name; set => _name = value; }
        public Transform PointofView { get => _pointofView; set => _pointofView = value; }
        public NavMeshAgent Agent { get => _agent; set => _agent = value; }
        public float Distance { get => _distance; set => _distance = value; }
        public float Angle { get => _angle; set => _angle = value; }
        public LayerMask TargetMask { get => _targetMask; set => _targetMask = value; }
        public LayerMask ObstructionMask { get => _obstructionMask; set => _obstructionMask = value; }
        public float ExplosionDealy { get => _explosionDealy; set => _explosionDealy = value; }
        
        private bool _isActive;
        
        public bool IsActive
        {
            get => _isActive;
            private set
            {
                if(_isActive != value)
                {
                    _isActive = value;
                    if (!_isActive)
                    {
                        CurrentHealth = 0;
                        _bodyAnimator.ResetTrigger("ExpTrigger");
                        _legsAnimator.ResetTrigger("IsMove");
                    }
                }
            }
        }

        public Action<float> DealDamage;
        private Animator _bodyAnimator;
        private Animator _legsAnimator;
        private float _timeDelay;
        
        private Vector3 _startPosition;
        private Quaternion _startTotation;

        public EnemyModel(EnemyView view)
        {
            Transform = view.Transform;
            
            PointofView = view.FieldOfView.PointofView;
            Distance = view.FieldOfView.Distance;
            Angle = view.FieldOfView.Angle;
            TargetMask = view.FieldOfView.TargetMask;
            ObstructionMask = view.FieldOfView.ObstructionMask;

            Agent = view.Agent;
            _bodyAnimator = view.BodyAnimator;
            _legsAnimator = view.LegsAnimator;

            Name = view.name;
            MaxHealth = view.MaxHealth;
            CurrentHealth = MaxHealth;
            CurrentSpeed = view.Speed;
            view.TakeDamage += TakeDamage;
            IsActive = true;

            _startPosition = Transform.position;
            _startTotation = Transform.rotation;

            ExplosionDealy = view.ExplosionDelay;
        }

        public override void Move(Vector3 input)
        {
            if (!IsActive) return;

            HowToMove(input);
            HowToAttack();
        }


        private void HowToMove(Vector3 input) 
        {
            switch (CurrentState(input))
            {
                case MoveState.None:
                    {
                        Agent.ResetPath();

                        if (Quaternion.Angle(Transform.rotation, _startTotation) > 0)
                            Transform.rotation = Quaternion.RotateTowards(Transform.rotation, _startTotation, 2f);
                        else
                            _legsAnimator.SetBool("IsMove", false);
                        break;
                    }
                case MoveState.ToTarget:
                    {
                        Agent.SetDestination(input);
                        Transform.LookAt(input);

                        _legsAnimator.SetBool("IsMove", true);

                        break;
                    }
                case MoveState.ToStart:
                    {
                        Agent.SetDestination(_startPosition);
                        _legsAnimator.SetBool("IsMove", true);
                        break;
                    }
            }

        }

        private void HowToAttack()
        {
            if (OnExplodeCheck())
            {
                if (_timeDelay > ExplosionDealy)
                {
                    _bodyAnimator.SetBool("ExpTrigger", false);
                    DealDamage?.Invoke(50);
                    _timeDelay = 0;

                    IsActive = false;
                }
                else
                {
                    if(!_bodyAnimator.GetAnimatorTransitionInfo(0).IsName("ExpTrigger"))
                        _bodyAnimator.SetBool("ExpTrigger", true);

                    _timeDelay += Time.deltaTime;
                }          
            }
            else
            {
                _bodyAnimator.SetBool("ExpTrigger", false);
                _timeDelay = 0;
            }
        }


        public void TakeDamage(float value)
        {
            CurrentHealth -= value;
            if (CurrentHealth <= 0)
            {
                IsActive = false;
                Debug.Log("Enemy Dead");
            }
        }

        public bool OnExplodeCheck()
        {
            var colliders = Physics.OverlapSphere(Transform.position, Distance / 2);
            foreach (var hit in colliders)
            {
                if (!hit.gameObject.CompareTag("Player")) continue;

                return true;
            }

            return false;
        }


        private bool FieldOfViewCheck(Vector3 targetPos)
        {
            if (Vector3.Distance(Transform.position, targetPos) > Distance) return false;
            
            Vector3 directionToTarget = (targetPos - PointofView.position).normalized;

            if (Vector3.Angle(PointofView.forward, directionToTarget) < Angle / 2)
            {
                float distanceToTarget = Vector3.Distance(PointofView.position, targetPos);

                if (!Physics.Raycast(PointofView.position, directionToTarget, distanceToTarget, ObstructionMask))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        private MoveState CurrentState(Vector3 target)
        {
            if (FieldOfViewCheck(target)) return MoveState.ToTarget;
            
            if ((Transform.position -  _startPosition).sqrMagnitude > 0.1f) return MoveState.ToStart;
            
            return MoveState.None;
        }
    }
}


