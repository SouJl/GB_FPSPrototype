using System;

namespace FPS_Game 
{
    public class ListExecuteController 
    {
        private IExecute[] _interactiveObject;

        public int Length 
        {
            get => _interactiveObject.Length;
        }

        public IExecute[] InteractiveObject
        {
            get => _interactiveObject;
            set
            {
                _interactiveObject = value;
            }
        }

        public ListExecuteController() 
        {

        }

        public void AddExecuteObject(IExecute execute) 
        {
            if(_interactiveObject == null) 
            {
                _interactiveObject = new[] { execute };
                return;
            }

            Array.Resize(ref _interactiveObject, Length + 1);
            _interactiveObject[Length - 1] = execute;
        }
    }
}


