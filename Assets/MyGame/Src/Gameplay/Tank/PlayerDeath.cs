using Photon.Pun;
using Src.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviourPun
{
    [SerializeField] private PhotonView _photonView;
    public GameObject _Explosion;
    public GameObject _TankRenderer;
    public GameObject _Panel;
    public GameObject _Particle;
    public GameObject _TransformBox;
    public PlayerMovement _PlayerMovement;

    public void Death()
    {
        if (!_photonView.IsMine) return;
        _photonView.RPC("OnDeath", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void OnDeath()
    {
        PhotonNetwork.Instantiate(_Explosion.name, transform.position, transform.rotation, 0);
        Destroy(_TankRenderer);
        Destroy(_Panel);
        Destroy(_Particle);
        Destroy(_TransformBox);
        Destroy(_PlayerMovement);
    }
}
