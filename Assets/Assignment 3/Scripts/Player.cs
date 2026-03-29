using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //MOVEMENT
    public Vector3 playerPosition;
    public float playerMoveSpeed;
    public float xDirection;

    //MISSILE
    public float missileSpawnPosition;

    public GameObject missilePrefab;

    public float durationMissile;
    public float progressMissile;

    public bool canShootMissile;

    //LASER BALL
    public GameObject laserPrefab;

    public float durationLaser;
    public float progressLaser;


    public bool canShootLaser;
    void Start()
    {
        progressMissile = 0f;
    }

    void Update()
    {
        //PLAYER
        playerPosition = transform.position;
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
        if (progressLaser >= durationLaser)
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
