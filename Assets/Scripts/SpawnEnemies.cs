using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [Header("Enemies")]   
    public GameObject lookPointEnemy;
    public GameObject[] enemyTypes;
    public Transform[] enemySpawners;
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
                var spawner = enemySpawners[Random.Range(0, enemySpawners.Length)];

                SpawnController spawn = spawner.GetComponent<SpawnController>();

                GameObject enemyType = enemyTypes[Random.Range(0, enemyTypes.Length)];
                GameObject enemy = Instantiate(enemyType, spawner.position, Quaternion.identity) as GameObject; // что такое Quaternion
                Ship1Controller enemy1Controller = null;
                Ship2Controller enemy2Controller = null;
                switch (enemy.name)
                {
                    case "Ship_1(Clone)": // заменить на имя из структуры
                        enemy1Controller = enemy.GetComponent<Ship1Controller>();
                        enemy1Controller.LookX = spawn.LookXEnemy;
                        enemy1Controller.LookY = spawn.LookYEnemy;
                        break;
                    case "Ship_2(Clone)":
                        enemy2Controller = enemy.GetComponent<Ship2Controller>();
                        enemy2Controller.LookX = spawn.LookXEnemy;
                        enemy2Controller.LookY = spawn.LookYEnemy;
                        break;
                }
                Debug.Log(enemy.name);
               
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
