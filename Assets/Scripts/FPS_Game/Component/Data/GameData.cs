
using System.Collections.Generic;

namespace FPS_Game.Data
{
    [System.Serializable]
    public class GameData
    {
        public float gameScore;

        public SaveObjectData playerTransformData;
        public PlayerData playerData;

        public List<SaveObjectData> pickUpitems;
    }
}
