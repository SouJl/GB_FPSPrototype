using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS_Game 
{
    public class Health : IExecute
{
        [SerializeField]
        public float MaxHealth = 100f;

        public float CurrentHealth { get; set; }

        public Health() 
        {
            CurrentHealth = MaxHealth;
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}

