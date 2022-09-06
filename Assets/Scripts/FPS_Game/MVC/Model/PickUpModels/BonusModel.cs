using System;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class BonusModel : AbstractPickUpItemModel
    { 
        private float _bonusValue;
        private Sprite _icon;
        private float _activeTime;

        public float BonusValue { get => _bonusValue; set => _bonusValue = value; }
        public Sprite Icon { get => _icon; set => _icon = value; }
        public float ActiveTime { get => _activeTime; set => _activeTime = value; }

        public BonusType Type { get; private set; }
        public event Action<BonusModel> AddBonus = delegate (BonusModel bonus) { };

        public BonusModel(BonusView view) : base(view) 
        {
            Icon = view.Icon;
            ActiveTime = view.ActiveTime;
            Type = view.Type;

            switch (view) 
            {
                default: 
                    {
                        BonusValue = view.BonusValue;
                        break;
                    }
                case HasteView haste: 
                    {
                        BonusValue = haste.SpeedUpScaler;
                        break;
                    }
                case SlowView slow:
                    {
                        BonusValue = slow.SlowScale;
                        break;
                    }
            }
        }

        public override void Execute()
        {
            base.Execute();
        }

        public override void Interaction(Collider collider)
        {
            if (collider.CompareTag("Player")) 
            {
                Debug.Log($"Interact with {this}");
                AddBonus?.Invoke(this);
                IsActive = false;
            }
        }
    }
}
