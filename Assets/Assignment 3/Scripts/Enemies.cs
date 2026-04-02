using System.Collections.Generic;
using UnityEngine;


public class Enemies : MonoBehaviour
{
    //ENEMY A
    //public List<GameObject> enemyAList = new List<GameObject>();
    public GameObject enemyAPrefab;
    public Vector3 enemyASpawnPosition;
    public int enemyASpawnDistance;

    //All Enemies
    public bool isSpawned;

    void Start()
    {
        isSpawned = true;
        GameObject newEnemyA = Instantiate(enemyAPrefab, enemyASpawnPosition, Quaternion.identity);
    }

    void Update()
    {
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