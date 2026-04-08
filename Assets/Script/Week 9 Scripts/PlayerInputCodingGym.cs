using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class PlayerInputCodingGym : MonoBehaviour
{
    public Vector2 directionalInput;
    public Vector2 lookVector;
    public float speed = 1;
    public GameObject barrel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position += (Vector3)directionalInput * speed * Time.deltaTime;
      
        rotateWithTranUp();

    }
     void rotateWithDir(){
         // using rotation
       /* Vector3 rot = barrel.transform.eulerAngles;
        rot.z = lookVector.x * -360;
        Debug.Log(rot.z);
        barrel.transform.eulerAngles = rot;*/
    }
    void rotateWithTranUp(){
        barrel.transform.up = (Vector3)lookVector.normalized;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        directionalInput = context.ReadValue<Vector2>();
    }
    public void Onlook(InputAction.CallbackContext context)
    {
        lookVector = context.ReadValue<Vector2>();
    }
}
