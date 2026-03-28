using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //MOVEMENT
    public float playerMoveSpeed;
    public float xDirection;

    //MISSILE
    public float missileSpawnPosition;

    public GameObject missilePrefab;

    public float durationMissile;
    public float progressMissile;

    public bool canShootMissile;

    //LASER BALL
    public float durationLaser;
    public float progressLaser;

    public GameObject laserPrefab;

    public bool canShootLaser;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        progressMissile = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //PLAYER
        transform.position += new Vector3(xDirection, 0f, 0f) * Time.deltaTime * playerMoveSpeed;
        
        //MISSILE
        if (progressMissile < durationMissile)
        {
            progressMissile += Time.deltaTime;            
        }

        //LASER BALL
        if (progressLaser < durationLaser)
        {
            progressLaser += Time.deltaTime;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 movement = context.ReadValue<Vector2>();
        xDirection = movement.x;
    }

    public void OnLeftClick(InputAction.CallbackContext context)
    {
        if (progressMissile >= durationMissile)
        {
            canShootMissile = true;
        }

        if (canShootMissile && Mouse.current.leftButton.wasPressedThisFrame)
        {
            GameObject missileSpawnLeft = Instantiate(missilePrefab, transform.position + new Vector3(-missileSpawnPosition, 0, 0), Quaternion.identity);
            GameObject missileSpawnRight = Instantiate(missilePrefab, transform.position + new Vector3(missileSpawnPosition, 0, 0), Quaternion.identity);

            canShootMissile = false;
            progressMissile = 0f;
        }
    }
    public void OnRightClick(InputAction.CallbackContext context)
    {
        if (progressLaser > durationLaser)
        {
            canShootLaser = true;
        }

        if (canShootLaser && Mouse.current.rightButton.wasPressedThisFrame)
        { 
            GameObject laserSpawn = Instantiate(laserPrefab, transform.position, Quaternion.identity);

            canShootLaser = false;
            progressLaser = 0f;
        }
    }
}
