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
    private GameObject newEnemyA;
    public EnemyAPrefab enemyAScript;

    public Vector3 enemyASpawnPosition;
    public int enemyASpawnDistance;

    //All Enemies
    public bool isSpawned;

    //ENEMY A COROUTINE
    public Coroutine enemyACoroutine;
    public Coroutine enemyATimerCoroutine;
    public Coroutine enemyAAttackCoroutine;
    public float enemyAAttackSpeed;

    public float enemyAStartAttackDuration;
    public float enemyAStartAttackProgress;

    public float progress;
    public  float duration;

    public GameObject startButton;

    //EnemyAPrefabioesnka
    public Vector3 position;

    public float speed;

    public float moveAmount;

    public bool isEnemySpawned;



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
        enemyACoroutine = StartCoroutine(EnemiesSpawnUpdate());
        startButton.SetActive(false);
    }

    private IEnumerator EnemiesSpawnUpdate()
    {
        while (enemyAList.Count < 5)
        {
            for (int i = 0; i < 5; i++)
            {
                newEnemyA = Instantiate(enemyAPrefab, enemyASpawnPosition += new Vector3(enemyASpawnDistance, 0, 0), Quaternion.identity);
                enemyAList.Add(newEnemyA);
            }
            
            yield return null;
        }

        enemyATimerCoroutine = StartCoroutine(EnemyAAttackUpdate());
        yield return enemyATimerCoroutine;
    }

    private IEnumerator EnemyAAttackUpdate()
    {
        //Debug.Log("does this work");

        while (progress < duration)
        {
            progress += Time.deltaTime;
            //enemyAList[0].transform.position -= Time.deltaTime * new Vector3(0, 1, 0);            
        
            yield return null;
        }
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