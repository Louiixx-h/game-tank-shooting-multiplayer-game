using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Src.Gameplay
{
    public class RotateBazuka : MonoBehaviour
    {
        [SerializeField] private Vector2 _rotate;
        [SerializeField] private PhotonView _photonView;

        void Update()
        {
            if (!_photonView.IsMine) return;
            TurnBazuka();
        }

        void TurnBazuka()
        {
            if (Input.GetMouseButton(1))
            {
                _rotate.x += Input.GetAxis("Horizontal1");
                _rotate.y += Input.GetAxis("Vertical1") * -1;

                transform.localRotation = Quaternion.Euler(-_rotate.y / 2, _rotate.x / 2, 0);
            }
        }
    }
}