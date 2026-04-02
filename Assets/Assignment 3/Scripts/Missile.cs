using System.Reflection;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public SpriteRenderer enemyASprite;
    public SpriteRenderer missileSprite;

    public GameObject newEnemyA;

    public EnemyAPrefab enemyAPrefab;
    public Enemies enemiesScript;

    public float missileSpeed;

    public bool isHit;

    void Start()
    {
        missileSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * missileSpeed;

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.y > Screen.height + 20)
        {
            Destroy(gameObject);
        }

        EnemyAHit();
    }

    public void EnemyAHit()
    {
        isHit = enemyASprite.bounds.Contains(transform.position);

        if (isHit)
        {
            Debug.Log("Missile Hit");
            //Debug.Log(transform.position);
            Debug.Log(newEnemyA.transform.position);

            Destroy(gameObject);
        }
    }
}
