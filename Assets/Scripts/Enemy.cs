using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform spawnAtRunTime;
    private void OnParticleCollision(GameObject other)
    {
        GameObject VFX = Instantiate(deathVFX, transform.position, Quaternion.identity);
        VFX.transform.parent = spawnAtRunTime;

        Destroy(gameObject);
    }
}
