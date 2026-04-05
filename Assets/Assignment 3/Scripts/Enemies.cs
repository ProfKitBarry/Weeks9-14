using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class Enemies : MonoBehaviour
{
    //ENEMY A
    public List<GameObject> enemyAList = new List<GameObject>();
    public GameObject enemyAPrefab;

    public Vector3 enemyASpawnPosition;
    public int enemyASpawnDistance;

    //All Enemies
    public bool isSpawned;

    public GameObject startButton;

    //sedjuiksc
    public float progressDive;
    public float durationDive;

    public float diveSpeed;

    public Coroutine spawnEnemyACoroutine;
    public Coroutine moveOntoScreenCoroutine;
    public Coroutine enemyAMoveCoroutine;

    public EnemyAPrefab enemyAPrefabScript;
    void Start()
    {
        //newEnemyA = Instantiate(enemyAPrefab, enemyASpawnPosition += new Vector3(enemyASpawnDistance, 0, 0), Quaternion.identity);

        //GameObject newEnemyA1 = Instantiate(enemyAPrefab, enemyASpawnPosition, Quaternion.identity);
        //GameObject newEnemyA2 = Instantiate(enemyAPrefab, enemyASpawnPosition, Quaternion.identity);
        //GameObject newEnemyA3 = Instantiate(enemyAPrefab, enemyASpawnPosition, Quaternion.identity);
        //GameObject newEnemyA4 = Instantiate(enemyAPrefab, enemyASpawnPosition, Quaternion.identity);
        //GameObject newEnemyA5 = Instantiate(enemyAPrefab, enemyASpawnPosition, Quaternion.identity);
    }

    void Update()
    {
        
    }

    public void OnStartButton()
    {
        isSpawned = true;
        startButton.SetActive(false);

        spawnEnemyACoroutine = StartCoroutine(EnemySpawnUpdate());
    }

    public IEnumerator EnemySpawnUpdate()
    {
        if (isSpawned == true)
        {
            while (enemyAList.Count < 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    GameObject newEnemyA = Instantiate(enemyAPrefab, enemyASpawnPosition += new Vector3(enemyASpawnDistance, 0, 0), Quaternion.identity);
                    enemyAList.Add(newEnemyA);

                    Debug.Log(enemyAList[0]);

                    yield return null;
                }
            }
        }

        enemyAMoveCoroutine = StartCoroutine(enemyAPrefabScript.MoveOntoScreenUpdate());
        yield return enemyAMoveCoroutine;
    }

    public IEnumerator EnemyADiveUpdate()
    {
        while (progressDive < durationDive)
        {
            Debug.Log("dive is working");
            progressDive += Time.deltaTime;

            enemyAList[0].transform.position -= Time.deltaTime * diveSpeed * new Vector3(0, 1, 0);

            yield return null;
        }
    }
}