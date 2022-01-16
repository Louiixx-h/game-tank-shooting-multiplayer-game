using Photon.Pun;
using UnityEngine;

namespace Src.Gameplay
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _controller;
        [SerializeField] private float _speed;
        [SerializeField] private float _speedRotate;
        [SerializeField] private PhotonView _photonView;
        [SerializeField] private Transform _gunRotation;

        void Update()
        {
            if (!_photonView.IsMine) return;
            MovementPlayer();
            TurnBazuka();
        }

        void MovementPlayer()
        {
            Vector3 move = new Vector3(0f, -1f, Input.GetAxis("Vertical"));
            Vector3 rotation = new Vector3(0f, Input.GetAxis("Horizontal"), 0f);

            move = transform.TransformDirection(move);

            _controller.Move(move * Time.deltaTime * _speed);
            transform.Rotate(rotation * Time.deltaTime * _speedRotate);
        }

        public void TurnBazuka()
        {
            if (Input.GetMouseButton(1))
            {
                float inputX = Input.GetAxis("Horizontal1");
                float inputY = Input.GetAxis("Vertical1") * -1;

                Vector3 rotation = new Vector3(inputX, inputY, 0f);

                _gunRotation.localRotation = Quaternion.Euler(-rotation.y / 2, rotation.x / 2, 0);
            }
        }
    }
}