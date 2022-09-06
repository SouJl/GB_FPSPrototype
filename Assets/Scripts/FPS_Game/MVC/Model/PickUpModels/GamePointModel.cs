using System;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class GamePointModel: AbstractPickUpItemModel
    {
        private float _points;

        public float Points { get => _points; set => _points = value; }

        public event Action<float> AddPoint = delegate (float value) { };

        public GamePointModel(GamePointView view) : base(view)
        {
            Points = view.Points;
        }

        public override void Interaction(Collider collider)
        {
            if(collider.tag == "Player")
            {
                AddPoint?.Invoke(Points);
                IsActive = false;
            }
        }
    }
}
