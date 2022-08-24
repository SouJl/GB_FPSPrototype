
using UnityEngine;

namespace FPS_Game 
{
    public abstract class Unit : MonoBehaviour, IRotation
    {
        public Transform transform;
      
        [Header("Health Settings")]
        public float maxHealth = 100f;


        private float _speed = 5f;
        private float _currentHealth;
        private bool _isDead;

        public float CurrentHealth 
        { 
            get => _currentHealth;
            set 
            {
                _currentHealth = Mathf.Clamp(value, 0f, maxHealth);
            }
        }

        public virtual void Awake() 
        {
            TryGetComponent(out transform);
            CurrentHealth = maxHealth;
        }

        public abstract void Move(Vector2 input);

        public abstract void Jump();

        public abstract void Rotate(float x, float y);
    }
}

