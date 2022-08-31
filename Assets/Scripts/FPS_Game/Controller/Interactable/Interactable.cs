using UnityEngine;

namespace FPS_Game
{
    [RequireComponent(typeof(Collider))]
    public abstract class Interactable : MonoBehaviour, IInteract
    {
        private bool _isActive;
        private Collider _collider;

        public bool IsActive 
        {
            get => _isActive;
            set 
            {
                _isActive = value;
                try
                {
                    _collider.enabled = value;
                    _collider.isTrigger = value;
                }
                catch(System.NullReferenceException ex)
                {
                    Debug.Log($"Collider Warning: Source - {this} : {ex}");
                }
            }
        }

        public virtual void Awake() 
        {
            _collider = GetComponent<Collider>();     
        }

        protected abstract void Interaction(Player player);

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                Interaction(other.GetComponent<Player>());
        }
    }
}
