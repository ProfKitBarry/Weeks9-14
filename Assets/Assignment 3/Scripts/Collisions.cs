using UnityEngine;

public class Collisions : MonoBehaviour
{
    public SpriteRenderer enemyA;
    public EnemyPrefabs enemyAScript;

    public SpriteRenderer missile;
    public Missile missileScript;

    public bool isEnemyAHit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        missile = GetComponent<SpriteRenderer>();
        
        isEnemyAHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        isEnemyAHit = missile.bounds.Contains(enemyAScript.transform.position);
        
        if (isEnemyAHit == true)
        {
            Debug.Log("Hit");

            Destroy(gameObject);
        }
    }
}
