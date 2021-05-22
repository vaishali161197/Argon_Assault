using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int hitPoint = 2;
    GameObject spawnAtRunTime;
    [SerializeField] int scorePerHit = 15;
    ScoreBoard scoreBoard;
    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        spawnAtRunTime = GameObject.FindWithTag("SpawnAtRunTime");
    }
    private void OnParticleCollision(GameObject other)
    {
        processHit();
        if(hitPoint < 1)
        {
            killEnemy();
        }

       
       
    }
    private void processHit()
    {
        hitPoint--;
        scoreBoard.IncreaseScore(scorePerHit);
        GameObject VFX= Instantiate(hitVFX, transform.position, Quaternion.identity);
        VFX.transform.parent = spawnAtRunTime.transform;
    }
    private void killEnemy()
    {
        GameObject VFX = Instantiate(deathVFX, transform.position, Quaternion.identity);
        VFX.transform.parent = spawnAtRunTime.transform;
        Destroy(gameObject);
    }
}

