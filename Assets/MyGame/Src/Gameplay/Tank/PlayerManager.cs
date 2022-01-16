using Src.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerDeath m_PlayerDeath;
    [SerializeField] private PlayerHealth m_PlayerHealth;
    [SerializeField] private CollectItems m_PlayerCollectItems;
    [SerializeField] private PlayerInventory m_PlayerInventory;

    void Start()
    {
        EventRegistration();
    }

    void EventRegistration()
    {
        m_PlayerHealth.OnPlayerHealthEqualsZero += m_PlayerDeath.Death;
        m_PlayerCollectItems.OnCollectItem += m_PlayerInventory.Save;
    }
}
