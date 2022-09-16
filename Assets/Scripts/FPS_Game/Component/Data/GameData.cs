
using System.Collections.Generic;

namespace FPS_Game.Data
{
    [System.Serializable]
    public class GameData
    {
        public SaveObjectData playerData;

        public List<SaveObjectData> pickUpitems;
    }
}
