using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class SpawnRandomObject : MonoBehaviour
    {
        [SerializeField] private Area _area;
        [SerializeField] private GameObject[] _objects;

        [Header("Time range")] [SerializeField]
        private float _minInterval, _maxInterval;

        private float _timeLeft;

        private void Start()
        {
            _timeLeft = GetInterval();
        }

        private void Update()
        {
            if (_timeLeft <= 0f)
            {
                Spawn();
                _timeLeft = GetInterval();
            }
            else
            {
                _timeLeft -= Time.deltaTime;
            }
        }

        private void Spawn()
        {
            
            Instantiate(GetObject(), _area.GetRandomPoint(), Quaternion.identity, transform);
        }

        private GameObject GetObject()
        {
            return _objects[Random.Range(0, _objects.Length)];
        }
        
        private float GetInterval()
        {
            return Random.Range(_minInterval, _maxInterval);
        }
    }
}