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
    public GameObject laserPrefab;

    //LASER BALL
    public float duration;
    public float progress;

    public bool canShoot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        progress = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(xDirection, 0f, 0f) * Time.deltaTime * playerMoveSpeed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 movement = context.ReadValue<Vector2>();
        xDirection = movement.x;
    }

    public void OnLeftClick(InputAction.CallbackContext context)
    {
        progress += Time.deltaTime;

        if (progress > duration)
        {
            canShoot = true;
        }

        if (canShoot)
        {
        }
        GameObject missileSpawnLeft = Instantiate(missilePrefab, transform.position + new Vector3(-missileSpawnPosition, 0, 0), Quaternion.identity);
        GameObject missileSpawnRight = Instantiate(missilePrefab, transform.position + new Vector3(missileSpawnPosition, 0, 0), Quaternion.identity);
    }
    public void OnRightClick(InputAction.CallbackContext context)
    {
        GameObject laserSpawn = Instantiate(laserPrefab, transform.position, Quaternion.identity);
    }
}
