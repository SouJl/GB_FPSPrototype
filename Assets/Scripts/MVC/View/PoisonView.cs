using UnityEngine;

namespace FPS_Game.MVC
{
    public class PoisonView : TrapView
    {
        [Header("Poison Settings")]
        [SerializeField] private float _tickTime = 1f;
        
        public float TickTime { get => _tickTime; set => _tickTime = value; }

        private bool _isOnPoisen;

        protected override void Awake()
        {
            base.Awake();
            _isOnPoisen = false;
        }

        protected override void Interaction(Collider other)
        {
            
        }

    }
}
