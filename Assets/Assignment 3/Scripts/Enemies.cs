using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.VFX;

public class Enemies : MonoBehaviour
{
    //ENEMY A
    public List<GameObject> enemyA = new List<GameObject>(5);
    public GameObject enemyAPrefab;
    public Vector3 enemyASpawnPosition;
    public int enemyASpawnDistance;

    //ENEMY B
    public List<GameObject> enemyB = new List<GameObject>(5);
    public GameObject enemyBPrefab;
    public Vector3 enemyBSpawnPosition;
    public int enemyBSpawnDistance;

    //All Enemies
    public bool isSpawned;

    void Start()
    {
        isSpawned = true;
    }

    void Update()
    {
        if (isSpawned)
        { 
            for (int i = 0; i < 5; i++)
            {
                GameObject newEnemyA = Instantiate(enemyAPrefab, enemyASpawnPosition += new Vector3(enemyASpawnDistance, 0, 0), Quaternion.identity);

                enemyA.Add(newEnemyA);

            }

            for (int i = 0; i < 5; i++)
            {
                GameObject newEnemyB = Instantiate(enemyBPrefab, enemyBSpawnPosition += new Vector3(enemyBSpawnDistance, 0, 0), Quaternion.identity);

                enemyB.Add(newEnemyB);
            }

            isSpawned = false;
        }
    }
}