using UnityEngine;

namespace FPS_Game.MVC
{
    public class PickUpItemView : InteractView
    {
        [Header("PickUp Settings")]
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _flyHeight;

        public float RotateSpeed { get => _rotateSpeed; set => _rotateSpeed = value; }
        public float FlyHeight { get => _flyHeight; set => _flyHeight = value; }

        private void OnTriggerEnter(Collider other)
        {
            Interaction(other);
        }
    }
}
