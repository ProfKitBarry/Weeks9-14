using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;

public class EnemyAPrefab : MonoBehaviour
{
    public Vector3 position;

    public float speed;

    public float progressMove;
    public float durationMove;

    void Start()
    {

    }

    void Update()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        while (progressMove < durationMove)
        {
            progressMove += Time.deltaTime;
            transform.position -= Time.deltaTime * speed * new Vector3(0, 1, 0);
        }
    }
}
