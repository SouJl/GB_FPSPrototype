using UnityEngine;

namespace FPS_Game.MVC
{
    public abstract class AbstractUnitModel
    {
        private Transform _transform;
        private float _maxHealth;
        private float _currentSpeed;
        private float _currentHealth;
        
        public Transform Transform { get => _transform; set => _transform = value; }

        public float CurrentSpeed { get => _currentSpeed; set => _currentSpeed = value; }

        public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
          
        public float CurrentHealth 
        { 
            get => _currentHealth; 
            set => _currentHealth = Mathf.Clamp(value, 0f, MaxHealth);
        }
        
        public abstract void Move(Vector3 input);
    }
}
