using System;
using UnityEngine;

namespace FPS_Game
{
    public sealed class GamePoint : PickUpItem, IPoint
    {
        [Header("GamePoint Settings")]
        [SerializeField]private float _points;

        public float Points
        {
            get => _points;
            set 
            {
                _points = value;
            }
        }

        public event Action<float> AddPoint = delegate(float value) { };

        public override void Execute()
        {
            base.Execute();
        }

        protected override void Interaction(Player player)
        {
            AddPoint?.Invoke(Points);

            IsActive = false;
            gameObject.SetActive(IsActive);
        }
    }
}
