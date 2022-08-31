using FPS_Game.UI;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
            try
            {
                if (interactItems.Length == 0) throw new NoItemExeception("Последовательность не содержит елементов", "interactItems");

                for (int i = 0; i < interactItems.Length; i++)
                {
                    interactItems[i].gameObject.SetActive(true);
                    interactItems[i].IsActive = true;

                    if (interactItems[i] is Bonus bonus)
                    {
                        bonus.AddBonus += _player.AddBonus;
                        bonus.AddBonus += _bonusBarManager.AddBonus;
                    }
                    if (interactItems[i] is AidKit aidKit)
                    {
                        aidKit.Heal += _player.Heal;
                    }
                    if (interactItems[i] is Trap trap)
                    {
                        trap.TakeDamage += _player.TakeDamage;
                    }
                    if (interactItems[i] is IPoint point)
                    {
                        point.AddPoint += AddPoints;
                        point.AddPoint += _scoreManager.AddPoints;
                    }
                }
            }
            catch(NoItemExeception ex)
            {
                Debug.LogWarning($"Main: {ex.Message}; source - {ex.SourceName}");
            }
           
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

