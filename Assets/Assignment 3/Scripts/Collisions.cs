using UnityEngine;

public class Collisions : MonoBehaviour
{
    public SpriteRenderer enemyA;
    public SpriteRenderer missileRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        missileRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isEnemyAHit = missileRenderer.bounds.Contains(enemyA.transform.position);

        if (isEnemyAHit)
        {
            Debug.Log("Hit");

            Destroy(gameObject);
        }
    }
}
