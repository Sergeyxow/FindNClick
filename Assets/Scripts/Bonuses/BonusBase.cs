using DefaultNamespace;
using UnityEngine;
using Zenject;

namespace Bonuses
{
    public abstract class BonusBase : MonoBehaviour
    {
        protected LevelEvents _levelEvents;

        [Inject]
        private void Construct(LevelEvents levelEvents)
        {
            _levelEvents = levelEvents;
        }

        public abstract void OnCollected();
    }
}