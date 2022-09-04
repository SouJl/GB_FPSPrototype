using UnityEngine;

namespace FPS_Game.MVC
{
    public sealed class HasteModel : BonusModel
    {
        private float _speedUpScaler;
        public float SpeedUpScaler { get => _speedUpScaler; set => _speedUpScaler = value; }

        public override BonusType BonusType => BonusType.SpeedChange;

       
        public HasteModel(HasteView view): base(view)
        {
            SpeedUpScaler = view.SpeedUpScaler;
        }

        public override void Execute()
        {
            base.Execute();
        }

        public override void Interaction(Collider collider)
        {
            base.Interaction(collider);
        }
    }
}
