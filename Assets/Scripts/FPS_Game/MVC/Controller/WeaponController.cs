using FPS_Game.Data;
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

        private ToSerializeXMLData<WeaponData> data;

        public WeaponController(BaseWeapon weapon, PlayerInput inputSys)
        {
            _weapon = weapon;
            _iputSystem = inputSys;

            _fire = _iputSystem.Weapon.Fire;
            _reload = _iputSystem.Weapon.Reload;

            _fire.performed +=  fire => _weapon.Shoot();
            _reload.performed += rld => _weapon.Reload();

            data = new ToSerializeXMLData<WeaponData>(Application.persistentDataPath + "/WeaponData.xml");

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

