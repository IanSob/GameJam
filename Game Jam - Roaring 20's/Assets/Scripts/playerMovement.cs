using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rbplayer;
    public float speed = 5;
    private float vertical;
    private float horizontal;
    private float rotation = 90;
    public Animator playerAnimation;
    AudioSource audioSrc;
    bool leftMoving = false;
    bool upMoving = false;
    private GameObject cam;

    private void Start()
    {
        cam = GameObject.Find("Camera");
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        playerAnimation.SetFloat("Speed", Mathf.Abs(rbplayer.velocity.x) + Mathf.Abs(rbplayer.velocity.y));
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rbplayer.velocity = new Vector2(rbplayer.velocity.x, speed * vertical);
        rbplayer.velocity = new Vector2(speed * horizontal, rbplayer.velocity.y);
        transform.rotation = Quaternion.Euler(0, 0, rotation);

        if (vertical > 0 && horizontal > 0)
        {
            rotation = 45;
        }
        else if (vertical > 0 && horizontal < 0)
        {
            rotation = 135;
        }
        else if(vertical > 0 && horizontal == 0)
        {
            rotation = 90;
        }
        else if(vertical == 0 && horizontal > 0)
		{
            rotation = 0;
		}
        else if(vertical == 0 && horizontal < 0)
		{
            rotation = 180;
		}
        else if(vertical < 0 && horizontal > 0)
		{
            rotation = -45;
		}
        else if(vertical < 0 && horizontal < 0)
		{
            rotation = -135;
		}
        else if(vertical < 0 && horizontal == 0)
		{
            rotation = -90;
		}

        if (rbplayer.velocity.x != 0)
        {
            leftMoving = true;
        }
        else
        {
            leftMoving = false;
        }//checks for horizontal movement

        if (vertical != 0) 
        {
            upMoving = true;
        }
        else
        {
            upMoving = false;
        }//checks for vertical movement

        if (upMoving)
        {
            if (!audioSrc.isPlaying)
                audioSrc.Play();
        }
        else
        {
            audioSrc.Stop();
        }


        //plays audio when moving
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Camera Blackout")
        {
            cam.GetComponent<CameraMovement>().SetCam(new Vector3(other.transform.position.x, other.transform.position.y, -10), other.transform.localScale.x, other.transform.localScale.y);
            other.GetComponent<SpriteRenderer>().enabled = false;
        }      
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Camera Blackout")
        {
            other.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
