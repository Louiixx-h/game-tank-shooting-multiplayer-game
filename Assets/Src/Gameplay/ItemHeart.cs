using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Src.Gameplay
{
    public class ItemHeart : MonoBehaviour
    {
        [SerializeField] private PhotonView _photonView;

        void Start()
        {

        }

        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
}