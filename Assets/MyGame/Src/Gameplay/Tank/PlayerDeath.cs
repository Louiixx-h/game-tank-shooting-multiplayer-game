using Src.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject m_Explosion;
    public GameObject m_TankRenderer;
    public GameObject m_Panel;
    public GameObject m_Particle;
    public GameObject m_TransformBox;
    public PlayerMovement m_PlayerMovement;

    public void Death()
    {
        var explosion = Instantiate(m_Explosion, transform);
        explosion.GetComponent<ParticleSystem>().Play();
        Destroy(m_TankRenderer);
        Destroy(m_Panel);
        Destroy(m_Particle);
        Destroy(m_TransformBox);
        Destroy(m_PlayerMovement);
    }
}
