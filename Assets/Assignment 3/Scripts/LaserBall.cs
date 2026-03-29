using Unity.Collections;
using UnityEngine;

public class LaserBall : MonoBehaviour
{
    public AnimationCurve laserCurve;

    public Vector3 laserBallPosition;
    public Vector3 laserBallSpawnPosition;
    
    public float laserBallSpeed;
    public float laserBallPathProgress;
    public float laserBallPathDuration;

    //public GameObject player;

    //public Player player;

    void Start()
    {

    }

    void Update()
    {
        laserBallPathProgress += Time.deltaTime;

        if (laserBallPathProgress > laserBallPathDuration)
        {
            laserBallPathProgress = 0f;
        }

        laserBallPosition = transform.position;

        Debug.Log(laserBallSpawnPosition.x + laserCurve.Evaluate(laserBallPathProgress / laserBallPathDuration));
        laserBallPosition.x += (laserCurve.Evaluate(laserBallPathProgress / laserBallPathDuration))/100;
        laserBallPosition.y += Time.deltaTime * laserBallSpeed;
        laserBallPosition.z = 0f;

        //laserBallSpawnPosition = new Vector3(laserBallPosition.x, laserBallPosition.y, laserBallPosition.z);
        //laserBallSpawnPosition += new Vector3(laserCurve.Evaluate(laserBallPathProgress / laserBallPathDuration), 0, 0);

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.y > Screen.height + 20)
        {
            Destroy(gameObject);
        }

        transform.position = laserBallPosition;
    }
}
