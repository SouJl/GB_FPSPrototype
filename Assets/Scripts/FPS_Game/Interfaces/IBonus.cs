using System;

namespace FPS_Game.MVC
{
    public interface IBonus
    {
        float BonusValue { get; set; }
        float ActiveTime { get; set; }

        public Action<BonusModel> AddBonus { get; set; }
    }
}
