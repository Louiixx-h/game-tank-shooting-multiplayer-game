using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Src
{
    public class ObjectHittable : MonoBehaviour, IShotHit
    {
        private Rigidbody _rigidbody;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void IShotHit.Hit(Vector3 direction)
        {
            _rigidbody.AddForce(Vector3.Scale(direction, new Vector3(50, 100, 50))*10);
        }
    }
}