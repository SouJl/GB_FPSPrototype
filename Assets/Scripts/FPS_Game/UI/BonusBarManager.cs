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

        public void AddBonus(Bonus bonus)
        {
            StartCoroutine(BonusTimer(bonus));
        }

        IEnumerator BonusTimer(Bonus bonus) 
        {
            float timeLeft = bonus.activeTime;
            iconImage.enabled = true;
            iconImage.sprite = bonus.icon;
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

