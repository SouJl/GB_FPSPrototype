using System;
using UnityEngine;

namespace FPS_Game.MVC
{
    public abstract class BonusModel : AbstractPickUpItemModel
    { 
        private float _bonusValue;
        private Sprite _icon;
        private float _activeTime;

        public float BonusValue { get => _bonusValue; set => _bonusValue = value; }
        public Sprite Icon { get => _icon; set => _icon = value; }
        public float ActiveTime { get => _activeTime; set => _activeTime = value; }

        public abstract BonusType BonusType { get; }

        public BonusModel(BonusView view) : base(view) 
        {
            BonusValue = view.BonusValue;
            Icon = view.Icon;
            ActiveTime = view.ActiveTime;
        }

        public override void Execute()
        {
            base.Execute();
        }

        public override void Interaction(Collider collider)
        {
            throw new NotImplementedException();
        }
    }
}
