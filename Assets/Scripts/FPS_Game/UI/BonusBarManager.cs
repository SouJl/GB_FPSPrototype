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

        private Player playerController;
        private bool _isTimerEnable;
        private float _timerCounter;

        private void Awake()
        {
            playerController = FindObjectOfType<Player>();
            ResetUI();
        }

        private void Update()
        {
            if (!playerController) return;
            BonusTimer();
        }

        private void BonusTimer() 
        {
            if (playerController.IsBonusActive)
            {
                if (!_isTimerEnable)
                {
                    _timerCounter = (int)playerController.CurrentBonus.activeTime + 1;
                    iconImage.enabled = true;
                    _isTimerEnable = true;
                }
                _timerCounter -= Time.deltaTime;
                float secondsLeft = Mathf.FloorToInt(_timerCounter % 60);
                iconImage.sprite = playerController.CurrentBonus.icon;
                counterText.text = $"{secondsLeft}";
            }
            else
                ResetUI();
        }

        private void ResetUI() 
        {
            iconImage.sprite = null;
            counterText.text = "";
            _timerCounter = 0;
            _isTimerEnable = false;
            iconImage.enabled = false;
        }
    }
}

