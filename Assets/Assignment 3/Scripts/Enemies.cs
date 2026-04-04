using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemies : MonoBehaviour
{
    //ENEMY A
    public List<GameObject> enemyAList = new List<GameObject>();
    public GameObject enemyAPrefab;
    private GameObject newEnemyA;

    public Vector3 enemyASpawnPosition;
    public int enemyASpawnDistance;

    //All Enemies
    public bool isSpawned;

    public float timeToStartMovingProgress;
    public float timeToStartMovingDuration;

    //ENEMY A COROUTINE
    public Coroutine EnemyACoroutine;
    public Coroutine FirstEnemyACoroutine;
    public Coroutine FirstEnemyAMovingCoroutine;

    public GameObject startButton;
    public float enemyADiveSpeed;

    public float firstEnemyProgress;
    public float firstEnemyDuration;

    void Start()
    {
        isSpawned = true;
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
        EnemyACoroutine = StartCoroutine(SpawnEnemyUpdate());
    }

    private IEnumerator SpawnEnemyUpdate()
    {
        Debug.Log("Enemy A Coroutine Worked");

        while (enemyAList.Count < 5)
        {
            isSpawned = true;

            if (isSpawned == true)
            {
                for (int i = 0; i < 5; i++)
                {
                    newEnemyA = Instantiate(enemyAPrefab, enemyASpawnPosition += new Vector3(enemyASpawnDistance, 0, 0), Quaternion.identity);
                    enemyAList.Add(newEnemyA);
                }

                startButton.SetActive(false);

                isSpawned = false;
            }

            yield return EnemyACoroutine;
        }

        FirstEnemyACoroutine = StartCoroutine(FirstEnemyAUpdate());
        yield return FirstEnemyACoroutine;
    }

    private IEnumerator FirstEnemyAUpdate()
    {
        Debug.Log("Enemy A Timer Coroutine Worked");

        while (timeToStartMovingProgress < timeToStartMovingDuration)
        {
            
            timeToStartMovingProgress += Time.deltaTime;

            if (timeToStartMovingProgress > timeToStartMovingDuration)
            {
                FirstEnemyAMovingCoroutine = StartCoroutine(FirstEnemyAMoving());
            }

            yield return FirstEnemyAMovingCoroutine;
        }


    }
    private IEnumerator FirstEnemyAMoving()
    {
        Debug.Log("Enemy A Moving Coroutine Worked");

        firstEnemyProgress = 0f;

        GameObject firstEnemy = enemyAList[0];
        Vector3 enemyACurrentPosition = firstEnemy.transform.position;

        enemyACurrentPosition -= Time.deltaTime * enemyADiveSpeed * transform.up;

        yield return FirstEnemyAMovingCoroutine;
    }
}
//if (enemyAList.Count < 5)
//{
//    isSpawned = true;

//    if (isSpawned == true)
//    {
//        for (int i = 0; i < 5; i++)
//        {

//            enemyAList.Add(newEnemyA);
//        }


//        isSpawned = false;
//    }
//}

//enemyASpawnPosition += new Vector3(enemyASpawnDistance, 0, 0)