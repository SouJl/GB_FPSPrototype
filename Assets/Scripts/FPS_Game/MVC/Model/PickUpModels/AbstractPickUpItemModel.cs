using UnityEngine;

namespace FPS_Game.MVC
{
    public abstract class AbstractPickUpItemModel : AbstractInteractModel, IFly, IRotate
    {

        private float _rotateSpeed;
        private float _maxFlyHeight;            
        private PickUpItemView _view;
        private string _name;

        public float MinFlyHeight { get; private set; }

        public float MaxFlyHeight { get => _maxFlyHeight; set => _maxFlyHeight = value; }

        public float RotateSpeed { get => _rotateSpeed; set => _rotateSpeed = value; }
        public string Name { get => _name; set => _name = value; }

        private Vector3 _flyStart;
        private Vector3 _flyEnd;

        public AbstractPickUpItemModel(PickUpItemView view) : base(view)
        {
            _view = view;
            RotateSpeed = _view.RotateSpeed;
            MaxFlyHeight = _view.FlyHeight;
            MinFlyHeight = _view.Transform.position.y;
            Name = _view.name;
            _flyStart = new Vector3(Transform.position.x, MinFlyHeight, Transform.position.z);
            _flyEnd = new Vector3(Transform.position.x, MaxFlyHeight, Transform.position.z);
        }

        public override void Execute()
        {
            Fly();
            Rotate();
        }

        public virtual void LoadData(Vector3 position, Quaternion rotation, bool enable)
        {
            _view.gameObject.SetActive(enable);
            IsActive = enable;
            _view.Transform.position = position;        
            _view.Transform.rotation = rotation;
        }

        public void Rotate()
        {
            _view.Transform.RotateAround(_view.Transform.position, Vector3.up, RotateSpeed * Time.deltaTime);
        }

        public void Fly()
        {
            /* float currentHeight = MinFlyHeight;
             if ((MaxFlyHeight - MinFlyHeight) > 0)
                 currentHeight = Mathf.PingPong(Time.time, MaxFlyHeight) + MinFlyHeight;
             _view.Transform.position = new Vector3(_view.Transform.position.x, currentHeight, _view.Transform.position.z);*/

            float t = Mathf.PingPong(Time.time, 1) / 1;
            _view.Transform.position = Vector3.Lerp(_flyStart, _flyEnd, t);
        }
    }
}
