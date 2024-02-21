using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviourPun
{
    [SerializeField] private PhotonView _PhotonView;

    public GameObject _bulletExplosion;
    public float _bulletSpeed;
    public Rigidbody _Rb;

    void Update()
    {
        _Rb.AddForce(transform.forward * _bulletSpeed * Time.deltaTime, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        PhotonNetwork.Instantiate(_bulletExplosion.name, transform.position, transform.rotation, 0);
        _PhotonView.RPC("DestroyBullet", RpcTarget.AllViaServer);
    }

    [PunRPC]
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
