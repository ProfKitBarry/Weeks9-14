using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KnightScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource walk;
    public float speed;
    public Animator knightAnimator;
    private float movement;
    public List<AudioClip> FootstepSounds = new List<AudioClip>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveDir = context.ReadValue<Vector2>();
        float xMovement = moveDir.x;
        movement = xMovement;
        bool isRunning = xMovement != 0;
        knightAnimator.SetBool("IsRunning", isRunning);

    }
    public void OnFootstep()
    {
        int random = Random.Range(0, FootstepSounds.Count);
        walk.clip = FootstepSounds[random];
        walk.Play();
    }
}
