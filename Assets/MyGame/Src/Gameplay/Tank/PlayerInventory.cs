using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Transform m_BoxTranform;
    public Transform m_DropBoxTranform;
    public Dictionary<string, GameObject> gameObjects = new Dictionary<string, GameObject>();

    void Update()
    {
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
                Instantiate(box, m_DropBoxTranform.position, Quaternion.identity);
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
