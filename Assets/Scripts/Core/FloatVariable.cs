using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "FloatSO", menuName = "Variables/Float Variable")]
    public class FloatVariable: ScriptableObject
    {
        [SerializeField] private float floatVariable;

        public float GetValue()
        {
            return floatVariable;
        }
    }
}