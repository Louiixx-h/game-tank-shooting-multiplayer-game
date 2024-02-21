using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviourPun
{
    [SerializeField] private PhotonView _photonView;

    public Transform m_BoxTranform;
    public Transform m_DropBoxTranform;
    public Dictionary<string, GameObject> gameObjects = new Dictionary<string, GameObject>();

    void Update()
    {
        if (!_photonView.IsMine) return;
        DropBox();
    }

    void DropBox()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject box;
            gameObjects.TryGetValue("Box", out box);
            if (box != null)
            {
                box.GetComponent<MeshCollider>().isTrigger = true;
                PhotonNetwork.Instantiate(box.name, m_DropBoxTranform.position, Quaternion.identity, 0);
                gameObjects.Remove("Box");
                Destroy(m_BoxTranform.GetChild(0).gameObject);
            }
        }
    }

    public void Save(string key, GameObject item)
    {
        gameObjects.Add(key, item);
    }
}
