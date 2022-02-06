using Photon.Pun;
using Src.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private PlayerDeath _PlayerDeath;
    [SerializeField] private PlayerHealth _PlayerHealth;
    [SerializeField] private CollectItems _PlayerCollectItems;
    [SerializeField] private PlayerInventory _PlayerInventory;

    void Start()
    {
        if (!_photonView.IsMine) return;
        EventRegistration();
    }

    void EventRegistration()
    {
        _PlayerHealth.OnPlayerHealthEqualsZero += _PlayerDeath.Death;
        _PlayerCollectItems.OnCollectItem += _PlayerInventory.Save;
    }
}
