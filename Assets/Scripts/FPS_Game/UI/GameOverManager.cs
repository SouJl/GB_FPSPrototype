using TMPro;
using UnityEngine;

namespace FPS_Game.UI 
{
    public class GameOverManager : MonoBehaviour
    {
        public TextMeshProUGUI gameOverText;

        private void Awake()
        {
            gameOverText.text = "";
        }

        public void GameOver(bool state) 
        {
            if (state)
            {
                gameOverText.text = "Game Won!";
            }
            else
            {
                gameOverText.text = "Game Over";
            }
        }
    }
}

