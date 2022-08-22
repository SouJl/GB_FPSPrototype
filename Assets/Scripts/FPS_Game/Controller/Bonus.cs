using UnityEngine;

namespace FPS_Game
{
    [RequireComponent(typeof(Collider))]
    public abstract class Bonus : MonoBehaviour, IExecute
    {
        private bool _isActive;
        protected Color _color;
        private Renderer _renderer;
        private Collider _collider;


        public bool IsActive 
        {
            get => _isActive;
            set 
            {
                _isActive = value;
                _renderer.enabled = value;
                _collider.enabled = value;
            }
        }

        public virtual void Awake() 
        {
            _collider = GetComponent<Collider>();
            _renderer = GetComponent<Renderer>();

            IsActive = true;
            
            _color = Random.ColorHSV();

            if(_renderer != null)
                _renderer.sharedMaterial.color = _color;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                Interaction();
        }

        protected abstract void Interaction();

        public abstract void Update();
    }
}
