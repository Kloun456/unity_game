using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [Header("Enemies")]   
    public GameObject lookPointEnemy;
    public GameObject[] enemyTypes;
    public List<Transform> enemySpawners;
    public int enemyCount;

    public float intervalSpawn;
    private float timerSpawnEnemies;
    private float counterEnemy;

    private bool isEnemySpawned;
    private int LookXEnemy;
    private int LookYEnemy;

    [HideInInspector] public List<GameObject> enemies;

    void Start()
    {
        isEnemySpawned = true;
        timerSpawnEnemies = intervalSpawn;
        counterEnemy = 0;
    }   

    void FixedUpdate()
    {
        timerSpawnEnemies -= Time.deltaTime;

        if (isEnemySpawned) {
            if (timerSpawnEnemies < 0 && counterEnemy < enemyCount) {
                var spawner = enemySpawners[Random.Range(0, enemySpawners.Count)];
                
                SpawnController spawn = spawner.GetComponent<SpawnController>();
                enemySpawners.Remove(spawner);
                GameObject enemyType = enemyTypes[Random.Range(0, enemyTypes.Length)];
                GameObject enemy = Instantiate(enemyType, spawner.position, Quaternion.identity) as GameObject; // что такое Quaternion
                Ship1Controller enemyController = enemy.GetComponent<Ship1Controller>();
                enemyController.LookX = spawn.LookXEnemy;
                enemyController.LookY = spawn.LookYEnemy;
                Debug.Log(enemy);
                //enemyController.direction = spawn.direction;
                enemyController.isVertical = spawn.isVertical;
                enemy.transform.parent = transform;
                enemies.Add(enemy);
                




                timerSpawnEnemies = intervalSpawn;
                counterEnemy++;
            }
            if (counterEnemy >= enemyCount)
                isEnemySpawned=false;
        }
        
    }
}
