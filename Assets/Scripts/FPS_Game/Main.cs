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
        [SerializeField] private Player _player;
        [SerializeField] private Interactable[] interactItems;
        [SerializeField] private Button _restartButton;

        private PlayerInput inputSystem;

        private MoveController _moveController;
        private LookController _lookController;

        private ListExecuteController _executeUpdate;
        private ListExecuteController _executeLateUpdate;

        /*UI components*/
        private BonusBarManager _bonusBarManager;
        private HealthBarManager _healthBarManager;
        private ScoreManager _scoreManager;
        private GameOverManager _gameOverManager;

        /*MVC test*/
        [SerializeField] private InteractView[] itemViews;
        private InteractableController _interactableController;

        private float _gameScore;

        private void Awake()
        {
            _gameScore = 0;
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
                for (int i = 0; i < itemViews.Length; i++)
                {
                    itemViews[i].gameObject.SetActive(true);
                    var model = Fabric(itemViews[i]);
                    _executeUpdate.AddExecuteObject(model);
                    _interactableController.AddControllerObject(new InteractableController(model, itemViews[i]));
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
            if (interactView is HasteView haste)
            {
                var hasteModel = new HasteModel(haste);
                hasteModel.AddBonus += _player.AddBonus;
                hasteModel.AddBonus += _bonusBarManager.AddBonus;
                interact = hasteModel;
      
            }
            if(interactView is SlowView slow) 
            {
                var slowModel = new SlowModel(slow);
                slowModel.AddBonus += _player.AddBonus;
                slowModel.AddBonus += _bonusBarManager.AddBonus;
                interact = slowModel;
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

            _lookController = new LookController(inputSystem, _player);
            _executeLateUpdate.AddExecuteObject(_lookController);
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

