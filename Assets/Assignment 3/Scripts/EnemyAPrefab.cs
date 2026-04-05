using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;

public class EnemyAPrefab : MonoBehaviour
{
    public Vector3 position;

    public float speed;

    public float moveAmount;

    public bool isEnemySpawned;

    public float progressMove;
    public float durationMove;

    public float progressDive;
    public float durationDive;

    public float diveSpeed;

    public Coroutine moveOntoScreenCoroutine;
    public Coroutine enemyADiveCoroutine;

    public Enemies enemiesScript;

    void Start()
    {

    }

    void Update()
    {

    }

    public IEnumerator MoveOntoScreenUpdate()
    {
        Debug.Log("is working");

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        while (progressMove < durationMove)
        {
            progressMove += Time.deltaTime;
            transform.position -= Time.deltaTime * speed * new Vector3(0, 1, 0);

            yield return null;
        }
        enemyADiveCoroutine = StartCoroutine(enemiesScript.EnemyADiveUpdate());
        yield return enemyADiveCoroutine;
        
    }
}
