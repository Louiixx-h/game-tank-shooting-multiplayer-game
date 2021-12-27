using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBazuka : MonoBehaviour
{
    [SerializeField]
    private Vector2 _rotate;

    void Update()
    {
        _rotate.x += Input.GetAxis("Horizontal1");
        _rotate.y += Input.GetAxis("Vertical1");

        transform.localRotation = Quaternion.Euler(-_rotate.y, _rotate.x, 0);
    }
}
