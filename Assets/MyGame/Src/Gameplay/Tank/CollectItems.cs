using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    public Transform m_BoxTranform;
    public GameObject m_BoxStatic;
    public GameObject m_Box;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            var box = m_BoxTranform.GetChild(0).gameObject;
            var position = transform.position;
            position.z += (position.normalized.z * 2) * -1;
            position.y += 0.5f;
            if (box != null)
            {
                Instantiate(m_Box, position, Quaternion.identity);
                Destroy(m_BoxTranform.GetChild(0).gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            Destroy(other.gameObject);
            var box = Instantiate(m_BoxStatic, m_BoxTranform);
            box.transform.parent = m_BoxTranform;
        }
    }
}
