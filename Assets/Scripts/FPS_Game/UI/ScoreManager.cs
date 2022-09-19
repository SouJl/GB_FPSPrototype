using TMPro;

namespace FPS_Game.UI 
{
    public class ScoreManager 
    {
        private TextMeshProUGUI _scoreText;
        private float _score;
        
        public ScoreManager(TextMeshProUGUI scoreText)
        {
            _scoreText = scoreText;
            _score = 0;
            scoreText.text = $"Score: {_score}";
        }

        public void AddPoints(float value) 
        {
            _score = value;
            _scoreText.text = $"Score: {_score}";
        }
    }
}

