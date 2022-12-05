using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float minSpawnRate = 2.5f;
    public float maxSpawnRate = 6.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Execute the coroutine
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Create coroutine to spawn enemies every 5 seconds
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnRate, maxSpawnRate));

            //Spawn an enemy according to the rarity
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);
            int probability = Random.Range(0, 100);
            //Set random position for enemy to spawn at 5 units above the spawner
            Vector3 spawnPosition = new Vector3(this.transform.position.x + Random.Range(-2, 2), this.transform.position.y + Random.Range(-3, 6), this.transform.position.z);
            
            if (enemyPrefabs[randomEnemy].GetComponent<EnemyBehaviour>().rarity == 1)
            {
                if (probability < 80)
                {
                    //Spawn enemy at random position
                    Instantiate(enemyPrefabs[randomEnemy], spawnPosition, Quaternion.identity);
                }else{
                    //Spawn enemy at random position
                    Instantiate(enemyPrefabs[0], spawnPosition, Quaternion.identity);
                }
            }
            else if (enemyPrefabs[randomEnemy].GetComponent<EnemyBehaviour>().rarity == 2)
            {
                if (probability < 50)
                {
                    //Spawn enemy at random position
                    Instantiate(enemyPrefabs[randomEnemy], spawnPosition, Quaternion.identity);
                }else{
                    //Spawn enemy at random position
                    Instantiate(enemyPrefabs[0], spawnPosition, Quaternion.identity);
                }
            }
            else if (enemyPrefabs[randomEnemy].GetComponent<EnemyBehaviour>().rarity == 3)
            {
                if (probability < 20)
                {
                    //Spawn enemy at random position
                    Instantiate(enemyPrefabs[randomEnemy], spawnPosition, Quaternion.identity);
                }else{
                    //Spawn enemy at random position
                    Instantiate(enemyPrefabs[0], spawnPosition, Quaternion.identity);
                }
            }
        }
    }
}
