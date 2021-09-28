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

    // Start is called before the first frame update
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");        
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

    }
}
