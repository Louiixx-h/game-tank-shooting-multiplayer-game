using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Src.Gameplay
{
    public class Shot : MonoBehaviour
    {
        public GameObject _particleFire;
        public GameObject _bullet;
        public Transform _bulletSpawn;
        public Transform _tank;

        [SerializeField] private PhotonView _photonView;

        private void Update()
        {
            if (!_photonView.IsMine) return;
            Shoot();
        }

        void Shoot()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shooting();
            }
        }

        public void Shooting()
        {
            Instantiate(_bullet, _bulletSpawn.position, _tank.rotation);
            SoundFiring();
            PlayFireParticle();
        }

        void PlayFireParticle()
        {
            GameObject fireParticle = Instantiate(_particleFire, _bulletSpawn);
            fireParticle.GetComponent<Explosion>().PlayExplosion();
        }

        void SoundFiring()
        {
            gameObject.GetComponent<AudioSource>().enabled = true;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}