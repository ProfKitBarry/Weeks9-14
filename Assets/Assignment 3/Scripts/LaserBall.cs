using UnityEngine;

public class LaserBall : MonoBehaviour
{
    public float laserBallSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


            transform.position += transform.up * Time.deltaTime * laserBallSpeed;

            Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

            if (screenPosition.y > Screen.height + 20)
            {
                Destroy(gameObject);
            }
        
    }
}
