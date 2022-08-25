using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FPS_Game 
{
    public class BonusBarManager : MonoBehaviour
    {
        public Image iconImage;
        public TextMeshProUGUI counterText;

        private string counter;
        private Player playerController;
        private bool _isTimerEnable;

        private void Awake()
        {
            playerController = FindObjectOfType<Player>();
            ResetUI();
        }

        private void Update()
        {
            if (!playerController) return;

            if (!_isTimerEnable) 
            {
                if (playerController.IsBonusActive)
                {
                    iconImage.sprite = playerController.CurrentBonus.icon;
                    // counterText.text = playerController.CurrentBonus.icon;
                }
                else
                    ResetUI();
            }
        }

        private void ResetUI() 
        {
            iconImage.sprite = null;
            counterText.text = "";
        }
    }
}

