using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    public List<Transform> Spawns = new List<Transform>();

    public GameObject enemyParent;

    int timer;

    private void Start()
    {
        Enemies.Add(Resources.Load<GameObject>("redEnemy"));
        Enemies.Add(Resources.Load<GameObject>("blueEnemy"));
        Enemies.Add(Resources.Load<GameObject>("greenEnemy"));
        //Debug.Log(Enemies.Count);

        Spawns.Add(GameObject.Find("enemySpawns").transform.GetChild(0).transform);
        Spawns.Add(GameObject.Find("enemySpawns").transform.GetChild(1).transform);
        Spawns.Add(GameObject.Find("enemySpawns").transform.GetChild(2).transform);
        Spawns.Add(GameObject.Find("enemySpawns").transform.GetChild(3).transform);
        Spawns.Add(GameObject.Find("enemySpawns").transform.GetChild(4).transform);
        Spawns.Add(GameObject.Find("enemySpawns").transform.GetChild(5).transform);
        //Debug.Log(Spawns.Count);

        
    }

    private void FixedUpdate()
    {
        SpawnThem();

        timer = Random.Range(0, 10);
    }

    void SpawnThem()
    {
        GameObject chooseEnemy;
        chooseEnemy = Enemies[Random.Range(0, Enemies.Count)];
        Transform theSpawn;
        theSpawn = Spawns[Random.Range(0, Spawns.Count)];
        if (timer < 5)
        {
            GameObject Go = Instantiate(chooseEnemy, theSpawn.position, Quaternion.identity);
            //Debug.Log(timer);
            enemyParent = GameObject.Find("EnemyParent");
            Go.transform.parent = enemyParent.transform;
        }
    }
}
