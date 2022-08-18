
using UnityEngine;

namespace FPS_Game 
{
    public abstract class Unit : MonoBehaviour
    {
        public Transform transform;
        public Rigidbody rb;

        private float _speed = 5f;
        private float _health = 100f;
        private bool _isDead;

        public float Health 
        { 
            get => _health;
            set 
            {
                if (value <= 100 && value >= 0)
                {
                    _health = value;
                }
                else
                {
                    _health = 100f;
                }
            }
        }

        public virtual void Awake() 
        {
            TryGetComponent(out transform);
            TryGetComponent(out rb);
        }

        public abstract void Move(Vector2 input);
    }
}

