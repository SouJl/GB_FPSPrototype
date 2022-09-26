using System;
using UnityEngine;

namespace FPS_Game.MVC
{
    public class WeaponView: BaseView
    {
        [Header("Weapon Settings")]
        [SerializeField] private float _damage;
        [SerializeField] private float _distance;
        [SerializeField] private int _currentAmmo;
        [SerializeField] private int _magSize;
        [SerializeField] private int _fireRate;
        [SerializeField] private float _reloadTime;
        [SerializeField] private Transform _muzzle;
        
        [Space(10)]
        [Header("Effect Settings")]
        [SerializeField] private ParticleSystem _shootingSystem;
        [SerializeField] private ParticleSystem _impacBulletSystem;
        [SerializeField] private TrailRenderer _bulletTrail;

        public float Damage { get => _damage; set => _damage = value; }
        public float Distance { get => _distance; set => _distance = value; }
        public int CurrentAmmo { get => _currentAmmo; set => _currentAmmo = value; }
        public int MagSize { get => _magSize; set => _magSize = value; }
        public int FireRate { get => _fireRate; set => _fireRate = value; }
        public float ReloadTime { get => _reloadTime; set => _reloadTime = value; }
        public Transform Muzzle { get => _muzzle; set => _muzzle = value; }
        public ParticleSystem ShootingSystem { get => _shootingSystem; set => _shootingSystem = value; }
        public ParticleSystem ImpacBulletSystem { get => _impacBulletSystem; set => _impacBulletSystem = value; }
        public TrailRenderer BulletTrail { get => _bulletTrail; set => _bulletTrail = value; }
      

        private void OnDrawGizmos()
        {
            Debug.DrawLine(Muzzle.position, Muzzle.position + Muzzle.forward * Distance);
        }

    }
}
