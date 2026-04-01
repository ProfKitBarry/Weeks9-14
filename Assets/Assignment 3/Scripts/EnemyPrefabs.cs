using UnityEngine;
using UnityEngine.UIElements;

public class EnemyPrefabs : MonoBehaviour
{
    public float speed;
    public Vector3 position;
    public float moveAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    }
}
