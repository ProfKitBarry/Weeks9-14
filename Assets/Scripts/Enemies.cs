using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class Enemies : MonoBehaviour
{
    //ALL ENEMIES
    public GameObject startButton;
    public bool isSpawned;

    //ENEMY A
    public List<GameObject> enemyAList = new List<GameObject>();
    public GameObject enemyAPrefab;
    public AnimationCurve enemyAMovingOntoScreenCurve;
    public EnemyAPrefab enemyAPrefabScript;

    public Coroutine enemyAMoveOntoScreenCoroutine;
    public Coroutine EnemyADiveCoroutine;

    public Vector3 enemyASpawnPosition;
    public int enemyASpawnDistance;

    public float durationEnemyA;
    public float progressEnemyA = 0f;

    public float durationDiveEnemyA;
    public float progressDiveEnemyA = 0f;

    public float spawnMaxEnemyA;

    //ENEMY B
    public List<GameObject> enemyBList = new List<GameObject>();
    public GameObject enemyBPrefab;
    public AnimationCurve enemyBMovingOntoScreenCurve;
    public EnemyBPrefab enemyBPrefabScript;

    public Coroutine enemyBMoveOntoScreenCoroutine;
    public Coroutine EnemyBDiveCoroutine;

    public Vector3 enemyBSpawnPosition;
    public int enemyBSpawnDistance;

    public float durationEnemyB;
    public float progressEnemyB = 0f;

    public float durationDiveEnemyB;
    public float progressDiveEnemyB = 0f;

    public float spawnMaxEnemyB;

    void Start()
    {

    }

    void Update()
    {
        if (enemyAList.Count == 0 && enemyBList.Count == 0)
        {
            isSpawned = true;
        }        
    }

    public void OnStartButton()
    {
        isSpawned = true;
        startButton.SetActive(false);

        if (isSpawned == true)
        {
            //ENEMY A
            while (enemyAList.Count < 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    GameObject newEnemyA = Instantiate(enemyAPrefab, enemyASpawnPosition += new Vector3(enemyASpawnDistance, 0, 0), Quaternion.identity);
                    enemyAList.Add(newEnemyA);

                    EnemyAPrefab enemyScriptEnemyA = newEnemyA.GetComponent<EnemyAPrefab>();
                    spawnMaxEnemyA = enemyScriptEnemyA.maxMoveLength;

                    Debug.Log(enemyAList[0]);
                }
            }

            //ENEMY B
            while (enemyBList.Count < 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    GameObject newEnemyB = Instantiate(enemyBPrefab, enemyBSpawnPosition += new Vector3(enemyBSpawnDistance, 0, 0), Quaternion.identity);
                    enemyBList.Add(newEnemyB);

                    EnemyBPrefab enemyScriptEnemyB = newEnemyB.GetComponent<EnemyBPrefab>();
                    spawnMaxEnemyB = enemyScriptEnemyB.maxMoveLength;

                    Debug.Log(enemyBList[0]);
                }
            }
        }
       
        enemyAMoveOntoScreenCoroutine = StartCoroutine(EnemyAMoveOntoScreenUpdate());
        enemyBMoveOntoScreenCoroutine = StartCoroutine(EnemyBMoveOntoScreenUpdate());
    }

    private IEnumerator EnemyAMoveOntoScreenUpdate()
    {
        while (progressEnemyA < durationEnemyA)
        {
            //Debug.Log("is working" + enemyAList[0]);
            progressEnemyA += Time.deltaTime;
                        
            yield return null;
        }
        if (progressEnemyA > durationEnemyA)
        { 
            Debug.Log("is working");
            EnemyADiveCoroutine = StartCoroutine(EnemyADiveUpdate());
            yield return EnemyADiveCoroutine;
        }
    }

    private IEnumerator EnemyADiveUpdate()
    {
        Vector3 newSpawnPoint = Vector3.zero;
        newSpawnPoint.y = spawnMaxEnemyB;
        Vector3 worldPositionPrefab = Camera.main.ScreenToWorldPoint(newSpawnPoint);


        for (int i = 0; i < enemyAList.Count; i++)
        {
            progressDiveEnemyA = 0f;

            while (progressDiveEnemyA < durationDiveEnemyA)
            {
                progressDiveEnemyA += Time.deltaTime;

                if (enemyAList[i] != null)
                {
                    //Vector3 startingPosition = enemyAList[0].transform.position;
                    Vector3 positionEnemyA = Camera.main.ScreenToWorldPoint(enemyAList[i].transform.position);
                    positionEnemyA.x = enemyAList[i].transform.position.x;
                    positionEnemyA.y = 1.5f - enemyAMovingOntoScreenCurve.Evaluate(progressDiveEnemyA / durationDiveEnemyA);
                    positionEnemyA.z = 0f;
                    enemyAList[i].transform.position = positionEnemyA;
                }
                                
                yield return null;
            }
        }                   
                        

        //for (int i = enemyAList.Count; i > 0; i--)
        //{
        //    Vector3 positionEnemyA = Camera.main.ScreenToWorldPoint(enemyAList[i].transform.position);
            
        //}
    }

    private IEnumerator EnemyBMoveOntoScreenUpdate()
    {
        while (progressEnemyB < durationEnemyB)
        {
            //Debug.Log("is working" + enemyAList[0]);
            progressEnemyB += Time.deltaTime;

            yield return null;
        }
        if (progressEnemyB > durationEnemyB)
        {
            Debug.Log("is working");
            EnemyBDiveCoroutine = StartCoroutine(EnemyBDiveUpdate());
            yield return EnemyBDiveCoroutine;
        }
    }   

    private IEnumerator EnemyBDiveUpdate()
    {
        Vector3 newSpawnPoint = Vector3.zero;
        newSpawnPoint.y = spawnMaxEnemyB;
        Vector3 worldPositionPrefab = Camera.main.ScreenToWorldPoint(newSpawnPoint);


        for (int i = 0; i < enemyBList.Count; i++)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(enemyBList[i].transform.position);
            progressDiveEnemyB = 0f;

            while (progressDiveEnemyB < durationDiveEnemyB)
            {
                progressDiveEnemyB += Time.deltaTime;

                if (enemyBList[i] != null)
                {
                    //Vector3 startingPosition = enemyAList[0].transform.position;
                    position.x = enemyBList[i].transform.position.x;
                    position.y = 3.5f - enemyBMovingOntoScreenCurve.Evaluate(progressDiveEnemyB / durationDiveEnemyB);
                    position.z = 0f;
                    enemyBList[i].transform.position = position;
                }

                yield return null;
            }
        }
    }
}