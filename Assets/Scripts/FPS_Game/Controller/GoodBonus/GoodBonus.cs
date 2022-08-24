using UnityEngine;

namespace FPS_Game
{
    public class GoodBonus : Bonus
    {
        public int BonusPoints;
        public float rotateSpeed;
        public float flyHeight;

        public override void Awake()
        {
            base.Awake();
            var pos = transform.position;
            pos.y = flyHeight;
            transform.position = pos;
        }

        public override void Update()
        {
            transform.RotateAround(transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
        }

        protected override void Interaction(Player player)
        {
            DisplayBonuses.Instance.DisplayGamePoints(BonusPoints);
            gameObject.SetActive(false);           
        }
    }
}
