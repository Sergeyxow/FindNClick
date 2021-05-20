using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class JumpInsideAreaComponent : MonoBehaviour
    {
        [SerializeField] public bool CanMove = true;
        [SerializeField] private bool _moveBoundsWithParent = false;
        [SerializeField] private Vector2 _bounds;
        [SerializeField] private Transform _target;

        private Vector2 _centerAtStart;
        private bool _started;

        private void Start()
        {
            _centerAtStart = transform.position;
            _started = true;
        }

        public void Jump()
        {
            if (!CanMove)
                return;
            
            Vector2 center =  _moveBoundsWithParent ? (Vector2) transform.position : _centerAtStart;
            _target.position = GetRandomPoint(center, _bounds);
        }

        private Vector2 GetRandomPoint(Vector2 center, Vector2 bounds)
        {
            Vector2 half = bounds / 2;
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