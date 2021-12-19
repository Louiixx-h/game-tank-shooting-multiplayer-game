using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Src.Player
{
    public class Shot : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _particle;
        
        [SerializeField]
        private GameObject _hitted;

        void FixedUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _particle.Play();
                ShootRaycast();   
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.yellow);
            }
        }

        void ShootRaycast()
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, Mathf.Infinity, LayerMask.GetMask("hittable")))
            {
                IShotHit hit = hitInfo.transform.GetComponent<IShotHit>();
                if(hit != null) hit.Hit(transform.TransformDirection(Vector3.forward));
                ExplosionOnCollision(hitInfo.point);
            }
        }

        void ExplosionOnCollision(Vector3 pointHitted)
        {
            GameObject explosion = Instantiate(_hitted, pointHitted, Quaternion.identity);
            explosion.GetComponent<Explosion>().PlayExplosion();
        }
    }
}