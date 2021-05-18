using UnityEngine;

namespace DefaultNamespace
{
    
    [CreateAssetMenu(fileName = "LevelDescriptionCollection", menuName = "LevelDescriptionCollection")]
    public class LevelDescriptionCollection : ScriptableObject
    {
        [SerializeField] private LevelDescription[] _levelDescriptions;

        public bool TryGetDescription(int id, out LevelDescription outDescription)
        {
            foreach (LevelDescription description in _levelDescriptions)
            {
                if (description.Id.Equals(id))
                {
                    outDescription = description;
                    return true;
                }
            }

            outDescription = null;
            return false;
        }
    }
}