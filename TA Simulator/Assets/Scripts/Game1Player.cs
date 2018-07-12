using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Player : MonoBehaviour
{
    public Game1Manager gameManager;
    public bool player2;

    public float moveSpeed;

	private void Update ()
	{
        if (!gameManager.gameRunning)
            return;

        if (player2 ? Input.GetKey(KeyCode.UpArrow) : Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * moveSpeed);
        }
        if (player2 ? Input.GetKey(KeyCode.DownArrow) : Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.down * moveSpeed);
        }

        if (player2 ? Input.GetKey(KeyCode.LeftArrow) : Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.left * moveSpeed);
        }
        if (player2 ? Input.GetKey(KeyCode.RightArrow) : Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.right * moveSpeed);
        }
    }
}