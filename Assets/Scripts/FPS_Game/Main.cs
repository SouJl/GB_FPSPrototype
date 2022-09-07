using FPS_Game.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using FPS_Game.MVC;
using System.Collections.Generic;

namespace FPS_Game
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private float _gameGoal = 500;
        [SerializeField] private GameObject _playerObject;
        [SerializeField] private InteractView[] itemViews;
        [SerializeField] private Button _restartButton;

        private Player _player;
        private Camera _camera;
        private PlayerInput inputSystem;

        private MoveController _moveController;
        private InteractableController _interactableController;
        private CameraController _cameraController;

        private ListExecuteController _executeUpdate;
        private ListExecuteController _executeLateUpdate;

        /*UI components*/
        private BonusBarManager _bonusBarManager;
        private HealthBarManager _healthBarManager;
        private ScoreManager _scoreManager;
        private GameOverManager _gameOverManager;

        private float _gameScore;

        private void Awake()
        {
            _gameScore = 0;

            _player = _playerObject.GetComponent<Player>();
            _camera = _player.playerCamera;

            try 
            {
                if (!_player) throw new PlayerNotFoundExeption("Объект Player не задан");

                inputSystem = new PlayerInput();
                InitExecuteObjects();
                InitUIComponents();
          
                _player.GameOver += GameOver;
                _player.GameOver += _gameOverManager.GameOver;

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
                        bonusModel.AddBonus += _player.AddBonus;
                        bonusModel.AddBonus += _bonusBarManager.AddBonus;
                        interact = bonusModel;
                        break;
                    }
                case GamePointView gamePoint:
                    {
                        var gamePointModel = new GamePointModel(gamePoint);
                        gamePointModel.AddPoint += AddPoints;
                        gamePointModel.AddPoint += _scoreManager.AddPoints;
                        interact = gamePointModel;
                        break;
                    }
                case AidKitView aidKit: 
                    {
                        var aidKitModel = new AidKitModel(aidKit);
                        aidKitModel.Heal += _player.Heal;
                        interact = aidKitModel;
                        break;
                    }
                case TrapView trap: 
                    {
                        var trapModel = new TrapModel(trap);
                        trapModel.OnDamage += _player.TakeDamage;
                        interact = trapModel;
                        break;
                    }
            }
 

            return interact;
        }

        private void AddPoints(float value)
        {
            _gameScore += value;
            if(_gameScore >= _gameGoal) 
            {
                _gameOverManager.GameOver(true);
                GameOver(true);
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

            _moveController = new MoveController(inputSystem, _player);
            _executeUpdate.AddExecuteObject(_moveController);

            _cameraController = new CameraController(_player.transform, _camera.transform, inputSystem, (_player.xSensitivity, _player.ySensitivity));
            _executeLateUpdate.AddExecuteObject(_cameraController);
        }

        private void InitUIComponents()
        {
            _bonusBarManager = GetComponentInChildren<BonusBarManager>();
            _healthBarManager = GetComponentInChildren<HealthBarManager>();
            _scoreManager = GetComponentInChildren<ScoreManager>();
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

