using System;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class InteractView : BaseView
    {
        public event Action<Collider> Interact;

        protected override void Awake()
        {
            base.Awake();
        }

        private void OnTriggerEnter(Collider other)
        {
            Interact?.Invoke(other);
        }
    }
}
