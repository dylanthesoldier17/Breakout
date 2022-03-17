using UnityEngine;

namespace Core
{
    [System.Serializable]
    public class NumberCounter
    {
        [SerializeField] private int startingAmount;
        [SerializeField] private int trackedAmount;

        public NumberCounter(int startingAmount = 0)
        {
            this.startingAmount = startingAmount;
        }
    
        public void Increment(int amount)
        {
            trackedAmount += amount;
        }

        public void Decrement(int amount)
        {
            trackedAmount -= amount;
        }

        public void Reset()
        {
            trackedAmount = startingAmount;
        }

        public int GetAmount()
        {
            return trackedAmount;
        }

        public void SetAmount(int value)
        {
            trackedAmount = value;
        }
        
    }
}
