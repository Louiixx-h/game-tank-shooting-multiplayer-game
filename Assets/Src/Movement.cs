using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private CharacterController _controller;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _speedRotate;

    void Update()
    {
        Vector3 move = new Vector3(0f, -1f, Input.GetAxis("Vertical"));
        Vector3 rotation = new Vector3(0f, Input.GetAxis("Horizontal"), 0f);
       
        move = transform.TransformDirection(move);

        _controller.Move(move * Time.deltaTime * _speed);
        transform.Rotate(rotation * Time.deltaTime * _speedRotate);
    }
}
