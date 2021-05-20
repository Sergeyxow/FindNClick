using UnityEngine;

namespace DefaultNamespace
{
    public class Area : MonoBehaviour
    {
        [SerializeField] private bool _moveBoundsWithParent = false;
        [SerializeField] private Vector2 _bounds;
        private Vector2 _centerAtStart;
        private bool _started;

        private void Start()
        {
            _centerAtStart = transform.position;
            _started = true;
        }
        public Vector2 GetRandomPoint()
        {
            Vector2 center = _moveBoundsWithParent ? (Vector2) transform.position : _centerAtStart;
            Vector2 half = _bounds / 2;
            var x = Random.Range(center.x - half.x, center.x + half.x);
            var y = Random.Range(center.y - half.y, center.y + half.y);
            return new Vector2(x, y);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.88f, 0f, 1f);
            Vector3 center;
            if (_started && !_moveBoundsWithParent)
            {
                center = _centerAtStart;
            }
            else
            {
                center = transform.position;
            }
            Gizmos.DrawWireCube(center, _bounds);
        }
    }
}