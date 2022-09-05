using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class PoisonModel:TrapModel
    {
        private float _tickTime;
        
        public float TickTime { get => _tickTime; set => _tickTime = value; }

        private bool _isOnPoisen;

        public PoisonModel(PoisonView view) : base(view)
        {
            TickTime = view.TickTime;
            _isOnPoisen = false;
        }

    }
}
