using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class BlockBreaker : MonoBehaviour
    {
        public StringVariable blockTag;
        public float breakDelayInSeconds = .1f;
        public UnityEvent blockCollisionEvent;
    
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!col.gameObject.tag.Equals(blockTag.GetValue())) 
                return;
            
            _invokeCollisionEvent();
            StartCoroutine(_disableGameObjectCO(col.gameObject));
        }
        private void _invokeCollisionEvent()
        {
            blockCollisionEvent.Invoke();
        }
    
        private IEnumerator _disableGameObjectCO(GameObject block)
        {
            yield return new WaitForSeconds(breakDelayInSeconds);
            block.SetActive(false);
        }
    }
}
