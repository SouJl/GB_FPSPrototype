using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class EnemyModel:AbstractUnitModel
    {
        private string _name;
        
        public string Name { get => _name; set => _name = value; }

        public EnemyModel(EnemyView view)
        {
            Transform = view.Transform;

            Name = view.name;
            MaxHealth = view.MaxHealth;
            CurrentHealth = MaxHealth;
            CurrentSpeed = view.Speed;
            view.TakeDamage += TakeDamage;
        }



        public override void Move(Vector3 input)
        {
            
        }

        public void TakeDamage(float value)
        {
            CurrentHealth -= value;
            if (CurrentHealth <= 0) Debug.Log("Enemy Dead");
        }
    }
}


