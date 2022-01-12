using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Src.Gameplay
{
    public class HealthPlayer : MonoBehaviour
    {
        [SerializeField] private float _maxLife = 100f;
        [SerializeField] private float _currentyLife;
        [SerializeField] private Image _spriteLife;
        [SerializeField] private PhotonView _photonView;

        void Start()
        {
            if (!_photonView.IsMine) return;
            ChangeLifePlayer(_maxLife);
        }

        public void ChangeLifePlayer(float value)
        {
            _currentyLife += value;
            _spriteLife.fillAmount = _currentyLife / 100f;
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