using UnityEngine;

public class MovementMobile : MonoBehaviour
{
    [SerializeField]
    private CharacterController _controller;
    [SerializeField]
    private FixedJoystick _joystick;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _speedRotate;

    void Update()
    {
        Vector3 move = new Vector3(_joystick.Vertical, -1f, 0f);
        Vector3 rotation = new Vector3(0f, _joystick.Horizontal, 0f);
       
        move = transform.TransformDirection(move);

        _controller.Move(move * Time.deltaTime * _speed);
        transform.Rotate(rotation * Time.deltaTime * _speedRotate);
    }
}
