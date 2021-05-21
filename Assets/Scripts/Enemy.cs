using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform spawnAtRunTime;
    [SerializeField] int scorePerHit = 15;
    ScoreBoard scoreBoard;
    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        processHit();
        killEnemy();
       
    }
    private void processHit()
    {
        scoreBoard.IncreaseScore(scorePerHit);
        
    }
    private void killEnemy()
    {
        GameObject VFX = Instantiate(deathVFX, transform.position, Quaternion.identity);
        VFX.transform.parent = spawnAtRunTime;
        Destroy(gameObject);
    }
}

