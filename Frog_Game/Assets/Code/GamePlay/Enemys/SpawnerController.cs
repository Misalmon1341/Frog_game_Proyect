using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerController : MonoBehaviour
{
    public GameObject[] enemyObject;
    public Transform[] spawnPoints;
    private float timer;
    public float timeBetweenSpawns;

    private void Start()
    {
        GameManager.Instance.speedMultiplier = 0;
    }

    private void Update()
    {
        GameManager.Instance.speedMultiplier += Time.deltaTime * 0.02f;
        timer += Time.deltaTime;
        if (timer > timeBetweenSpawns )
        {
            timer = 0;
            int randomPoint = Random.Range( 0, spawnPoints.Length );
            int randomEnemy = Random.Range( 0,enemyObject.Length  );
            Instantiate(enemyObject[randomEnemy], spawnPoints[randomPoint].position, Quaternion.identity);
        }
    }
}
