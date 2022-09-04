namespace FPS_Game.MVC
{
    public class InteractableController
    {

        private AbstractInteractModel _model;
        private InteractView _view;

        public InteractableController(AbstractInteractModel model, InteractView view)
        {
            _model = model;
            _view = view;

            _view.Interact += _model.Interaction;
        }
    }
}
