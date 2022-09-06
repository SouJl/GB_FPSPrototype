using System.Collections;
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

        private void OnTriggerEnter(Collider other)
        {
            _isOnPoisen = true;
            StartCoroutine(PoisonTick(TickTime, other));
        }

        private void OnTriggerExit(Collider other)
        {
            _isOnPoisen = false;
        }

        private IEnumerator PoisonTick(float time, Collider collider)
        {
            while (_isOnPoisen)
            {
                Interaction(collider);
                yield return new WaitForSeconds(time);
            }
        }

    }
}
