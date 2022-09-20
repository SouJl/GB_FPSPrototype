using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class EnemyModel:AbstractUnitModel
    {

        public EnemyModel(EnemyView view)
        {
            Transform = view.Transform;

            MaxHealth = view.MaxHealth;
            CurrentHealth = MaxHealth;
            CurrentSpeed = view.Speed;
            view.TakeDamage += TakeDamage;
        }

        public override void Move(Vector2 input)
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage(float value)
        {
            CurrentHealth -= value;
            if (CurrentHealth <= 0) Debug.Log("Enemy Dead");
        }

    }
}


