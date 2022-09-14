using FPS_Game.MVC;

namespace FPS_Game.Data
{
    [System.Serializable]
    public class BonusData
    {
        public float BonusValue;
        public SpriteData Icon;
        public float ActiveTime;
        public BonusType Type;

        public BonusData() { }
        
        public BonusData(BonusModel bonus)
        {
            BonusValue = bonus.BonusValue;
            Icon = bonus.Icon;
            ActiveTime = bonus.ActiveTime;
            Type = bonus.Type;
        }        
    }
}
