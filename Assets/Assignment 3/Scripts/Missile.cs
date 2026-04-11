using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;

public class Missile : MonoBehaviour
{
    public float missileSpeed;
    public GameObject enemySpawner;
    public SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * missileSpeed;
        Enemies enemyScriptList = enemySpawner.GetComponent<Enemies>();

        for (int i = 0; i < enemyScriptList.enemyAList.Count; i++)
        {
            Debug.Log("For loop working" + i);

            if (enemyScriptList.enemyAList[i] != null)
                {
                SpriteRenderer enemyASprite = enemyScriptList.enemyAList[i].GetComponent<SpriteRenderer>();
                GameObject enemyAGameObject = enemyScriptList.enemyAList[i];

                bool isEnemyAHit = spriteRenderer.bounds.Contains(enemyAGameObject.transform.position);

                if (Vector3.Distance(transform.position, enemyScriptList.enemyAList[i].transform.position) <= 0.5f)
                {
                    Debug.Log("Bool working");

                    enemyScriptList.enemyAList[i].SetActive(false);
                    enemyScriptList.enemyAList.RemoveAt(i);
                }
            }
        }

        Vector3 missilePosition = Camera.main.WorldToScreenPoint(transform.position);

        if (missilePosition.y > Screen.height)
        {
            Destroy(gameObject);
        }
    }
}
