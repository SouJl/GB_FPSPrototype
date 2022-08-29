using UnityEngine;

namespace FPS_Game
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private Unit _player;
        [SerializeField] private PickUp[] _gamePoints;

        private PlayerInput inputSystem;

        private MoveController _moveController;
        private LookController _lookController;

        private ListExecuteController _executeUpdate;
        private ListExecuteController _executeLateUpdate;


        private void Awake()
        {
            inputSystem = new PlayerInput();
            _executeUpdate = new ListExecuteController();
            _executeLateUpdate = new ListExecuteController();

            _moveController = new MoveController(inputSystem, _player);
            _executeUpdate.AddExecuteObject(_moveController);

            _lookController = new LookController(inputSystem, _player);
            _executeLateUpdate.AddExecuteObject(_lookController);
            
            SpawnBonus();
        }

        private void Update()
        {
            while (_executeUpdate.MoveNext()) 
            {
                IExecute tmp = (IExecute)_executeUpdate.Current;
                tmp.Update();
            }
            _executeUpdate.Reset();
        }

        private void LateUpdate()
        {
            while (_executeLateUpdate.MoveNext())
            {
                IExecute tmp = (IExecute)_executeLateUpdate.Current;
                tmp.Update();
            }
            _executeLateUpdate.Reset();
        }


        private void SpawnBonus()
        {
            for (int i = 0; i < _gamePoints.Length; i++)
            {
                _gamePoints[i].gameObject.SetActive(true);
                _gamePoints[i].IsActive = true;
            }
        }
    }
}

