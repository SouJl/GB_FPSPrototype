using System;
using UnityEngine;

namespace FPS_Game.MVC
{
    public sealed class SlowView : BonusView
    {
        [Header("Slow Settings")]
        [Range(0f, 1f)]
        [SerializeField] private float _slowScale = 0.5f;
        public float SlowScale { get => _slowScale; set => _slowScale = value; }
    }
}
