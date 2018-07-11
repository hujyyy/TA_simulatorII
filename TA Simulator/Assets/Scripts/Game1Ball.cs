using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Ball : MonoBehaviour
{
    public Game1Manager gameManager;

    public Vector2 velocity;
    public float speed;

    public void Update()
    {
        //if (!gameManager.gameRunning)
            //return;

        transform.Translate(velocity * speed * Time.deltaTime, Space.World);
        speed += Time.deltaTime / 4;
    }

    public void StartKick()
    {
        velocity = Vector2.left + Vector2.up * Random.Range(-1f, 1f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "top border" || col.tag == "bot border")
        {
            velocity = new Vector2(velocity.x, -velocity.y);
        }
        if (col.tag == "top paddle")
        {
            velocity = new Vector2(transform.position.x < 0 ? 1 : -1, Random.Range(0.8f, 1f));
        }
        if (col.tag == "mid paddle")
        {
            velocity = new Vector2(transform.position.x < 0 ? 1 : -1, Random.Range(-1f, 1f));
        }
        if (col.tag == "bot paddle")
        {
            velocity = new Vector2(transform.position.x < 0 ? 1 : -1, Random.Range(-1f, 0.8f));
        }

        if (col.tag == "right border")
        {
            velocity = new Vector2(velocity.x, -velocity.y);
        }
        if (col.tag == "left border")
        {
            velocity = new Vector2(velocity.x, -velocity.y);
        }
    }
}