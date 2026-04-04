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

    public Coroutine FirstEnemyAUpdate;

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
        if (enemyAList.Count < 5)
        {
            isSpawned = true;

            if (isSpawned == true)
            {
                for (int i = 0; i < 5; i++)
                {
                    newEnemyA = Instantiate(enemyAPrefab, enemyASpawnPosition += new Vector3(enemyASpawnDistance, 0, 0), Quaternion.identity);
                    enemyAList.Add(newEnemyA);
                }


                isSpawned = false;
            }
        }
    }

    public IEnumerator FirstEnemyA()
    {

        yield return null;
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