using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] private PhotonView _photonView;

    void Start()
    {
        if (!_photonView.IsMine) return;
        gameObject.AddComponent<Camera>();
    }
}
