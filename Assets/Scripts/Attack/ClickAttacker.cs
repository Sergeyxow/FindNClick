using System;
using Modules.Health;
using UnityEngine;

namespace DefaultNamespace
{
    public class ClickAttacker : MonoBehaviour
    {
        [SerializeField] private float _damage = 1f;
        
        private Camera _camera;
        private AttackBehavior _attackBehavior;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = _camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 5f);

                if (hit)
                {
                    if (hit.collider.gameObject.TryGetComponent(out DamageableComponent damageable))
                    {
                        _attackBehavior.Attack(_damage, damageable);
                    }
                }
            }
        }
        
    }
}