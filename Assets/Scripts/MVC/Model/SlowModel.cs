using UnityEngine;

namespace FPS_Game.MVC
{
    public class SlowModel: BonusModel
    {
        private float _slowScale;
        public float SlowScale { get => _slowScale; set => _slowScale = value; }

        public override BonusType BonusType => BonusType.SpeedChange;

        public SlowModel(SlowView view) : base(view)
        {
            SlowScale = view.SlowScale;
            BonusValue = SlowScale;
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
