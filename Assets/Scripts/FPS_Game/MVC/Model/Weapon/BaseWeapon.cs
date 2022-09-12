namespace FPS_Game.MVC 
{
    public abstract class BaseWeapon : IWeapon
    {
        private float _damage;
        private float _distance;
        private int _currentAmmo;
        private int _magSize;
        private int _fireRate;

        public float Damage { get => _damage; set => _damage = value; }
        public float Distance { get => _distance; set => _distance = value; }
        public int CurrentAmmo { get => _currentAmmo; set => _currentAmmo = value; }
        public int MagSize { get => _magSize; set => _magSize = value; }
        public int FireRate { get => _fireRate; set => _fireRate = value; }

        public abstract void Reload();

        public abstract void Shoot();
    }
}

