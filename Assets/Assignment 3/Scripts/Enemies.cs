using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.VFX;

public class Enemies : MonoBehaviour
{
    //ENEMY A
    public List<GameObject> enemyAList = new List<GameObject>(5);
    public GameObject enemyAPrefab;
    public Vector3 enemyASpawnPosition;
    public int enemyASpawnDistance;
    public GameObject newEnemyA;

    //COLLISIONS
    public SpriteRenderer enemyASprite;
    public SpriteRenderer missileSprite;

    public Missile missileScript;
    public bool isEnemyAHit;

    //ENEMY B
    public List<GameObject> enemyB = new List<GameObject>(5);
    public GameObject enemyBPrefab;
    public Vector3 enemyBSpawnPosition;
    public int enemyBSpawnDistance;

    public GameObject newEnemyB;

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
                newEnemyA = Instantiate(enemyAPrefab, enemyASpawnPosition += new Vector3(enemyASpawnDistance, 0, 0), Quaternion.identity);

                enemyAList.Add(newEnemyA);
            }

            for (int i = 0; i < 5; i++)
            {
                newEnemyB = Instantiate(enemyBPrefab, enemyBSpawnPosition += new Vector3(enemyBSpawnDistance, 0, 0), Quaternion.identity);

                enemyB.Add(newEnemyB);
            }

            isSpawned = false;
        }
    }

    public void RemoveEnemyA()
    {
        //Debug.Log(newEnemyA.transform.position);
        Debug.Log("Enemy A Hit");

        enemyAList.Remove(newEnemyA);
    }
}