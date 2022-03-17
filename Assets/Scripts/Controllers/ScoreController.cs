using Core;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private NumberCounter score;
        [SerializeField] private TMP_Text scoreText;
    
        public void IncrementScore(int amount)
        {
            score.Increment(amount);
            _updateScoreText();
        }
        public void ResetScore()
        {
            score.Reset();
            _updateScoreText();
        }
        
        private void _updateScoreText()
        {
            if(scoreText != null)
                scoreText.text = score.GetAmount().ToString();
        }

        
    }
}
