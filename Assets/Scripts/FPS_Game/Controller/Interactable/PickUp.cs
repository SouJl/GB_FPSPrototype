using UnityEngine;

namespace  FPS_Game
{
    public class PickUp : Interactable
    {
        [Header("PickUp Settings")]
        public float rotateSpeed;
        public float flyHeight;

        public override void Awake()
        {
            base.Awake();
        }

        public virtual void Update()
        {
            transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
        }

        protected override void Interaction(Player player) { }
    }
}
