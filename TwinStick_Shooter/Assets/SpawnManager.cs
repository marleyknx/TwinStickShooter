using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [System.Serializable]
    public class WaveContent
    {
        [SerializeField] [NonReorderable] GameObject[] monsterSpawn;

        public GameObject[] GetMonsterSpawnList()
        {
            return monsterSpawn;
        }
    }

    [SerializeField] WaveContent[] Waves;
    int currentWave = 0;
    public Transform[] spawnerPoint;
    public int enemiesKilled;
    public List<GameObject> currentMonster;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWaves();
    }

    // Update is called once per frame
    void Update()
    {
       if(currentMonster.Count == 0)
        { 
            
            currentWave++;
            SpawnWaves();
        }

    }


    void SpawnWaves()
    {
        for (int i = 0; i < Waves[currentWave].GetMonsterSpawnList().Length; i++)
        {
           GameObject newSpawn = Instantiate(Waves[currentWave].GetMonsterSpawnList()[i], spawnerPoint[i].position, Quaternion.identity);

            currentMonster.Add(newSpawn);

            Enemy monster = newSpawn.GetComponent<Enemy>();
            monster.SetSpawner(this);
        }
    }
}
