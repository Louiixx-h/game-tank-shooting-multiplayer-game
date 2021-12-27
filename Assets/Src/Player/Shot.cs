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
        private GameObject _explosionParticle;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                ShootRaycast();
            }
        }

        public void ShootRaycast()
        {
            RaycastHit hitInfo;
            
            PlayFireParticle();
            SoundFiring();
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, Mathf.Infinity, LayerMask.GetMask("hittable")))
            {
                IShotHit hit = hitInfo.transform.GetComponent<IShotHit>();
                if (hit != null)
                {
                    hit.Hit(transform.TransformDirection(Vector3.forward));
                }
                ExplosionOnCollision(hitInfo.point);
            }
        }

        void ExplosionOnCollision(Vector3 pointHitted)
        {
            GameObject explosion = Instantiate(_explosionParticle, pointHitted, Quaternion.identity);
            explosion.GetComponent<Explosion>().PlayExplosion();
        }

        void PlayFireParticle()
        {
            _particle.Play();
        }

        void SoundFiring()
        {
            gameObject.GetComponent<AudioSource>().enabled = true;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}