using System.Collections;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class PoisonView : TrapView
    {
        [Header("Poison Settings")]
        [SerializeField] private float _tickTime = 1f;
        
        public float TickTime { get => _tickTime; set => _tickTime = value; }

        private bool _isStay;

        protected override void Awake()
        {
            base.Awake();
            _isStay = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            _isStay = true;
            StartCoroutine(PoisonTick(TickTime, other));
        }

        private void OnTriggerExit(Collider other)
        {
            _isStay = false;
        }

        private IEnumerator PoisonTick(float time, Collider collider)
        {
            while (_isStay)
            {
                Interaction(collider);
                yield return new WaitForSeconds(time);
            }
        }

    }
}
