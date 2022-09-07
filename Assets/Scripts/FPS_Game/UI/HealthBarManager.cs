using FPS_Game.MVC;
using UnityEngine;
using UnityEngine.UI;

namespace FPS_Game.UI
{
    public class HealthBarManager: IExecute
    {
        private Image _healthBarFill;
        private PlayerModel _playerModel;

        public HealthBarManager(PlayerModel playerModel, Image healthBarFill)
        {         
            try
            {
                _playerModel = playerModel;
                _healthBarFill = healthBarFill;
            }
            catch (System.NullReferenceException ex)
            {
                Debug.LogException(ex);
            }
        }

        public void Execute()
        {
            _healthBarFill.fillAmount = _playerModel.CurrentHealth / _playerModel.MaxHealth;
        }

    }
}


