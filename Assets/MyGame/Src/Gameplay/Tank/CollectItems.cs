using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviourPun
{
    [SerializeField] private PhotonView _photonView;

    public Transform m_BoxTranform;
    public GameObject m_BoxStatic;

    public delegate void CollectItemHandler(string key, GameObject item);
    public event CollectItemHandler OnCollectItem;

    private void OnTriggerEnter(Collider other)
    {
        if (!_photonView.IsMine) return;
        if (other.gameObject.layer == 6)
        {
            if (other.CompareTag("Box"))
            {
                _photonView.RPC("CollectItem", RpcTarget.AllBuffered, other.gameObject);
            }
        }
    }

    [PunRPC]
    void CollectItem(GameObject item)
    {
        Destroy(item);
        var box = PhotonNetwork.Instantiate(m_BoxStatic.name, m_BoxTranform.position, Quaternion.identity, 0);
        box.transform.parent = m_BoxTranform;
        box.GetComponent<MeshCollider>().isTrigger = false;
        CollectedItem("Box", box);
    }

    public void CollectedItem(string key, GameObject item)
    {
        OnCollectItem.Invoke(key, item);
    }
}
