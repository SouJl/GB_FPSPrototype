using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FPS_Game.MVC
{
    public class EnemyModel:AbstractUnitModel
    {
        private string _name;
        private NavMeshAgent _agent;
        
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

        private bool _isActive;
        private Animator _animator;

        public EnemyModel(EnemyView view)
        {
            Transform = view.Transform;
            
            PointofView = view.FieldOfView.PointofView;
            Distance = view.FieldOfView.Distance;
            Angle = view.FieldOfView.Angle;
            TargetMask = view.FieldOfView.TargetMask;
            ObstructionMask = view.FieldOfView.ObstructionMask;

            Agent = view.Agent;
            _animator = view.Animator;

            Name = view.name;
            MaxHealth = view.MaxHealth;
            CurrentHealth = MaxHealth;
            CurrentSpeed = view.Speed;
            view.TakeDamage += TakeDamage;
            _isActive = true;
        }



        public override void Move(Vector3 input)
        {
            if (!_isActive) return;

            if(FieldOfViewCheck(out Vector3 target))
            {
                Agent.SetDestination(target);
                Transform.LookAt(target);
                _animator.SetBool("IsMove", true);
            }
            else 
            {
                Agent.ResetPath();
                _animator.SetBool("IsMove", false);
            }
        }

        public void TakeDamage(float value)
        {
            CurrentHealth -= value;
            if (CurrentHealth <= 0)
            {
                _isActive = false;
                Debug.Log("Enemy Dead");
            }
        }

        private bool FieldOfViewCheck(out Vector3 targetPos)
        {
            targetPos = Vector3.zero;

            Collider[] rangeChecks = Physics.OverlapSphere(PointofView.position, Distance, TargetMask);

            if (rangeChecks.Length == 0) return false;

            targetPos = rangeChecks[0].transform.position;
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
    }
}


