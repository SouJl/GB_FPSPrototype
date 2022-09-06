using System;

namespace FPS_Game.MVC
{
    public class InteractableController
    {
        private InteractableController[] _interactController;
        private int _index = -1;

        public int Length => _interactController.Length;
        public object Current => _interactController[_index];
        
        public InteractableController this[int curr]
        {
            get => _interactController[curr];
            private set => _interactController[curr] = value;
        }

        private AbstractInteractModel _model;
        private InteractView _view;

        public InteractableController() { }

        public InteractableController(AbstractInteractModel model, InteractView view)
        {
            _model = model;
            _view = view;
            _view.Interact += _model.Interaction;
        }

        public void AddControllerObject(InteractableController controller)
        {
            if (_interactController == null)
            {
                _interactController = new[] { controller };
                return;
            }

            Array.Resize(ref _interactController, Length + 1);
            _interactController[Length - 1] = controller;
        }
    }
}
