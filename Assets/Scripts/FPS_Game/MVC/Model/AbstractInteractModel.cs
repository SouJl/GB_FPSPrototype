using System;
using UnityEngine;

namespace FPS_Game.MVC
{
    public abstract class AbstractInteractModel : IInteract, IExecute
    {
        private bool _isActive;

        private Transform _transform;
        private Collider _collider;

        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                try
                {
                    _collider.enabled = value;
                    _collider.isTrigger = value;
                }
                catch (NullReferenceException ex)
                {
                    Debug.Log($"Collider Warning: Source - {this} : {ex}");
                }
            }
        }

        public Transform Transform { get => _transform; set => _transform = value; }

        public AbstractInteractModel(BaseView view)
        {
            Transform = view.Transform;
            _collider = view.Collider;
            IsActive = true;
        }

        public abstract void Execute();

        public abstract void Interaction(Collider collider);
    }
}
