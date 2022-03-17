using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "StringSO", menuName = "Variables/String Variable")]
    public class StringVariable : ScriptableObject
    {
        [SerializeField] private string stringVariable;

        public string GetValue()
        {
            return stringVariable;
        }
    }
}
