using UnityEngine;

namespace FPS_Game.MVC
{
    public sealed class HasteView: BonusView
    {
        [Header("Haste Settings")]
        [SerializeField] private float speedUpScaler = 2f;

        public float SpeedUpScaler { get => speedUpScaler; set => speedUpScaler = value; }
    }
}
