using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    public Transform m_BoxTranform;
    public GameObject m_BoxStatic;

    public delegate void CollectItemHandler(string key, GameObject item);
    public event CollectItemHandler OnCollectItem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            if (other.CompareTag("Box"))
            {
                Destroy(other.gameObject);
                var box = Instantiate(m_BoxStatic, m_BoxTranform);
                box.transform.parent = m_BoxTranform;
                box.GetComponent<MeshCollider>().isTrigger = false;
                CollectedItem("Box", box);
            }
        }
    }

    public void CollectedItem(string key, GameObject item)
    {
        OnCollectItem.Invoke(key, item);
    }
}
