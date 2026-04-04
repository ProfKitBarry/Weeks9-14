using System.Collections.Generic;
using UnityEngine;

public class EnemyAPrefab : MonoBehaviour
{
    public Vector3 position;

    public float speed;

    public float moveAmount;

    public bool isEnemySpawned;

    void Start()
    {
        isEnemySpawned = true;
    }

    void Update()
    {
        if (isEnemySpawned == true)
        { 
            //Moving
            position = transform.position;

            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

            if (screenPosition.y > Screen.height - (moveAmount * 10))
            {
                position.y -= Time.deltaTime * speed;
            }

            else
            {
                isEnemySpawned = false;
            }

            transform.position = position;
        }
    }
}
