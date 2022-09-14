using UnityEngine;
using UnityEngine.InputSystem;

namespace FPS_Game.MVC
{
    public class WeaponController : IExecute
    {
        private BaseWeapon _weapon;
        
        private PlayerInput _iputSystem;

        private InputAction _fire;
        private InputAction _reload;

        public WeaponController(BaseWeapon weapon, PlayerInput inputSys)
        {
            _weapon = weapon;
            _iputSystem = inputSys;

            _fire = _iputSystem.Weapon.Fire;
            _reload = _iputSystem.Weapon.Reload;

            _fire.performed +=  fire => _weapon.Shoot();
            _reload.performed += rld => _weapon.Reload();

            OnEnable();
        }

        public void Execute() 
        {
            _weapon.TimeBeforeShoot += Time.deltaTime;
        }

        private void OnEnable()
        {
            _fire.Enable();
            _reload.Enable();
        }

        private void OnDisable()
        {
            _fire.Disable();
            _reload.Disable();
        }

        ~WeaponController() => OnDisable();
    }

}

