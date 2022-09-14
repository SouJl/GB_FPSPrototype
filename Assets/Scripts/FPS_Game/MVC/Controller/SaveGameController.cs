using FPS_Game.Data;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FPS_Game.MVC
{
    public class SaveGameController
    {
        private const string _folderName = "GameDataSave";

        private PlayerInput _iputSystem;

        private InputAction _save;
        private InputAction _load;

        private ToSerializeXMLData<GameData> _gameDataSerializer;
        private GameData _gameData;

        private Action<GameData> OnLoadData;

        public SaveGameController(PlayerInput inputSys, GameData gameData, Action<GameData> onLoadAction)
        {
            _iputSystem = inputSys;
            _save = _iputSystem.System.Save;
            _load = _iputSystem.System.Load;

            _save.performed += S => Save();
            _load.performed += L => Load();

            _gameData = gameData;

            string path = Path.Combine(Application.dataPath, _folderName, "gamedata.xml");
            _gameDataSerializer = new ToSerializeXMLData<GameData>(path);

            OnLoadData = onLoadAction;

            OnEnable();

        }

        private void Save()
        {
            Debug.Log("Game Data Save");
            //_gameDataSerializer.Save(_gameData);
        }

        private void Load()
        {
            //GameData data = _gameDataSerializer.Load();
            Debug.Log("Game Data Load");
            OnLoadData?.Invoke(null);
        }

        private void OnEnable()
        {
            _save.Enable();
            _load.Enable();
        }

        private void OnDisable()
        {
            _save.Disable();
            _load.Disable();
        }

        ~SaveGameController() => OnDisable();

    }
}
