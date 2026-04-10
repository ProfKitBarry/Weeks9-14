using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class Enemies : MonoBehaviour
{
    //ENEMY A
    public List<GameObject> enemyAList = new List<GameObject>();
    public GameObject enemyAPrefab;

    public Vector3 enemyASpawnPosition;
    public int enemyASpawnDistance;

    public AnimationCurve movingOntoScreenCurve;
    public float duration;
    public float progress = 0f;

    public float durationDive;
    public float progressDive = 0f;
    //All Enemies
    public bool isSpawned;

    public float spawnMax;

    public GameObject startButton;

    public Coroutine moveOntoScreenCoroutine;
    public Coroutine EnemyADiveCoroutine;

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
        if (isSpawned == true)
        {
            while (enemyAList.Count < 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    GameObject newEnemyA = Instantiate(enemyAPrefab, enemyASpawnPosition += new Vector3(enemyASpawnDistance, 0, 0), Quaternion.identity);
                    enemyAList.Add(newEnemyA);

                    EnemyAPrefab enemyScript = newEnemyA.GetComponent<EnemyAPrefab>();
                    spawnMax = enemyScript.maxMoveLength;

                    Debug.Log(enemyAList[0]);
                }
            }
        }
    }

    public void OnStartButton()
    {
        isSpawned = true;
        startButton.SetActive(false);

        moveOntoScreenCoroutine = StartCoroutine(MoveOntoScreenUpdate());
    }

    private IEnumerator MoveOntoScreenUpdate()
    {
        while (progress < duration)
        {
            //Debug.Log("is working" + enemyAList[0]);
            progress += Time.deltaTime;
                        
            yield return null;
        }
        if (progress > duration)
        { 
            Debug.Log("is working");
            EnemyADiveCoroutine = StartCoroutine(EnemyADiveUpdate());
            yield return EnemyADiveCoroutine;
        }

    }

    private IEnumerator EnemyADiveUpdate()
    {
        Vector3 newSpawnPoint = Vector3.zero;
        newSpawnPoint.y = spawnMax;
        Vector3 worldPositionPrefab = Camera.main.ScreenToWorldPoint(newSpawnPoint);

            
        for (int i = 0; i < enemyAList.Count; i++)
        {

        progressDive = 0f;

            while (progressDive < durationDive)
            {
                if (enemyAList[i] != null)
                {
                    progressDive += Time.deltaTime;
                    //Vector3 startingPosition = enemyAList[0].transform.position;
                    Vector3 position = Camera.main.ScreenToWorldPoint(enemyAList[i].transform.position);
                    position.x = enemyAList[i].transform.position.x;
                    position.y = 2.5f - movingOntoScreenCurve.Evaluate(progressDive / durationDive);
                    position.z = 0f;
                    enemyAList[i].transform.position = position;
                }

                yield return null;
            }
        }
    }
}