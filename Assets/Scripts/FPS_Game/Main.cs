using FPS_Game.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using FPS_Game.MVC;
using FPS_Game.Data;
using System.Collections.Generic;
using System.Linq;
using System;
using TMPro;

namespace FPS_Game
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private float _gameGoal = 500;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private InteractView[] itemViews;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Image _healthBar;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private WeaponView _weaponView;

        private PlayerModel _playerModel;
        private Camera _camera;
        private PlayerInput inputSystem;

        private PlayerController _playerController;
        private InteractableController _interactableController;
        private CameraController _cameraController;

        private ListExecuteController _executeUpdate;
        private ListExecuteController _executeLateUpdate;

        private BaseWeapon CurrentWeapon;
        private WeaponController _weaponController;

        private SaveGameController _saveGameController;

        /*UI components*/
        private BonusBarManager _bonusBarManager;
        private HealthBarManager _healthBarManager;
        private ScoreManager _scoreManager;
        private GameOverManager _gameOverManager;

        private float _gameScore;

        private void Awake()
        {
            _gameScore = 0;

            try 
            {
                if (!_playerView) throw new PlayerNotFoundExeption("Объект Player не задан");

                inputSystem = new PlayerInput();

                _camera = _playerView.Camera;
                _playerModel = new PlayerModel(_playerView);

                InitExecuteObjects();
                InitUIComponents();

                _playerModel.GameOver += GameOver;
                _playerModel.GameOver += _gameOverManager.GameOver;

                SpawnBonus();

                Cursor.lockState = CursorLockMode.Locked;
            }
            catch (PlayerNotFoundExeption ex) 
            {
                Debug.Log($"{ex} : {ex.Message}!");
                Quit();
            }
        }

        private void Update()
        {
            while (_executeUpdate.MoveNext()) 
            {
                IExecute tmp = (IExecute)_executeUpdate.Current;
                tmp.Execute();
            }
            _executeUpdate.Reset();
        }

        private void LateUpdate()
        {
            while (_executeLateUpdate.MoveNext())
            {
                IExecute tmp = (IExecute)_executeLateUpdate.Current;
                tmp.Execute();
            }
            _executeLateUpdate.Reset();
        }


        private void SpawnBonus()
        {
            try
            {
                if (itemViews.Length == 0) throw new NoItemExeception("Последовательность не содержит елементов", "interactItems");

                _interactableController = new InteractableController();
                foreach(var itemView in itemViews)
                {
                    itemView.gameObject.SetActive(true);
                    var model = Fabric(itemView);
                    _executeUpdate.AddExecuteObject(model);
                    _interactableController.AddControllerObject(new InteractableController(model, itemView));
                }
            }
            catch(NoItemExeception ex)
            {
                Debug.LogWarning($"Main: {ex.Message}; source - {ex.SourceName}");
            }
           
        }

        private AbstractInteractModel Fabric(InteractView interactView)
        {
            AbstractInteractModel interact = null;
            switch (interactView) 
            {
                case BonusView bonus: 
                    {
                        var bonusModel = new BonusModel(bonus);
                        
                        bonusModel.AddBonus += _playerModel.AddBonus;
                        bonusModel.AddBonus += _bonusBarManager.AddBonus;
                        interact = bonusModel;
                        break;
                    }
                case GamePointView gamePoint:
                    {
                        var gamePointModel = new GamePointModel(gamePoint);
                        gamePointModel.AddPoint += AddPoints;

                        interact = gamePointModel;
                        break;
                    }
                case AidKitView aidKit: 
                    {
                        var aidKitModel = new AidKitModel(aidKit);
                        aidKitModel.Heal += _playerModel.Heal;
                        interact = aidKitModel;
                        break;
                    }
                case TrapView trap: 
                    {
                        var trapModel = new TrapModel(trap);
                        trapModel.OnDamage += _playerModel.TakeDamage;
                        interact = trapModel;
                        break;
                    }
            }
 

            return interact;
        }

        private void AddPoints(float value)
        {
            _gameScore += value;
            _scoreManager.AddPoints(_gameScore);
            /*if(_gameScore >= _gameGoal) 
            {
                _gameOverManager.GameOver(true);
                GameOver(true);
            } */
        }

        private GameData SaveGameData()
        {
            var gameData = new GameData();

            gameData.gameScore = _gameScore;

            gameData.playerTransformData = new SaveObjectData
            {
                Name = _playerView.name,
                position = _playerView.transform.position,
                rotation = _playerView.transform.rotation,
                IsEnable = true
            };

            gameData.playerData = new PlayerData
            {
                CurrentHealth = _playerModel.CurrentHealth,
                CurrentSpeed = _playerModel.CurrentSpeed
            };

            gameData.pickUpitems = new List<SaveObjectData>();
            for(int i =0; i < _interactableController.Length; i++) 
            {
                if (_interactableController[i].Model is AbstractPickUpItemModel pickUp)
                {
                    gameData.pickUpitems.Add(new SaveObjectData
                    {
                        Name = pickUp.Name,
                        position = pickUp.Transform.position,
                        rotation = pickUp.Transform.rotation,
                        IsEnable = pickUp.IsActive
                    });
                }
            }
            return gameData;
        }

        private void LoadGameData(GameData data)
        {
            _gameScore = data.gameScore;
            _scoreManager.AddPoints(_gameScore);

            _playerView.LoadData(data.playerTransformData.position, data.playerTransformData.rotation);
            _playerModel.LoadData(data.playerData);

            foreach (var pickUpData in data.pickUpitems)
            {
                for (int i = 0; i < _interactableController.Length; i++) 
                {
                    if (_interactableController[i].Model is AbstractPickUpItemModel pickUp) 
                    {
                        if(pickUp.Name == pickUpData.Name)
                        {
                            pickUp.LoadData(pickUpData.position, pickUpData.rotation, pickUpData.IsEnable);
                        }
                    }
                }
            }
        }

        private void GameOver(bool state) 
        {
            _restartButton.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
         
        private void RestartGame()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }


        #region Game Init

        private void InitExecuteObjects()
        {
            _executeUpdate = new ListExecuteController();
            _executeLateUpdate = new ListExecuteController();

            _playerController = new PlayerController(_playerModel, inputSystem);
            _executeUpdate.AddExecuteObject(_playerController);

            _cameraController = new CameraController(_playerView.Transform, _camera.transform, inputSystem, (_playerView.XSensitivity, _playerView.YSensitivity));
            _executeLateUpdate.AddExecuteObject(_cameraController);

            CurrentWeapon = new AssaltRifle(_weaponView);
            _weaponController = new WeaponController(CurrentWeapon, inputSystem);
            _executeUpdate.AddExecuteObject(_weaponController);

            _saveGameController = new SaveGameController(inputSystem, SaveGameData, LoadGameData);

        }

        private void InitUIComponents()
        {
            _bonusBarManager = GetComponentInChildren<BonusBarManager>();
            
            _healthBarManager = new HealthBarManager(_playerModel, _healthBar);
            _executeUpdate.AddExecuteObject(_healthBarManager);

            _scoreManager = new ScoreManager(_scoreText);

            _gameOverManager = GetComponentInChildren<GameOverManager>();

            _restartButton.onClick.AddListener(RestartGame);
            _restartButton.gameObject.SetActive(false);
        }

        #endregion

        public void Quit()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }

    }
}

