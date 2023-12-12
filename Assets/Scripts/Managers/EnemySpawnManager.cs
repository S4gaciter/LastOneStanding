using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public static EnemySpawnManager Instance;

    public List<Transform> spawnPositions;
    public GameObject enemyObject;

    int enemiesToSpawn;
    int enemiesSpawned;
    public int enemiesActive;
    public float waveBreak;
    float spawnCooldown;
    float healthMultiplier;

    int round = 0;
    bool ongoing = false;
    private void Awake() => Instance = this;

    // Start is called before the first frame update
    void Start()
    {
        healthMultiplier = 1.0f;
        spawnCooldown = 3.0f;
        NewRound();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        if (ongoing)
        {
            Instantiate(enemyObject, GetRandomSpawn()).GetComponent<Enemy>().health *= healthMultiplier;
            enemiesSpawned++;
            enemiesActive++;
            Invoke(nameof(SpawnEnemy), spawnCooldown);
        }
        
        if (enemiesSpawned > enemiesToSpawn)
        {
            ongoing = false;
            CheckEndOfRound();
        }
    }

    void CheckEndOfRound()
    {
        if (enemiesActive == 0 && !ongoing)
        {
            Invoke(nameof(NewRound), waveBreak);
        }
        else
        {
            Invoke(nameof(CheckEndOfRound), 2.0f);
        }
    }

    Transform GetRandomSpawn()
    {
        int i;
        i = Random.Range(0, GetActiveSpawners());
        return spawnPositions[i];
    }

    int GetActiveSpawners()
    {
        int res = 0;
        for (int i = 0; i < spawnPositions.Count; i++)
        {
            if (spawnPositions[i].gameObject.activeSelf)
            {
                res++;
            }
        }
        return res;
    }

    public void NewRound()
    {
        round++;
        spawnCooldown -= 0.1f;
        spawnCooldown = Mathf.Clamp(spawnCooldown, 0.5f, 3.0f);

        healthMultiplier += 0.05f;
        enemiesSpawned = 0;
        enemiesToSpawn = round * 3 + 2;
        ongoing = true;
        SpawnEnemy();
    }
}
