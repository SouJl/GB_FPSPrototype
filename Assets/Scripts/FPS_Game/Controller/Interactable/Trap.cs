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

        public override void Execute() { }

        protected void DealDamage() 
        {
            TakeDamage?.Invoke(Damage);
        }

        protected override void Interaction(Player player) { }
    }
}
