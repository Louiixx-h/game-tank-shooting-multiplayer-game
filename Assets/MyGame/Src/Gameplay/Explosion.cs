using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private PhotonView _PhotonView;

    private void Start()
    {
        StartCoroutine(DestroyExplosion());
        PlayExplosion();
    }

    public void PlayExplosion()
    {
        GetComponent<ParticleSystem>().Play();
        DestroyExplosion();
    }

    IEnumerator DestroyExplosion()
    {
        yield return new WaitForSeconds(2f);
        _PhotonView.RPC("DestroyExplosionGameObject", RpcTarget.AllViaServer);
        yield return null;
    }

    [PunRPC]
    void DestroyExplosionGameObject()
    {
        Destroy(gameObject);
    }
}
