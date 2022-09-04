using UnityEngine;

namespace FPS_Game.MVC
{
    public abstract class AbstractPickUpItemModel : AbstractInteractModel, IFly, IRotate
    {

        private float _rotateSpeed;
        private float _maxFlyHeight;     
        private PickUpItemView _view;

        public float MinFlyHeight { get; private set; }

        public float MaxFlyHeight { get => _maxFlyHeight; set => _maxFlyHeight = value; }

        public float RotateSpeed { get => _rotateSpeed; set => _rotateSpeed = value; }


        public AbstractPickUpItemModel(PickUpItemView view) : base(view)
        {
            _view = view;
            RotateSpeed = _view.RotateSpeed;
            MaxFlyHeight = _view.FlyHeight;
            MinFlyHeight = _view.Transform.position.y;
        }

        public override void Execute()
        {
            Fly();
            Rotate();
        }

        public void Rotate()
        {
            _view.Transform.RotateAround(_view.Transform.position, Vector3.up, RotateSpeed * Time.deltaTime);
        }

        public void Fly()
        {
            float currentHeight = MinFlyHeight;
            if ((MaxFlyHeight - MinFlyHeight) > 0)
                currentHeight = Mathf.PingPong(Time.time, MaxFlyHeight) + MinFlyHeight;
            _view.Transform.position = new Vector3(_view.Transform.position.x, currentHeight, _view.Transform.position.z);
        }
    }
}
