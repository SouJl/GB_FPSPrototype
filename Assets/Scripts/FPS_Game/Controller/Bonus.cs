using UnityEngine;

namespace FPS_Game
{
    [RequireComponent(typeof(Collider))]
    public abstract class Bonus : MonoBehaviour, IExecute
    {
        private bool _isActive;
        private Collider _collider;

        public bool IsActive 
        {
            get => _isActive;
            set 
            {
                _isActive = value;
                _collider.enabled = value;
                _collider.isTrigger = value;
            }
        }

        public virtual void Awake() 
        {
            _collider = GetComponent<Collider>();     
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                Interaction(other.GetComponent<Player>());
        }

        protected abstract void Interaction(Player player);

        public abstract void Update();
    }
}
