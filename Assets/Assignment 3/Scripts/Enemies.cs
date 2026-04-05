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

                    Debug.Log(enemyAList[0]);
                }
            }
        }
    }

    public void OnStartButton()
    {
        isSpawned = true;
        startButton.SetActive(false);
    }
}