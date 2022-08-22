using UnityEngine;

namespace FPS_Game
{
    public sealed class DisplayBonuses
    {
        private int _gamePointsValue;

        private static DisplayBonuses _instance;
        
        public static DisplayBonuses Instance 
        {
            get 
            {
                if (_instance == null) 
                {
                    _instance = new DisplayBonuses();
                    _instance._gamePointsValue = 0;
                }
                return _instance;
            }
        }

        private DisplayBonuses() { }


        public void DisplayGamePoints(int value)
        {
            _gamePointsValue += value;
            Debug.Log($"Вы набрали {_gamePointsValue}");
            if(_gamePointsValue > 500)
                Debug.Log($"Игра пройдена!");
        }

    }
}
