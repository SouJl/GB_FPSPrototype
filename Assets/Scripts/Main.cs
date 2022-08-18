using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS_Game 
{
    public class Main : MonoBehaviour
    {
        private PlayerInput inputSystem;

        private MoveController _moveController;
        private LookController _lookController;

        private ListExecuteController _executeUpdate;
        private ListExecuteController _executeLateUpdate;

        [SerializeField] private Unit _player;

        [SerializeField] private PlayerLook _playerLook;


        private void Awake()
        {
            inputSystem = new PlayerInput();
            _executeUpdate = new ListExecuteController();
            _executeLateUpdate = new ListExecuteController();

            _moveController = new MoveController(inputSystem, _player);
            _executeUpdate.AddExecuteObject(_moveController);

            _lookController = new LookController(inputSystem, _playerLook);
            _executeLateUpdate.AddExecuteObject(_lookController);
        }

        private void Update()
        {
            for(int i=0; i < _executeUpdate.Length; i++) 
            {
                if (_executeUpdate.InteractiveObject[i] == null) continue;

                _executeUpdate.InteractiveObject[i].Update();
            }
        }

        private void LateUpdate()
        {
            for (int i = 0; i < _executeLateUpdate.Length; i++)
            {
                if (_executeLateUpdate.InteractiveObject[i] == null) continue;

                _executeLateUpdate.InteractiveObject[i].Update();
            }
        }
    }
}

