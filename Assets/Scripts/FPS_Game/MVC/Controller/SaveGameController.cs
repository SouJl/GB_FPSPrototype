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

        private Action<GameData> OnLoadData;
        private Func<GameData> OnDataRequest;

        public SaveGameController(PlayerInput inputSys, Func<GameData> onDataFunc, Action<GameData> onLoadAction)
        {
            _iputSystem = inputSys;
            _save = _iputSystem.System.Save;
            _load = _iputSystem.System.Load;

            _save.performed += S => Save();
            _load.performed += L => Load();


            string path = Path.Combine(Application.dataPath, _folderName, "gamedata.xml");
            _gameDataSerializer = new ToSerializeXMLData<GameData>(path);

 
            OnLoadData = onLoadAction;
            OnDataRequest = onDataFunc;

            OnEnable();

        }

        private void Save()
        {
            Debug.Log("Game Data Save");
            var gamedata = OnDataRequest?.Invoke();
            _gameDataSerializer.Save(gamedata);
        }

        private void Load()
        {
            Debug.Log("Game Data Load");
            GameData data = _gameDataSerializer.Load(); 
            OnLoadData?.Invoke(data);
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
