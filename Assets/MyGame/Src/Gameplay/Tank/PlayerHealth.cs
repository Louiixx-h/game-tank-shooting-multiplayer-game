using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Src.Gameplay
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private PhotonView _photonView;

        public float _maxLife = 50f;
        public float _currentyLife;
        public Image _spriteLife;

        public delegate void PlayerHealthDelegate();
        public event PlayerHealthDelegate OnPlayerHealthEqualsZero;

        void Start()
        {
            if (!_photonView.IsMine) return;
            ChangeLifePlayer(_maxLife);
        }

        public void ChangeLifePlayer(float value)
        {
            _currentyLife += value;
            _spriteLife.fillAmount = _currentyLife / 100f;

            if (_currentyLife <= 0f)
            {
                OnPlayerHealthEqualsZero.Invoke();
                Destroy(this);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_photonView.IsMine && other.CompareTag("Bullet"))
            {
                ChangeLifePlayer(-10f);
            }
            if (_photonView.IsMine && other.CompareTag("Life"))
            {
                ChangeLifePlayer(10f);
            }
        }
    }
}