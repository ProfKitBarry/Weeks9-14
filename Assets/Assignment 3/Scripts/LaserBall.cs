using UnityEngine;

public class LaserBall : MonoBehaviour
{
    public AnimationCurve laserCurve;

    public Vector3 laserBallPosition;
    
    public float laserBallSpeed;
    public float laserBallPathProgress;
    public float laserBallPathDuration;

    void Start()
    {

    }

    void Update()
    { 
        laserBallPathProgress += Time.deltaTime;

        laserBallPosition = transform.position;

        laserBallPosition.y += Time.deltaTime * laserBallSpeed;
        laserBallPosition.x += laserCurve.Evaluate(1);
        laserBallPosition.z = 0f;

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.y > Screen.height + 20)
        {
            Destroy(gameObject);
        }

        transform.position = laserBallPosition;
    }
}
