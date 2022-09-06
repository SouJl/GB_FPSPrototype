using FPS_Game.MVC;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FPS_Game.UI 
{
    public class BonusBarManager : MonoBehaviour
    {
        public Image iconImage;
        public TextMeshProUGUI counterText;

        private void Awake()
        {
            ResetUI();
        }


        public void AddBonus(BonusModel bonus)
        {
            StartCoroutine(BonusTimer(bonus));
        }

        IEnumerator BonusTimer(BonusModel bonus)
        {
            float timeLeft = bonus.ActiveTime;
            iconImage.enabled = true;
            iconImage.sprite = bonus.Icon;
            while (timeLeft > 0)
            {
                counterText.text = $"{Mathf.FloorToInt(timeLeft % 60)}";
                timeLeft -= Time.deltaTime;
                yield return null;
            }
            ResetUI();
        }

        private void ResetUI() 
        {
            iconImage.sprite = null;
            counterText.text = "";
            iconImage.enabled = false;
        }
    }
}

