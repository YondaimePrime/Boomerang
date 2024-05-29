using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{   

    
    public TextMeshProUGUI enemiesCounter;

    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private float minimumSpawnTime;
    [SerializeField]
    private float maximumSpawnTime;

    private float timeUntilSpawn;

    private int maxEnemies = 10;
    private int currentEnemies = 0;
    
    void Awake()
    {   
        SetTimeUntilSpawn();
    }

    void Update()
    {   
        enemiesCounter.text = (currentEnemies).ToString();
        if(currentEnemies < maxEnemies) 
        {
            timeUntilSpawn -= Time.deltaTime;

            if(timeUntilSpawn <= 0)
            {
                Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
                SetTimeUntilSpawn();
                currentEnemies++;
            }
        }
    }


    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}
