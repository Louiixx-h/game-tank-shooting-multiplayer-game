using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyExplosion());
    }

    public void PlayExplosion()
    {
        GetComponent<ParticleSystem>().Play();
        DestroyExplosion();
    }

    IEnumerator DestroyExplosion()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        yield return null;
    }
}
