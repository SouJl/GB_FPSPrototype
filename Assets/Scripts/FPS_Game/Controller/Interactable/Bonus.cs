using UnityEngine;

namespace FPS_Game
{
    public abstract class Bonus: Interactable, IPickUp
    {
        [Header("Bonus Settings")]
        public float bonusValue;
        public Sprite icon;
        public float activeTime = 5f;

        [Header("PickUp Settings")]
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _flyHeight;

        public abstract BonusType BonusType { get; }
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

        public virtual void Update()
        {
            MoveBehavior();
        }

        public void MoveBehavior()
        {
            transform.RotateAround(transform.position, Vector3.up, RotateSpeed * Time.deltaTime);
        }

        protected override void Interaction(Player player)
        {
            player.AddBonus(this);
            IsActive = false;
            gameObject.SetActive(IsActive);
        }

    }
}
