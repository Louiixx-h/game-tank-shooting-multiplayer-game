using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Src.Gameplay
{
    public class PlayerShot : MonoBehaviourPun
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
            PhotonNetwork.Instantiate(_bullet.name, _bulletSpawn.position, _bulletSpawn.rotation, 0);
            _photonView.RPC("PlayFireParticle", RpcTarget.AllViaServer);
        }

        [PunRPC]
        void PlayFireParticle()
        {
            GameObject fireParticle = Instantiate(_particleFire, _bulletSpawn);
            fireParticle.GetComponent<Explosion>().PlayExplosion();
            SoundFiring();
        }

        void SoundFiring()
        {
            gameObject.GetComponent<AudioSource>().enabled = true;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}