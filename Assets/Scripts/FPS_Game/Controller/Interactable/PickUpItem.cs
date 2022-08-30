using System;
using UnityEngine;

namespace FPS_Game
{
    public abstract class PickUpItem : Interactable, IFly, IRotate
    {
        [Header("PickUp Settings")]
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _flyHeight;

        public float MinFlyHeight { get; private set; }
        public float MaxFlyHeight
        {
            get => _flyHeight;
            set
            {
                _flyHeight = value;
            }
        }
        
        public float RotateSpeed
        {
            get => _rotateSpeed;
            set => _rotateSpeed = value;
        }

        public override void Awake()
        {
            base.Awake();
            MinFlyHeight = transform.position.y;
        }

        public virtual void Update()
        {
            Fly();
            Rotate();
        }

        public void Rotate()
        {
            transform.RotateAround(transform.position, Vector3.up, RotateSpeed * Time.deltaTime);
        }

        public void Fly()
        {

            float currentHeight = MinFlyHeight;
            if ((MaxFlyHeight - MinFlyHeight) > 0)
                currentHeight = Mathf.PingPong(Time.time, MaxFlyHeight) + MinFlyHeight;
            transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
        }
    }
}
