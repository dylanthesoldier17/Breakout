using Controllers;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public GameObject[] blocks;
        public LivesController livesController;
        public ScoreController scoreController; 
    
        public void BlockBroken()
        {
            scoreController.IncrementScore(1);
        
            if (_allBlocksDestroyed()) 
                ResetGame();
        }
        public void LostLive()
        {
            livesController.Decrement(1);
        
            if (livesController.GetCurrentLivesCount() <= 0)
            {
                ResetGame();
            }
        }
        public void ResetGame()
        {
            _resetScore();
            _resetLives();
            _resetBlocks();
        }

        private bool _allBlocksDestroyed()
        {
            foreach (GameObject block in blocks)
            {
                if (block.activeSelf == true)
                    return false;
            }

            return true;
        }
        private void _resetScore()
        {
            scoreController.ResetScore();
        }
        private void _resetLives()
        {
            livesController.ResetLives();
        }
        private void _resetBlocks()
        {
            foreach (GameObject block in blocks)
            {
                block.SetActive(true);
            }
        }
    }
}
