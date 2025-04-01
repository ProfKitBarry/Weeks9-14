using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public float speed = 2;
    Animator animator;
    SpriteRenderer sr;
    public bool canRun = true;
    public AudioSource audio;
    public AudioClip[] audiolist;
    public CinemachineImpulseSource impulseSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        sr.flipX = direction < 0;

        animator.SetFloat("speed", Mathf.Abs(direction));

        if (Input.GetMouseButtonDown(0))
        {
            //audio.Play();
            animator.SetTrigger("attack");
            canRun = false;
        }
        if(canRun == true)
        {
            transform.position += transform.right * direction * speed * Time.deltaTime;
        }
    }

    public void AttackHasFinished()
    {
        canRun = true;
    }

    public void PlaySound()
    {
        Debug.Log("playsound");

        int randomNumber = Random.Range(0, audiolist.Length);
        Debug.Log(audiolist[randomNumber].name);

        audio.clip = (audiolist[randomNumber]);
        audio.Play();
        impulseSource.GenerateImpulse(0.1f);
    }

}
