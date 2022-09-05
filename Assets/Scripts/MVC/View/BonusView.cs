using UnityEngine;

namespace FPS_Game.MVC
{
    public class BonusView: PickUpItemView
    {
        [Header("Bonus Settings")]
        [SerializeField] private float _bonusValue;
        [SerializeField] private Sprite _icon;
        [SerializeField] private float _activeTime = 5f;
        [SerializeField] private BonusType _type;

        public float BonusValue { get => _bonusValue; set => _bonusValue = value; }
        public Sprite Icon { get => _icon; set => _icon = value; }
        public float ActiveTime { get => _activeTime; set => _activeTime = value; }
        public BonusType Type { get => _type; set => _type = value; }
    }
}
