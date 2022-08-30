using System;

namespace FPS_Game
{
    public class Trap : Interactable
    {
        public int Damage;
        
        public event EventHandler<float> TakeDamage;

        public override void Awake()
        {
            base.Awake();
        }

        protected void DealDamage() 
        {
            TakeDamage?.Invoke(this, Damage);
        }

        protected override void Interaction(Player player) { }
    }
}
