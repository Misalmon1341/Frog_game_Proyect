using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject[] enemyObject;
    public Transform[] spawnPoints;
    private float timer;
    public float timeBetweenSpawns;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenSpawns )
        {
            timer = 0;
            int randomPoint = Random.Range( 0, spawnPoints.Length );
            int randomEnemy = Random.Range( 0,enemyObject.Length );
            if(randomPoint == 0)
            {
             Instantiate(enemyObject[0], spawnPoints[randomPoint].position, Quaternion.identity);
             return;
            }
            Instantiate(enemyObject[randomEnemy], spawnPoints[randomPoint].position, Quaternion.identity);
        }
    }
}
