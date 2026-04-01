using UnityEngine;

public class EnemyBPrefab : MonoBehaviour
{
    public float speed;
    public Vector3 position;
    public float moveAmount;

    //Enemy A
    public SpriteRenderer enemyBSprite;
    public GameObject enemyBPrefab;

    public SpriteRenderer missile;

    public bool isEnemyAHit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyBSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;

        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.y > Screen.height - (moveAmount * 10))
        {
            position.y -= Time.deltaTime * speed;
        }

        transform.position = position;

        isEnemyAHit = missile.bounds.Contains(transform.position);

        if (isEnemyAHit)
        {
            Debug.Log("EnenmyA Hit");

            //Destory(gameObject);
        }
    }
}
