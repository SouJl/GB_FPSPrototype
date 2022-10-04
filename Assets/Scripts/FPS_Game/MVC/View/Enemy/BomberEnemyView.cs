using UnityEngine;

namespace FPS_Game.MVC
{
    public sealed class BomberEnemyView : BaseEnemyView
    {
        [Header("Explosion settings: BomberEnemy")]
        [SerializeField] private float _explosionDelay = 3f;

        public float ExplosionDelay { get => _explosionDelay; set => _explosionDelay = value; }
        
        protected override void Awake()
        {
            base.Awake();
        }
    }
}

