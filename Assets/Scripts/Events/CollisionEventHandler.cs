using Core;
using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class CollisionEventHandler : MonoBehaviour
    {
        public StringVariable gameObjectTag;
        public UnityEvent onTriggerExecute;
    
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag.Equals(gameObjectTag.GetValue()))
            {
                onTriggerExecute.Invoke();
            }
        }
    }
}
