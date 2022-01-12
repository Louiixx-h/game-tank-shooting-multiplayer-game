using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Src.Gameplay
{
    public class Shot : MonoBehaviour
    {
        [SerializeField] private GameObject _particle;
        [SerializeField] private GameObject _explosionParticle;
        [SerializeField] private PhotonView _photonView;

        private void Update()
        {
            if (!_photonView.IsMine) return;
            Shoot();
        }

        void Shoot()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ShootingRaycast();
            }
        }

        public void ShootingRaycast()
        {
            RaycastHit hitInfo;
            
            PlayFireParticle();
            SoundFiring();
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, Mathf.Infinity, LayerMask.GetMask("hittable")))
            {
                IShotHit hit = hitInfo.transform.GetComponent<IShotHit>();
                if (hit != null)
                {
                    ObjectsDamage(hit);
                }
                ExplosionOnCollision(hitInfo.point);
            }
        }

        void ObjectsDamage(IShotHit hit)
        {
            hit.Hit(transform.TransformDirection(Vector3.forward));
        }

        void ExplosionOnCollision(Vector3 pointHitted)
        {
            GameObject explosion = PhotonNetwork.Instantiate(_explosionParticle.name, pointHitted, Quaternion.identity, 0);
            explosion.GetComponent<Explosion>().PlayExplosion();
        }

        void PlayFireParticle()
        {
            GameObject fireParticle = PhotonNetwork.Instantiate(_particle.name, transform.position, transform.rotation, 0);
            fireParticle.GetComponent<Explosion>().PlayExplosion();
        }

        void SoundFiring()
        {
            gameObject.GetComponent<AudioSource>().enabled = true;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}