using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FPS_Game.MVC
{
    public class EnemyModel:AbstractUnitModel
    {
        private string _name;
        private Transform _pointofView;
        private NavMeshAgent _agent;
        private float _distance;

        public string Name { get => _name; set => _name = value; }
        public Transform PointofView { get => _pointofView; set => _pointofView = value; }
        public NavMeshAgent Agent { get => _agent; set => _agent = value; }
        public float Distance { get => _distance; set => _distance = value; }

        private bool _isActive;

        public EnemyModel(EnemyView view)
        {
            Transform = view.Transform;
            PointofView = view.PointofView;
            Distance = view.Distance;
            Agent = view.Agent;

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

            if(Physics.Raycast(PointofView.position, PointofView.forward, out RaycastHit hitInfo, Distance))
            {
                if(hitInfo.transform.tag == "Player")
                {
                    Agent.SetDestination(input);

                    Vector3 targetDir = input - Transform.position;
                    Quaternion newDir = Quaternion.LookRotation(targetDir);
                    Transform.rotation = newDir;
                }
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
    }
}


