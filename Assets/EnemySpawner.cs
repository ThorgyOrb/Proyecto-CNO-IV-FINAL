using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject coinPrefab;
    public float minSpawnRate = 2.5f;
    public float maxSpawnRate = 6.0f;
    private PlayerControler playerControllerScript;
    public float spawnDelay = 5;
    public float spawnInterval = 4.2f;
    // Start is called before the first frame update
    void Start()
    {
        //Execute the coroutine
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControler>();
        StartCoroutine(SpawnEnemies());
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Create coroutine to spawn enemies every 5 seconds
    IEnumerator SpawnEnemies(){
        while (!playerControllerScript.gameOver)
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
    // Spawn Coins and enemies
    void SpawnObjects (){
        // Set random spawn location and random object index
        Vector3 spawnLocation = new Vector3(15, Random.Range(1.5f, -5), 0);
        //Vector3 spawnPosition = new Vector3(this.transform.position.x + Random.Range(-2, 2), this.transform.position.y + Random.Range(-3, 6), this.transform.position.z);
        //int index = Random.Range(0, objectPrefabs.Length);

        // If game is still active, spawn new object
        if (!playerControllerScript.gameOver)
        {
            Instantiate(coinPrefab, spawnLocation, Quaternion.identity);
        }

    }
}
