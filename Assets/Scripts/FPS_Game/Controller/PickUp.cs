using UnityEngine;

namespace  FPS_Game
{
    [RequireComponent(typeof(Collider))]
    public abstract class PickUp : MonoBehaviour, IInteract, IExecute
    {
        [Header("PickUp Settings")]
        public float rotateSpeed;
        public float flyHeight;


        private Collider _collider;
        private bool _isActive;

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

        public virtual void Update()
        {
            transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
        }

        protected virtual void Interaction(Player player) { }


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                Interaction(other.GetComponent<Player>());
        }
    }
}
