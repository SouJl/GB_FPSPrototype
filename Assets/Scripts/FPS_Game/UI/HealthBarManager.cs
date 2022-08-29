using UnityEngine;
using UnityEngine.UI;

namespace FPS_Game.UI
{
    public class HealthBarManager : MonoBehaviour
    {
        public Image healthBarFill;

        private Player playerController;

        private void Start()
        {
            playerController = FindObjectOfType<Player>();
            try 
            {
                healthBarFill.fillAmount = playerController.CurrentHealth / playerController.maxHealth;
            }
            catch(System.NullReferenceException ex) 
            {
                Debug.LogException(ex, this);
            }
        }

        private void Update()
        {
            healthBarFill.fillAmount = playerController.CurrentHealth / playerController.maxHealth;
        }
    }
}


