using UnityEngine;

namespace FPS_Game 
{
    public class AidKit : Interactable, IPickUp
    {
        [Header("AidKit Settings")]
        public float HealAmount = 30f;

        [Header("PickUp Settings")]
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _flyHeight;
        
        public float RotateSpeed
        {
            get => _rotateSpeed;
            set => _rotateSpeed = value;
        }
        public float FlyHeight
        {
            get => _flyHeight;
            set => _flyHeight = value;
        }

        public override void Awake()
        {
            base.Awake();

            var pos = transform.position;
            pos.y = FlyHeight;
            transform.position = pos;
        }

        public void Update()
        {
            MoveBehavior();
        }

        public void MoveBehavior()
        {
            transform.RotateAround(transform.position, Vector3.up, RotateSpeed * Time.deltaTime);
        }

        protected override void Interaction(Player player)
        {
            player.Heal(HealAmount);
            IsActive = false;
            gameObject.SetActive(IsActive);
        }
    }
}

