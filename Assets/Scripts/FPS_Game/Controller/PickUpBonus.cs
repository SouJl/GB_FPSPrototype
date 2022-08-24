using System;
using UnityEngine;

namespace  FPS_Game
{
    public class PickUpBonus : Bonus
    {
        public float rotateSpeed;
        public float flyHeight;

        public override void Update()
        {
            transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
        }

        protected override void Interaction(Player player) { }
    }
}
