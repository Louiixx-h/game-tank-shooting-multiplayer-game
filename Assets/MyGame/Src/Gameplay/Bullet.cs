using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _bulletExplosion;
    [SerializeField] private float _bulletSpeed;

    void Update()
    {
        transform.localPosition += Vector3.forward * _bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        Destroy(gameObject);
    }
}
