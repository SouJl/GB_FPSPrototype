using TMPro;
using UnityEngine;

namespace FPS_Game.UI 
{
    public class ScoreManager : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;

        private float _score;
        private void Awake()
        {
            _score = 0;
            scoreText.text = $"Score: {_score}";
        }

        public void AddPoints(float value) 
        {
            _score += value;
            scoreText.text = $"Score: {_score}";
        }
    }
}

