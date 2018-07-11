using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Player : MonoBehaviour
{
    public Game1Manager gameManager;
    public bool player2;

    public float moveSpeed;
    //public float jumpSpeed = 25;
    //public float gravity = 50;
    //private float velocity;

	private void Update ()
	{
        //if (!gameManager.gameRunning)
            //return;

        if (player2 ? Input.GetKey(KeyCode.UpArrow) : Input.GetKey(KeyCode.W))
        {
            if(transform.position.y < 8)
                transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
        if (player2 ? Input.GetKey(KeyCode.DownArrow) : Input.GetKey(KeyCode.S))
        {
            if (transform.position.y > 0)
                transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }

        if (player2 ? Input.GetKey(KeyCode.LeftArrow) : Input.GetKey(KeyCode.A))
        {
            if (!player2)
            {
                if (transform.position.x < -8f)
                {
                    return;
                }
            }
            else
            {
                if (transform.position.x < 3.5f)
                {
                    return;
                }
            }

            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (player2 ? Input.GetKey(KeyCode.RightArrow) : Input.GetKey(KeyCode.D))
        {
            if (!player2)
            {
                if (transform.position.x > -3.5f)
                {
                    return;
                }
            }
            else
            {
                if (transform.position.x > 8f)
                {
                    return;
                }
            }

            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }

        /*
        if (player2 ? Input.GetKeyDown(KeyCode.UpArrow) : Input.GetKeyDown(KeyCode.W))
        {
            if (transform.position.y == 0)
            {
                Jump();
            }
        }

        velocity -= gravity * Time.deltaTime;
        Vector2 nextPosition = transform.position + Vector3.up * velocity * Time.deltaTime;

        if (nextPosition.y < 0)
        {
            velocity = 0;
            nextPosition = new Vector2(nextPosition.x, 0);
        }

        transform.position = nextPosition;
        */
    }

    /*
private void Jump()
{
    velocity = jumpSpeed;
    transform.position += Vector3.up * 0.1f;
}
    */
}