using System.Collections;
using UnityEngine;

namespace FPS_Game 
{
    public class Poison : OnTakeDamageBonus
    {
        [Header("Settings: Poison")]
        [SerializeField] private float _tickTime = 1f;

        private bool _isOnPoisen;

        private void Start()
        {
            _isOnPoisen = false;
        }

        public override void Update()
        {

        }

        private IEnumerator PoisonTick(float time, Player player)
        {
            while (_isOnPoisen) 
            {
                player.TakeDamage(Damage);
                DisplayBonuses.Instance.DisplayPlayerDamage(Damage);
                yield return new WaitForSeconds(time);
            }
        }
        
        protected override void Interaction(Player player)
        {
            base.Interaction(player);
            _isOnPoisen = true;
            StartCoroutine(PoisonTick(_tickTime, player));
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.tag == "Player") 
            {
                _isOnPoisen = false;
            }
        }
    }
}

