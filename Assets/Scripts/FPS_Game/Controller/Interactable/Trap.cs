using System;

namespace FPS_Game
{
    public class Trap : Interactable
    {
        public int Damage;
        
        public event Action<float> TakeDamage =  delegate(float value) { };

        public override void Awake()
        {
            base.Awake();
        }

        protected void DealDamage() 
        {
            TakeDamage?.Invoke(Damage);
        }

        protected override void Interaction(Player player) { }
    }
}
