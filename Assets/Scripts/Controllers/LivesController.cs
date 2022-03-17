using Core;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class LivesController : MonoBehaviour
    {
        [SerializeField] private NumberCounter lives;
        [SerializeField] private TMP_Text livesText;
        public void Decrement(int amount)
        {
            lives.Decrement(amount);
            _updateScoresText();
        }
        
        public int GetCurrentLivesCount()
        {
            return lives.GetAmount();
        }
        
        public void ResetLives()
        {
            lives.Reset();
            _updateScoresText();
        }
        
        private void _updateScoresText()
        {
            if (livesText != null)
                livesText.text = lives.GetAmount().ToString();
        }
    }
}
