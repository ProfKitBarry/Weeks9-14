using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class Enemies : MonoBehaviour
{
    //ENEMY A
    public List<GameObject> enemyAList = new List<GameObject>();
    public GameObject enemyAPrefab;
    public Vector3 enemyASpawnPosition;
    public int enemyASpawnDistance;
    public GameObject newEnemyA;

    public EnemyAPrefab enemyAScript;

    //COLLISIONS
    public SpriteRenderer enemyASprite;
    public SpriteRenderer missileSprite;

    public Missile missileScript;
    public bool isEnemyAHit;

    //ENEMY B
    public List<GameObject> enemyBList = new List<GameObject>(5);
    public GameObject enemyBPrefab;
    public Vector3 enemyBSpawnPosition;
    public int enemyBSpawnDistance;

    private int i;

    public GameObject newEnemyB;

    //All Enemies
    public bool isSpawned;

    void Start()
    {
        isSpawned = true;
    }

    void Update()
    {
        if (enemyAList.Count < 5)
        {
            for (i = 0; i < 5; i++)
            {
                newEnemyA = Instantiate(enemyAPrefab, enemyASpawnPosition += new Vector3(enemyASpawnDistance, 0, 0), Quaternion.identity);

                enemyAList.Add(newEnemyA);
            }
            if (missileSprite.bounds.Contains(newEnemyA.transform.position))
            {
                Debug.Log("Enemy A Hit");

                enemyAList.Remove(newEnemyA);
            }
        }

        if (enemyBList.Count < 5)
        {
            for (int i = 0; i < 5; i++)
            {
                newEnemyB = Instantiate(enemyBPrefab, enemyBSpawnPosition += new Vector3(enemyBSpawnDistance, 0, 0), Quaternion.identity);

                enemyBList.Add(newEnemyB);
            }            
        }    

        missileScript.EnemyAHit();
    }
}