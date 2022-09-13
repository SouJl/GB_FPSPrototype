using UnityEngine;

namespace FPS_Game.MVC 
{
    public abstract class BaseWeapon : IWeapon
    {

        private Transform _muzzle;

        private float _damage;
        private float _distance;
        private int _currentAmmo;
        private int _magSize;
        private int _fireRate;
        private float _reloadTime;
        private float _timeBeforeShoot;

        private bool _isReloading;

        public float Damage { get => _damage; set => _damage = value; }
        public float Distance { get => _distance; set => _distance = value; }
        public int CurrentAmmo { get => _currentAmmo; set => _currentAmmo = value; }
        public int MagSize { get => _magSize; set => _magSize = value; }
        public int FireRate { get => _fireRate; set => _fireRate = value; }
        public bool IsReloading { get => _isReloading; set => _isReloading = value; }
        public Transform Transform { get => Muzzle; set => Muzzle = value; }
        public float TimeBeforeShoot { get => _timeBeforeShoot; set => _timeBeforeShoot = value; }
        public Transform Muzzle { get => _muzzle; set => _muzzle = value; }
        public float ReloadTime { get => _reloadTime; set => _reloadTime = value; }

        public BaseWeapon(WeaponView view)
        {
            Transform = view.Transform;
            Damage = view.Damage;
            Distance = view.Distance;
            CurrentAmmo = view.CurrentAmmo;
            MagSize = view.MagSize;
            FireRate = view.FireRate;
            Muzzle = view.Muzzle;
            ReloadTime = view.ReloadTime;
        }

        public abstract void Reload();

        public abstract void Shoot();
    }
}

