using System;
using Modules.Health;
using UnityEngine;

namespace DefaultNamespace
{
    public class ClickAttacker : MonoBehaviour
    {
        [SerializeField] private float _damage = 1f;
        public AttackBehavior AttackBehavior = new SingleHitAttackBehavior();
        
        private Camera _camera;

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
                        AttackBehavior.Attack(_damage, damageable);
                    }
                }
            }
        }
        
    }
}