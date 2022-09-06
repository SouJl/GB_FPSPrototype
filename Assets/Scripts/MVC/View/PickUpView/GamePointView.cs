using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class GamePointView : PickUpItemView
    {
        [Header("GamePoint Settings")]
        [SerializeField] private float _points;

        public float Points { get => _points; set => _points = value; }
    }
}
